using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarpSlow : Droppable
{
    public override DROPPABLES _name => DROPPABLES.TIMEWARP_SLOW;
    GameObject _timewarpSlowPrefab;
    Transform _timewarpSlowTransform;
    private void Awake()
    {
        _timewarpSlowPrefab = gameObject;
        _timewarpSlowTransform = _timewarpSlowPrefab.GetComponent<Transform>();
        _timewarpSlowTransform.localPosition = new Vector3(Random.Range(-10.0f, 10.0f), 20, 0);
    }
    public override GameObject Do()
    {
        return null;
    }
}
