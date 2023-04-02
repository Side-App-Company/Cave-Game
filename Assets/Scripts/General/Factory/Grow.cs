using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : Droppable
{
    public override DROPPABLES _name => DROPPABLES.GROW;
    GameObject _growPrefab;
    Transform _growTransform;
    private void Awake()
    {
        _growPrefab = gameObject;
        _growTransform = _growPrefab.GetComponent<Transform>();
        _growTransform.localPosition = new Vector3(Random.Range(-10.0f,10.0f), 20, 0);
    }
    public override GameObject Do()
    {
        //Spawn Grow Power Down
        return null;
    }
}
