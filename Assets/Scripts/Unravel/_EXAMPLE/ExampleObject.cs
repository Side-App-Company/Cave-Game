using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

using Unravel.Example;
using Unravel.Scenes;
using Unravel.Touch;

public class ExampleObject : MonoBehaviour,
IPubAccess<EXAMPLE_EVENT>,
IPubAccess<TouchEvent>,

IAsyncLoadReceiver<GameObject>

//IAsyncLoadReceiver<SceneInstance>,
//IAsyncUnloadReceiver<SceneInstance>
{
    [SerializeField]
    private Hub hub;

    private IExampleAccess exampleAccess;

    private IAssetAccess AssetAccess;
    private AssetReference objectRef = new AssetReference("Unravel/ExampleSphere.prefab");
    private AssetReference sceneRef = new AssetReference("Scenes/MainMenu.unity");
    private SceneInstance loadedScene;
    private bool assetsLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        this.exampleAccess = this.hub.getExampleAccess();
        this.hub.getExampleSubAccess().subscribe(this);
        
        this.hub.getTouchSubAccess().subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.assetsLoaded)
        {
            this.assetsLoaded = true;
            this.hub.getSceneAccess().enqueueScene(SCENE.GAME);
            this.hub.getAssetAccess().loadGameObject(this.objectRef, this);
        }
    }

/********** Example Events **********/
    public void publishEvent(EXAMPLE_EVENT e)
    {
        switch(e)
        {
            case EXAMPLE_EVENT.STOP:
                UnityEngine.Debug.Log("CODE 1");
                this.hub.getExampleSubAccess().unsubscribe(this);
                //this.hub.getExampleSubAccess().subExample(this);
                break;
            case EXAMPLE_EVENT.GO:
                UnityEngine.Debug.Log("CODE 2");
                ExampleData example = this.exampleAccess.getExampleData();
                //example.one = 7;
                //UnityEngine.Debug.Log("ExampleData Copy = " + example.one);
                break;
            case EXAMPLE_EVENT.RESTART:
                UnityEngine.Debug.Log("CODE 3");
                break;
            default:
                break;
        }
    }

/********** Touch Events **********/
    public void publishEvent(TouchEvent e)
    {
        UnityEngine.Debug.Log(e.gesture +"  "+ e.screenPos);
        /*switch(e.gesture)
        {
            case GESTURE.SWIPE_RIGHT:
                UnityEngine.Debug.Log(e.gesture);
                break;
            case GESTURE.SWIPE_LEFT:
                UnityEngine.Debug.Log(e.gesture);
                break;
            case GESTURE.SWIPE_UP:
                UnityEngine.Debug.Log(e.gesture);
                break;
            case GESTURE.SWIPE_DOWN:
                UnityEngine.Debug.Log(e.gesture);
                break;
            default:
                UnityEngine.Debug.Log("DEFAULT");
                break;
        }*/
    }

/********** Asset Loading **********/
    public void onLoadedResource(AsyncOperationHandle<GameObject> asset)
    {
        // TODO: Real error reporting.
        if(asset.Status == AsyncOperationStatus.Failed)
            return;
            
        UnityEngine.Debug.Log("COMPLETED GAME OBJECT LOAD");
        Object.Instantiate(asset.Result);
    }

    /*public void onLoadedResource(AsyncOperationHandle<SceneInstance> asset)
    {
        UnityEngine.Debug.Log("COMPLETED SCENE LOAD");
        this.loadedScene = asset.Result;

        //this.hub.getAssetSceneAccess().unloadScene(this.loadedScene, this);
    }

    public void onUnloadedResource(AsyncOperationHandle<SceneInstance> asset)
    {
        UnityEngine.Debug.Log("COMPLETED SCENE UNLOAD");
        this.loadedScene = new SceneInstance();
    }*/
    
/********** Clean Up **********/
    void OnDestroy()
    {
        this.hub.getExampleSubAccess().unsubscribe(this);
        this.hub.getTouchSubAccess().unsubscribe(this);
    }
}
