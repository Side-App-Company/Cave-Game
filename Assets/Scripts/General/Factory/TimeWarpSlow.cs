using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarpSlow : Droppable
{
    public override DROPPABLES _name => DROPPABLES.TIMEWARP_SLOW;
    GameObject _timewarpSlowPrefab;
    public override GameObject Do()
    {
        return null;
    }
}
