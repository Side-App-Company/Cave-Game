using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Droppable
{
    public abstract DROPPABLES _name { get; }
    public abstract GameObject Do();
}