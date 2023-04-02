using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Droppable
{
    public override DROPPABLES _name => DROPPABLES.SPEEDUP;
    GameObject _speedupPrefab;
    Transform _speedupTransform;
    private void Awake()
    {
        _speedupPrefab = gameObject;
        _speedupTransform = _speedupPrefab.GetComponent<Transform>();
        _speedupTransform.localPosition = new Vector3(Random.Range(-10.0f, 10.0f), 20, 0);
    }
    public override GameObject Do()
    {
        //Spawn Speedup timewarp
        return null;
    }
}