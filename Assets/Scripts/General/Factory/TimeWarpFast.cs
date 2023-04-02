using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarpFast : Droppable
{
    public override DROPPABLES _name => DROPPABLES.TIMEWARP_FAST;
    GameObject _timewarpFastPrefab;
    Transform _timewarpFastTransform;
    private void Awake()
    {
        _timewarpFastPrefab = gameObject;
        _timewarpFastTransform = _timewarpFastPrefab.GetComponent<Transform>();
        _timewarpFastTransform.localPosition = new Vector3(Random.Range(-10.0f, 10.0f), 20, 0);
    }
    public override GameObject Do()
    {
        //Spawn TimeWarpFast Power Down
        return null;
    }
}