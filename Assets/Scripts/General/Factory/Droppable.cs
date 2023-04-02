using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Droppable : MonoBehaviour 
{
    public abstract DROPPABLES _name { get; }
    public abstract GameObject Do();
}