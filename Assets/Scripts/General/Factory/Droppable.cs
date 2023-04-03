using Constants.Drop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Droppable : MonoBehaviour 
{
    public abstract DROPPABLES _name { get; }
    public abstract GameObject Do();

    protected GameObject _droppableGameObject;
    protected Transform _droppableTransform;
    [SerializeField]
    protected float randomfall;
    [SerializeField]
    protected float minspeed = .2f;
    [SerializeField]
    protected float maxspeed = 2.0f;

    protected virtual void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 30;

        _droppableGameObject = gameObject;
        _droppableTransform = _droppableGameObject.GetComponent<Transform>();
        init();
    }
    protected virtual void Update()
    {
        fall();
        if(_droppableTransform.position.y < -95)
        {
            Destroy(_droppableGameObject);
        }
    }
    protected virtual void fall()
    {
        _droppableTransform.position = new Vector3(_droppableTransform.position.x, _droppableTransform.position.y - randomfall, _droppableTransform.position.z);
        randomfall = Random.Range(minspeed, maxspeed);
    }
    protected virtual void init()
    {
        _droppableTransform.localPosition = new Vector3(Random.Range(-100.0f, 100.0f), 20, 0);
        randomfall = Random.Range(minspeed, maxspeed);
    }
}