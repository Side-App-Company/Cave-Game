using System;
using UnityEngine;

using Unravel.Touch;

namespace Unravel
{
    namespace Touch
    {
        public enum GESTURE
        {
            NULL,

        /*********** Touch Values *************/
            HOLD,
            HOLD_RIGHT,
            HOLD_LEFT,
            TAP,
            DOUBLE_TAP,
            RELEASE,
            MOVED,

        /*********** Swipe Values *************/
            SWIPE_RIGHT,
            SWIPE_LEFT,
            SWIPE_UP,
            SWIPE_DOWN
        }

        public enum SCREEN_POS
        {
            NULL,

            RIGHT,
            LEFT,
            TOP,
            BOTTOM
        }

        public static class TOUCH_CONSTANTS
        {
            public static readonly int swipeTrigger = 25;
            // TODO: Increase max drag
            public static readonly float maxDragDistance = 3f; 
        }
    }
}

// TODO: Add more information related to touch. Position, velocity, etc.
// TODO: Add finger count
public class TouchEvent
{
    public GESTURE gesture {get; private set;}

    public SCREEN_POS screenPos {get; private set;}
    public Vector3 position {get; private set;}

    public TouchEvent(){
        this.gesture = GESTURE.NULL;

        this.screenPos = SCREEN_POS.NULL;
        this.position = Vector3.zero;
    }

    public TouchEvent(GESTURE gesture, SCREEN_POS screenPos, ref Vector3 position)
    {
        this.gesture = gesture;

        this.screenPos = screenPos;
        this.position = position;
    }

    public void resetTouchEvent(GESTURE gesture, SCREEN_POS screenPos, ref Vector3 position)
    {
        this.gesture = gesture;

        this.screenPos = screenPos;
        this.position = position;
    }
}
