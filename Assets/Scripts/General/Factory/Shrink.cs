using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : Droppable
{
    public override DROPPABLES _name => DROPPABLES.SHRINK;
    GameObject _shrinkPrefab;
    Transform _shrinkTransform;
    private void Awake()
    {
        _shrinkPrefab = gameObject;
        _shrinkTransform = _shrinkPrefab.GetComponent<Transform>();
        _shrinkTransform.localPosition = new Vector3(Random.Range(-10.0f, 10.0f), 20, 0);
    }
    public override GameObject Do()
    {
        //Spawn Shrink powerup
        return null;
    }
}
