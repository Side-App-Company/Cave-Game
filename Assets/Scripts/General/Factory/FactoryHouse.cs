using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants.Drop;

public class FactoryHouse : MonoBehaviour
{
    [SerializeField]
    private GameObject stalactite;

    [SerializeField]
    private GameObject shrink;

    [SerializeField]
    private GameObject speedUp;

    [SerializeField]
    private GameObject timewarpslow;

    [SerializeField]
    private GameObject grow;

    [SerializeField]
    private GameObject slow;

    [SerializeField]
    private GameObject timewarpfast;

    [SerializeField]
    private GameObject oil;

    private GameObject factoryHouse;

    private void Awake()
    {
        factoryHouse = gameObject;
    }


    // Start is called before the first frame update
    void Start()
    {
        Factory.getObject(DROPPABLES.STALACTITE, stalactite, factoryHouse.transform);
        Factory.getObject(DROPPABLES.SHRINK, shrink, factoryHouse.transform);
        Factory.getObject(DROPPABLES.SPEEDUP, speedUp, factoryHouse.transform);
        Factory.getObject(DROPPABLES.TIMEWARP_SLOW, timewarpslow, factoryHouse.transform);
        Factory.getObject(DROPPABLES.GROW, grow, factoryHouse.transform);
        Factory.getObject(DROPPABLES.SLOW, slow, factoryHouse.transform);
        Factory.getObject(DROPPABLES.TIMEWARP_FAST, timewarpfast, factoryHouse.transform);
        Factory.getObject(DROPPABLES.OIL, oil, factoryHouse.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
