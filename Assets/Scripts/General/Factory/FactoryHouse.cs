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

    [SerializeField]
    private int stalactites = 0;

    [SerializeField]
    private int maxSpawn = 101;

    private GameObject factoryHouse;
    private GameObject enemyParent;
    private GameObject itemParent;

    [SerializeField]
    private float minTime = .1f;
    [SerializeField]
    private float maxTime = .4f;
    float randomTime;

    [SerializeField]
    private float oilTime = 5.5f;

    [SerializeField]
    private float minpowerTime = .75f;
    [SerializeField]
    private float maxpowerTime = 3.5f;
    private float powerTime;

    [SerializeField]
    private bool timewarpFastbool = false;
    [SerializeField]
    private bool timewarpSlowbool = false;
    [SerializeField]
    private float timewarp = 4.2f;

    private int powerSpawn;

    private void Awake()
    {
        factoryHouse = gameObject;
        enemyParent = GameObject.FindGameObjectWithTag("Enemy_Space");
        itemParent = GameObject.FindGameObjectWithTag("Item_Space");
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Factory.getObject(DROPPABLES.STALACTITE, stalactite, enemyParent.transform);
            stalactites++;
        }
        randomTime = Random.Range(minTime, maxTime);
        powerTime = Random.Range(minpowerTime, maxpowerTime);
        powerSpawn = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        spawning();
    }
    private void timewarpFast()
    {
        if (timewarpSlowbool)
        {
            timewarpFastbool = !timewarpFastbool;
            foreach (Transform item in enemyParent.transform)
            {
                var script = item.GetComponent<Droppable>();
                if (script != null)
                    script.timewarpFastbool = !script.timewarpFastbool;
            }
            timewarp = 4.2f;
            return;
        }
        foreach (Transform item in enemyParent.transform)
        {
            var script = item.GetComponent<Droppable>();
            if (script != null)
                script.timewarpFastbool = true;
        }
        if (timewarp >= 0)
        {
            timewarp = timewarp - Time.deltaTime;
        }
        else
        {
            timewarpFastbool = false;
            timewarp = 4.2f;
        }
    }
    private void timewarpSlow()
    {
        if (timewarpFastbool)
        {
            timewarpSlowbool = false;
            foreach (Transform item in enemyParent.transform)
            {
                var script = item.GetComponent<Droppable>();
                if (script != null)
                    script.timewarpSlowbool = !script.timewarpSlowbool;
            }
            timewarp = 4.2f;
            return;
        }
        foreach (Transform item in enemyParent.transform)
        {
            var script = item.GetComponent<Droppable>();
            if (script != null)
                script.timewarpSlowbool = true;
        }
        if (timewarp >= 0)
        {
            timewarp = timewarp - Time.deltaTime;
        }
        else
        {
            timewarpSlowbool = false;
            timewarp = 4.2f;
        }
    }

    private void spawning()
    {
        randomTime = randomTime - Time.deltaTime;
        oilTime = oilTime - Time.deltaTime;
        powerTime = powerTime - Time.deltaTime;
        if (randomTime <= 0 && stalactites < maxSpawn)
        {
            Factory.getObject(DROPPABLES.STALACTITE, stalactite, enemyParent.transform);
            stalactites++;
            if(stalactites > 24)
            {
                minTime = 1.2f;
                maxTime = 2.4f;
            }
            randomTime = Random.Range(minTime, maxTime);
        }
        if(powerTime <= 0)
        {
            switch (powerSpawn)
            {
                default:
                    break;
                case 1:
                    Factory.getObject(DROPPABLES.SHRINK, shrink, itemParent.transform);
                    break;
                case 2:
                    Factory.getObject(DROPPABLES.SPEEDUP, speedUp, itemParent.transform);
                    break;
                case 3:
                    Factory.getObject(DROPPABLES.TIMEWARP_SLOW, timewarpslow, itemParent.transform);
                    break;
                case 4:
                    Factory.getObject(DROPPABLES.GROW, grow, itemParent.transform);
                    break;
                case 5:
                    Factory.getObject(DROPPABLES.SLOW, slow, itemParent.transform);
                    break;
                case 6:
                    Factory.getObject(DROPPABLES.TIMEWARP_FAST, timewarpfast, itemParent.transform);
                    break;
            }
            powerTime = Random.Range(minpowerTime, maxpowerTime);
            powerSpawn = Random.Range(1, 6);
        }
        if (oilTime <= 0)
        {
            Factory.getObject(DROPPABLES.OIL, oil, itemParent.transform);
            oilTime = 5.5f;
        }
        if (timewarpFastbool)
        {
            timewarpFast();
        }
        if (timewarpSlowbool)
        {
            timewarpSlow();
        }
    }
}
