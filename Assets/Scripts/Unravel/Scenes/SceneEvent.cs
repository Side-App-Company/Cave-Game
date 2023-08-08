using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;

using Unravel.Scenes;

namespace Unravel
{
    namespace Scenes
    {
        public enum SCENE
        {
            NULL,
            MAIN_MENU,
            GAME,
        }

        namespace Directory
        {
            public static class SCENE_ADDRESSES
            {
                public static ReadOnlyDictionary<SCENE, string> MAP 
                = new ReadOnlyDictionary<SCENE, string>(
                    new Dictionary<SCENE, string>
                    {
                        { SCENE.MAIN_MENU, "Scenes/MainMenu.unity" },
                        //{ SCENE.GAME, "Scenes/Game.unity" }
                        { SCENE.GAME, "Scenes/TEST/GameScene.unity" }
                    }
                );
            }
        }
        
        public enum SCENE_EVENT
        {
            NULL,
            LOADING,
            ENQUEUED,
            UNLOADED,
            LOADED,
            READY,
            TRANSITIONED
        }
    }
}

public class SceneEvent
{
    public SCENE_EVENT sceneEvent {get; private set;}

    public SCENE currentScene {get; private set;}
    public SCENE previousScene {get; private set;}
    public SCENE enqueuedScene {get; private set;}

    public SceneEvent()
    {
        this.sceneEvent = SCENE_EVENT.NULL;
        
        this.currentScene = SCENE.NULL;
        this.previousScene = SCENE.NULL;
        this.enqueuedScene = SCENE.NULL;
    }

    public SceneEvent(SCENE_EVENT sceneEvent, SCENE currentScene, SCENE previousScene, SCENE enqueuedScene)
    {
        this.sceneEvent = sceneEvent;

        this.currentScene = currentScene;
        this.previousScene = previousScene;
        this.enqueuedScene = enqueuedScene;
    }

    public void resetSceneEvent(SCENE_EVENT sceneEvent, SCENE currentScene, SCENE previousScene, SCENE enqueuedScene)
    {
        this.sceneEvent = sceneEvent;

        this.currentScene = currentScene;
        this.previousScene = previousScene;
        this.enqueuedScene = enqueuedScene;
    }
}