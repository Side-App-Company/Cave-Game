using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants.Drop;
using System;

//TODO:: 
public static class Factory
{
    public static GameObject getObject(DROPPABLES d, GameObject go, Transform t)
    {
        GameObject gameObject= go;
        Transform test = t;
        switch (d)
        {
            case DROPPABLES.STALACTITE:
                UnityEngine.Object.Instantiate(gameObject.gameObject, test);
                break;
            case DROPPABLES.SHRINK:
                UnityEngine.Object.Instantiate(gameObject.gameObject, test);
                break;
            case DROPPABLES.SPEEDUP:
                UnityEngine.Object.Instantiate(gameObject.gameObject, test);
                break;
            case DROPPABLES.TIMEWARP_SLOW:
                UnityEngine.Object.Instantiate(gameObject.gameObject, test);
                break;
            case DROPPABLES.GROW:
                UnityEngine.Object.Instantiate(gameObject.gameObject, test);
                break;
            case DROPPABLES.SLOW:
                UnityEngine.Object.Instantiate(gameObject.gameObject, test);
                break;
            case DROPPABLES.TIMEWARP_FAST:
                UnityEngine.Object.Instantiate(gameObject.gameObject, test);
                break;
            case DROPPABLES.OIL:
                UnityEngine.Object.Instantiate(gameObject.gameObject, test);
                break;
            default:
                break;
        }
        return gameObject;
    }
}

