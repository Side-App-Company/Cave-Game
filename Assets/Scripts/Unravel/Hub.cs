using UnityEngine;

using Unravel.Example;
public class Hub : MonoBehaviour,
    IExampleHub,
    ISceneHub,
    IAssetHub,
    ITouchHub
{
/********** Example Access **********/
    [SerializeField]
    private ExampleManager exampleManager;

    public IExampleAccess getExampleAccess()
    {
        return this.exampleManager;
    }
    public ISubAccess<IPubAccess<EXAMPLE_EVENT>> getExampleSubAccess()
    {
        return this.exampleManager;
    }

/********** Scene Access **********/
    [SerializeField]
    private SceneManager sceneManager;

    public ISceneAccess getSceneAccess()
    {
        return this.sceneManager;
    }

    public ISubAccess<IPubAccess<SceneEvent>> getSceneSubAccess()
    {
        return this.sceneManager;
    }

/********** Asset Access **********/
    [SerializeField]
    private AssetManager assetManager;

    public IAssetAccess getAssetAccess()
    {
        return this.assetManager;
    }

/********** Touch Access **********/
    [SerializeField]
    private TouchManager touchManager;

    public ITouchAccess getTouchAccess()
    {
        return this.touchManager;
    }

    public ISubAccess<IPubAccess<TouchEvent>> getTouchSubAccess()
    {
        return this.touchManager;
    }
}
