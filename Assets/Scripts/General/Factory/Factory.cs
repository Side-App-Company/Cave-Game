using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants.Drop;
using System;

//TODO:: 
public static class Factory
{
    public static GameObject getObject(DROPPABLES d)
    {
        GameObject gameObject= null;
        switch (d)
        {
            case DROPPABLES.STALACTITE:
                UnityEngine.Debug.Log("Stalactite");
                Stalactite stalactite = new Stalactite();
                gameObject = stalactite.Do();
                break;
            case DROPPABLES.SHRINK:
                Shrink shrink = new Shrink();
                gameObject = shrink.Do();
                UnityEngine.Debug.Log("Shrink");
                break;
            case DROPPABLES.SPEEDUP:
                SpeedUp speedUp = new SpeedUp();
                gameObject = speedUp.Do();
                UnityEngine.Debug.Log("Speedup");
                break;
            case DROPPABLES.TIMEWARP_SLOW:
                TimeWarpSlow timewarpslow = new TimeWarpSlow();
                gameObject = timewarpslow.Do();
                UnityEngine.Debug.Log("Time Warp Slow");
                break;
            case DROPPABLES.GROW:
                Grow grow = new Grow();
                gameObject = grow.Do();
                UnityEngine.Debug.Log("Grow");
                break;
            case DROPPABLES.SLOW:
                Slow slow = new Slow();
                gameObject = slow.Do();
                UnityEngine.Debug.Log("Slow");
                break;
            case DROPPABLES.TIMEWARP_FAST:
                TimeWarpFast timeWarpFast = new TimeWarpFast();
                gameObject = timeWarpFast.Do();
                UnityEngine.Debug.Log("Time Warp Fast");
                break;
            case DROPPABLES.OIL:
                Oil oil = new Oil();
                gameObject = oil.Do();
                UnityEngine.Debug.Log("Oil");
                break;
            default:
                break;
        }
        return gameObject;
    }
}

