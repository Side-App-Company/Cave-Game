using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stalactite : Droppable
{
    public override DROPPABLES _name => DROPPABLES.STALACTITE;
    GameObject _stalactitePrefab;
    Transform _stalactiteTransform;
    private void Awake()
    {
        _stalactitePrefab = gameObject;
        _stalactiteTransform = _stalactitePrefab.GetComponent<Transform>();
        _stalactiteTransform.localPosition = new Vector3(0, 20, 0);
    }
    public override GameObject Do()
    {
        if(_stalactitePrefab == null )
            _stalactitePrefab = gameObject;
        
        //Spawn triangle
        Instantiate(_stalactitePrefab, _stalactiteTransform);
        return _stalactitePrefab;
    }
}
