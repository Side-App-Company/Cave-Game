using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : Droppable
{
    public override DROPPABLES _name => DROPPABLES.SLOW;
    GameObject _slowPrefab;
    public override GameObject Do()
    {
        //Spawn Slow Power down
        return null;
    }
}