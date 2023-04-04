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
        if (timewarpFastbool)
        {
            if (timewarp >= 0)
            {
                timewarp = timewarp - Time.deltaTime;
                minspeed = 2f;
                maxspeed = 5f;
            }
            else
            {
                timewarpFastbool = false;
                timewarp = 4.2f;
                minspeed = .2f;
                maxspeed = 2f;
            }
        }
        if (timewarpSlowbool)
        {
            if (timewarp >= 0)
            {
                timewarp = timewarp - Time.deltaTime;
                minspeed = .01f;
                maxspeed = .2f;
            }
            else
            {
                timewarpSlowbool = false;
                timewarp = 4.2f;
                minspeed = .2f;
                maxspeed = 2f;
            }
        }
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
