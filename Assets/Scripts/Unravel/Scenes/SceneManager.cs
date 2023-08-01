using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

using Unravel.Scenes;
using Unravel.Scenes.Directory;

public class SceneManager : PubSubAccess<SceneEvent>,
    ISceneAccess,
    IAsyncLoadReceiver<SceneInstance>,
    IAsyncUnloadReceiver<SceneInstance>
{
/********** Data **********/
    [SerializeField]
    private GameObject loading_canvas;

    [SerializeField]
    private bool markScenesReady = true;

    private SCENE DEFAULT_SCENE;
    private SCENE ENQUEUED_SCENE;
    private List<SCENE> sceneHistory;
    private SceneInstance currentScene;
    private AssetReference enqueuedScene;

/********** Construction **********/
    void Awake()
    {
        this.init();
    }

    private void init()
    {
        this.DEFAULT_SCENE = SCENE.MAIN_MENU;
        this.ENQUEUED_SCENE = this.DEFAULT_SCENE;
        this.sceneHistory = new List<SCENE>();
        this.currentScene = new SceneInstance();
        this.enqueuedScene = new AssetReference(SCENE_ADDRESSES.MAP[this.ENQUEUED_SCENE]);
    }

    void Start()
    {
        this.loadScene(this.enqueuedScene, this);
    }

    // TODO: Buttonless Scene Hopping/Teleporting in the Inspector

/********** Data Access **********/
    public IReadOnlyList<SCENE> getSceneMap()
    {
        return this.sceneHistory;
    }

    public SCENE getCurrentScene()
    {
        int sceneCount = this.sceneHistory.Count;
        
        if(sceneCount > 0)
            return this.sceneHistory[sceneCount - 1];
        else
            return SCENE.NULL;
    }

    public SCENE getPreviousScene()
    {
        int sceneCount = this.sceneHistory.Count;
        
        if(sceneCount > 1)
            return this.sceneHistory[sceneCount - 2];
        else
            return SCENE.NULL;
    }

/********** Method Access **********/
    public void enqueueScene(SCENE scene)
    {
        if(SCENE_ADDRESSES.MAP.ContainsKey(scene))
        {
            this.toggleLoadingCanvas(true);
            this.ENQUEUED_SCENE = scene;

            this.enqueuedScene = new AssetReference(SCENE_ADDRESSES.MAP[this.ENQUEUED_SCENE]);

            this.publishSceneEvent(SCENE_EVENT.ENQUEUED);
            this.unloadScene(this.currentScene, this);
        }
        else
            UnityEngine.Debug.Log("Invalid Scene. Scene may not be registered in SceneEvent.cs");
    }

    public void markSceneReady(SCENE scene)
    {
        if(this.markScenesReady)
            this.sceneReady(scene);
    }

/********** Loadind UI **********/
    private void sceneReady(SCENE scene)
    {
        if (scene == this.getCurrentScene() || scene == this.ENQUEUED_SCENE)
        {
            this.publishSceneEvent(SCENE_EVENT.READY);
            this.toggleLoadingCanvas(false);
        }
    }

    private void toggleLoadingCanvas(bool active)
    {
        this.loading_canvas.SetActive(active);
        if(active)
            this.publishSceneEvent(SCENE_EVENT.LOADING);

        // NOTE: Order of LOADED and TRANSITIONED swap depending on simplicity of scene
        if(!active)
            this.publishSceneEvent(SCENE_EVENT.TRANSITIONED);
    }

/********** Scene Loading **********/
    private void loadScene(AssetReference assetReference, IAsyncLoadReceiver<SceneInstance> callback)
    {
        assetReference.LoadSceneAsync(LoadSceneMode.Additive).Completed += callback.onLoadedResource;
    }

    public void onLoadedResource(AsyncOperationHandle<SceneInstance> asset)
    {
        // TODO: Real error reporting.
        if(asset.Status == AsyncOperationStatus.Failed)
            return;

        UnityEngine.Debug.Log("COMPLETED SCENE LOAD");

        this.sceneHistory.Add(this.ENQUEUED_SCENE);

        this.currentScene = asset.Result;

        this.ENQUEUED_SCENE = SCENE.NULL;
        
        if(!this.markScenesReady)
            this.sceneReady(this.getCurrentScene());

        // NOTE: Order of LOADED and TRANSITIONED swap depending on simplicity of scene
        this.publishSceneEvent(SCENE_EVENT.LOADED);
    }

/********** Scene Unloading **********/
    private void unloadScene(SceneInstance scene, IAsyncUnloadReceiver<SceneInstance> callback)
    {
        Addressables.UnloadSceneAsync(scene).Completed += callback.onUnloadedResource;
    }

    public void onUnloadedResource(AsyncOperationHandle<SceneInstance> asset)
    {
        // TODO: Real error reporting.
        if(asset.Status == AsyncOperationStatus.Failed)
            return;
        
        UnityEngine.Debug.Log("COMPLETED SCENE UNLOAD");

        this.currentScene = new SceneInstance();
        this.loadScene(this.enqueuedScene, this);

        this.publishSceneEvent(SCENE_EVENT.UNLOADED);
    }

/********** Scene Publishing **********/
    private void publishSceneEvent(SCENE_EVENT sceneEvent)
    {
        SceneEvent publishSceneEvent = new SceneEvent(sceneEvent, this.getCurrentScene(), this.getPreviousScene(), this.ENQUEUED_SCENE);

        this.publishEvent(publishSceneEvent);
    }
}
