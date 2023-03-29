using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants.Drop;
using System;

//TODO:: 
public static class Factory
{
    static GameObject _stalactitePrefab;
    static GameObject _shrinkPrefab;
    static GameObject _speedupPrefab;
    static GameObject _timewarpSlowPrefab;
    static GameObject _growPrefab;
    static GameObject _slowPrefab;
    static GameObject _timewarpFastPrefab;
    static Vector2 _spawnPoint = new Vector2(0, 0);

    public static GameObject getObject(DROPPABLES d)
    {
        GameObject gameObject= null;
        switch (d)
        {
            case DROPPABLES.STALACTITE:
                UnityEngine.Debug.Log("Stalactite");
                break;
            case DROPPABLES.SHRINK:
                UnityEngine.Debug.Log("Shrink");
                break;
            case DROPPABLES.SPEEDUP:
                UnityEngine.Debug.Log("Speedup");
                break;
            case DROPPABLES.TIMEWARP_SLOW:
                UnityEngine.Debug.Log("Time Warp Slow");
                break;
            case DROPPABLES.GROW:
                UnityEngine.Debug.Log("Grow");
                break;
            case DROPPABLES.SLOW:
                UnityEngine.Debug.Log("Slow");
                break;
            case DROPPABLES.TIMEWARP_FAST:
                UnityEngine.Debug.Log("Time Warp Fast");
                break;
            default:
                break;
        }
        return gameObject;
    }
}

