using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stalactite : Droppable
{
    public override DROPPABLES _name => DROPPABLES.STALACTITE;

    protected override void Update()
    {
        fall();
        if (_droppableTransform.position.y <= -95)
        {
            init();
        }
    }
    public override GameObject Do()
    {
        //
        return null;
    }
}
