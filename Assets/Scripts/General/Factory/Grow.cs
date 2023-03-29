using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : Droppable
{
    public override DROPPABLES _name => DROPPABLES.GROW;
    GameObject _growPrefab;
    public override GameObject Do()
    {
        //Spawn Grow Power Down
        return null;
    }
}
