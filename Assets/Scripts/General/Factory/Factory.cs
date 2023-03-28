using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants.Drop;
using System;

//TODO:: Add code for factory
public static class Factory
{
    public static GameObject getObject(DROPPABLES d)
    {
        GameObject gameObject= null;
        switch (d)
        {
            case DROPPABLES.STALACTITE:
                break;
            case DROPPABLES.SHRINK:
                break;
            case DROPPABLES.SPEEDUP:
                break;
            case DROPPABLES.TIMEWARP_SLOW:
                break;
            case DROPPABLES.GROW:
                break;
            case DROPPABLES.SLOW:
                break;
            case DROPPABLES.TIMEWARP_FAST:
                break;
            default:
                break;
        }
        return gameObject;
    }
}

