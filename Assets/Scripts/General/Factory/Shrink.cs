using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : Droppable
{
    public override DROPPABLES _name => DROPPABLES.SHRINK;
    GameObject _shrinkPrefab;
    public override GameObject Do()
    {
        //Spawn Shrink powerup
        return null;
    }
}