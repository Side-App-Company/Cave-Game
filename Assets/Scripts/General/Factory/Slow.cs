using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : Droppable
{
    public override DROPPABLES _name => DROPPABLES.SLOW;
    GameObject _slowPrefab;
    Transform _slowTransform;

    private void Awake()
    {
        _slowPrefab = gameObject;
        _slowTransform = _slowPrefab.GetComponent<Transform>();
        _slowTransform.localPosition = new Vector3(Random.Range(-10.0f, 10.0f), 20, 0);
    }
    public override GameObject Do()
    {
        //Change position
        return null;
    }
}