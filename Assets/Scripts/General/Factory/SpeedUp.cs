using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Droppable
{
    public override DROPPABLES _name => DROPPABLES.SPEEDUP;
    GameObject _speedupPrefab;
    public override GameObject Do()
    {
        //Spawn Speedup timewarp
        return null;
    }
}