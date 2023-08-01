using System;
using UnityEngine;

using Unravel.Touch;

public class TouchManager : PubSubAccess<TouchEvent>,
ITouchAccess
{
/********** Data **********/
    private Camera mainCamera;

    private TouchEvent touchEvent;

    private TrackedTouch[] trackedTouches;
    private Touch touch;
    private int touchCount = 0;

    private Vector2 touchDelta;
    private Vector3 publishPosition;

    // TODO: More elegant solution, GAMEWORLD_DEBUG MODE
    // NOTE: In game simulation
    [SerializeField] 
    private bool GAME_DEBUG_ENABLED = false;

/********** Construction **********/
    void Awake()
    {
        this.init();
    }

    private void init()
    {
        // NOTE: Always cache Camera.main
        this.mainCamera = Camera.main;

        this.touchEvent = new TouchEvent();

        this.trackedTouches = new TrackedTouch[5];
        for( int i = 0; i < 5; ++i)
        {
            this.trackedTouches[i] = new TrackedTouch(i);
        }

        this.touchDelta = Vector2.zero;
        this.publishPosition = Vector3.zero;
    }

/********** Update **********/
    void FixedUpdate()
    {
        this.touchCount = Input.touchCount;
        this.readTouches();

        // NOTE: Enable this block for editor testing
        if(GAME_DEBUG_ENABLED)
        {
            this.readDebugController();
            this.readDebugTouch();
        }
    }

/********** Actions **********/
    private void readTouches()
    {
        if(this.touchCount > 0)
        {
            // TODO: Touch is dropping fingers
            for(int i = 0; i < this.touchCount; ++i)
            {
                this.touch = Input.GetTouch(i);
                int touchIndex = this.touch.fingerId;
                
                // NOTE: Create a tracked touch
                if (this.touch.phase == TouchPhase.Began)
                {
                    SCREEN_POS screenPos;
                    if(this.touch.position.x < Screen.width/2)
                        screenPos = SCREEN_POS.LEFT;
                    else
                        screenPos = SCREEN_POS.RIGHT;

                    this.trackedTouches[touchIndex].resetTouch(this.touch.position, screenPos);
                }
                // NOTE: Handles tracked touch movement
                else if(this.touch.phase == TouchPhase.Moved 
                    && this.trackedTouches[touchIndex].isActive
                ){

                    if(this.trackedTouches[touchIndex].trackMovement)
                        this.publishTouchEvent(GESTURE.MOVED, this.trackedTouches[touchIndex].screenPos, this.touch.position);
                    else
                        this.evaluateGesture(this.touch.position, touchIndex);

                    this.trackedTouches[touchIndex].lastPhase = TouchPhase.Moved;

                }
                // NOTE: Destroy a tracked touch
                else if (this.touch.phase == TouchPhase.Ended || this.touch.phase == TouchPhase.Canceled)
                {
                    if(this.trackedTouches[touchIndex].trackRelease)
                        this.publishTouchEvent(GESTURE.RELEASE, this.trackedTouches[touchIndex].screenPos, this.touch.position);

                    this.trackedTouches[touchIndex].endTouch();
                }
            }

        }
    }

    private void evaluateGesture(Vector2 touchPosition, int touchIndex)
    {
        this.touchDelta = touchPosition - this.trackedTouches[touchIndex].startPosition;

        if(this.touchDelta.magnitude > TOUCH_CONSTANTS.swipeTrigger)
        {
            // NOTE: Swipe up or down
            if(Math.Abs(this.touchDelta.x) < Math.Abs(this.touchDelta.y))
            {
                if(this.touchDelta.y < 0)
                    this.publishTouchEvent(GESTURE.SWIPE_DOWN, this.trackedTouches[touchIndex].screenPos, touchPosition);
                else
                    this.publishTouchEvent(GESTURE.SWIPE_UP, this.trackedTouches[touchIndex].screenPos, touchPosition);

                    this.trackedTouches[touchIndex].endTouch();
            }
            // NOTE: Swipe left or right
            else
            {
                if(this.touchDelta.x < 0)
                {
                    // NOTE: Provider Arrow aiming.
                    //this.trackedTouches[touchIndex].trackMovement = true;
                    //this.trackedTouches[touchIndex].trackRelease = true;
                    this.publishTouchEvent(GESTURE.SWIPE_LEFT, this.trackedTouches[touchIndex].screenPos, this.trackedTouches[touchIndex].startPosition);
                }
                else
                {
                    this.publishTouchEvent(GESTURE.SWIPE_RIGHT, this.trackedTouches[touchIndex].screenPos, touchPosition);
                    this.trackedTouches[touchIndex].endTouch();
                }
            }
        }
    }

/********** Debug **********/
    private void readDebugTouch()
    {
        // NOTE: MouseInput resets every frame
        // NOTE: TouchPhase.Began
        if(Input.GetMouseButtonDown(0))
        {
            if(!this.trackedTouches[0].isActive)
            {
                Vector2 startPosition = Input.mousePosition;
                SCREEN_POS screenPos;
                if(startPosition.x < Screen.width/2)
                    screenPos = SCREEN_POS.LEFT;
                else
                    screenPos = SCREEN_POS.RIGHT;

                this.trackedTouches[0].resetTouch(startPosition, screenPos);
            }
        }
        
        else if(this.trackedTouches[0].isActive)
        {
            Vector2 currentPosition = Input.mousePosition;
            
            // NOTE: TouchPhase.Ended
            if(!Input.GetMouseButton(0))
            {
                if(this.trackedTouches[0].trackRelease)
                    this.publishTouchEvent(GESTURE.RELEASE, this.trackedTouches[0].screenPos, currentPosition);
                //this.trackedTouches.Clear();
                this.trackedTouches[0].endTouch();
            }
            // NOTE: TouchPhase.Moved
            else if(this.trackedTouches[0].trackMovement)
                this.publishTouchEvent(GESTURE.MOVED, this.trackedTouches[0].screenPos, currentPosition);
            else
                this.evaluateGesture(currentPosition, 0);
        }

    }

    private void readDebugController()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            this.publishTouchEvent(GESTURE.SWIPE_UP, SCREEN_POS.NULL, Vector3.zero);
        
        if(Input.GetKeyDown(KeyCode.DownArrow))
            this.publishTouchEvent(GESTURE.SWIPE_DOWN, SCREEN_POS.NULL, Vector3.zero);
    }

/********** Lifecycle **********/
    public void clearTouches()
    {
        for(int i = 0; i < this.trackedTouches.Length; ++i)
        {
            this.trackedTouches[i].endTouch();
        }
    }

/********** Events **********/
    private void publishTouchEvent(GESTURE gesture, SCREEN_POS screenPos, Vector3 position)
    {
        this.publishPosition = position;
        // NOTE: Initialize TouchEventArgs object with new TOUCH EVENT
        this.touchEvent.resetTouchEvent(gesture, screenPos, ref this.publishPosition);

        this.publishEvent(this.touchEvent);
    }
}
