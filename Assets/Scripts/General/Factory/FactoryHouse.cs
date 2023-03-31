using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants.Drop;

public class FactoryHouse : MonoBehaviour
{
    [SerializeField]
    private GameObject stalactite;
    
    // Start is called before the first frame update
    void Start()
    {
        Factory.getObject(DROPPABLES.STALACTITE, stalactite, stalactite.transform);
        /*Factory.getObject(DROPPABLES.SHRINK);
        Factory.getObject(DROPPABLES.SPEEDUP);
        Factory.getObject(DROPPABLES.TIMEWARP_SLOW);
        Factory.getObject(DROPPABLES.GROW);
        Factory.getObject(DROPPABLES.SLOW);
        Factory.getObject(DROPPABLES.TIMEWARP_FAST);
        Factory.getObject(DROPPABLES.STALACTITE);*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
