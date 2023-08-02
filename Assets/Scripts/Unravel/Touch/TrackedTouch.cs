using UnityEngine;

using Unravel.Touch;

public class TrackedTouch
{
    public int touchId {get; private set;}
    public Vector2 startPosition {get; private set;}
    public SCREEN_POS screenPos {get; private set;}

    public TouchPhase lastPhase;
    public bool trackMovement;
    public bool trackRelease;

    public bool isActive{get; private set;}

    // NOTE: This is used for rapid memory allocation
    public TrackedTouch(int touchId)
    {
        this.touchId = touchId;
        this.isActive = false;
    }

    public TrackedTouch(int touchId, Vector2 startPosition, SCREEN_POS screenPos)
    {
        this.touchId = touchId;
        this.resetTouch(startPosition, screenPos);
    }

    public void resetTouch(Vector2 startPosition, SCREEN_POS screenPos, bool trackRelease = true, bool trackMovement = true)
    {
        this.startPosition = startPosition;
        this.screenPos = screenPos;

        this.lastPhase = TouchPhase.Began;
        this.trackRelease = trackRelease;
        this.trackMovement = trackMovement;

        this.isActive = true;
    }

    public void endTouch()
    {
        this.isActive = false;
    }
}
