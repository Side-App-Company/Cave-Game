using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : Droppable
{
    public override DROPPABLES _name => DROPPABLES.SHRINK;
    GameObject _oilPrefab;
    Transform _oilTransform;
    private void Awake()
    {
        _oilPrefab = gameObject;
        _oilTransform = _oilPrefab.GetComponent<Transform>();
        _oilTransform.localPosition = new Vector3(Random.Range(-10.0f, 10.0f), 20, 0);
    }
    public override GameObject Do()
    {
        //Spawn Oil powerup
        return null;
    }
}
