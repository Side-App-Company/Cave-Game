using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : Droppable
{
    public override DROPPABLES _name => DROPPABLES.SHRINK;
    public override GameObject Do()
    {
        //Spawn Oil powerup
        return null;
    }
}
