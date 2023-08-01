//using UnityEngine;

using Unravel.Example;

public class ExampleManager : PubSubAccess<EXAMPLE_EVENT>,
IExampleAccess
{
    private ExampleData exampleData;

    void Start()
    {
        this.init();
    }

    void Update()
    {
        //this.publishEvent(EXAMPLE_EVENT.GO);
        //UnityEngine.Debug.Log("ExampleData True = " + this.exampleData.one);
    }

    private void init()
    {
        this.exampleData = new ExampleData();
    }

    public ExampleData getExampleData()
    {
        return new ExampleData(this.exampleData);
    }

}
