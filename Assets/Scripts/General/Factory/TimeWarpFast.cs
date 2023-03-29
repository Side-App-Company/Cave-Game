using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarpFast : Droppable
{
    public override DROPPABLES _name => DROPPABLES.TIMEWARP_FAST;
    GameObject _timewarpFastPrefab;
    public override GameObject Do()
    {
        //Spawn TimeWarpFast Power Down
        return null;
    }
}