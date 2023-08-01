using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;

using Unravel.Scenes;

public interface ISceneAccess
{
/********** Data Access **********/
    public IReadOnlyList<SCENE> getSceneMap();
    public SCENE getCurrentScene();
    public SCENE getPreviousScene();

/********** Method Access **********/
    public void enqueueScene(SCENE scene);
    public void markSceneReady(SCENE scene);
}
