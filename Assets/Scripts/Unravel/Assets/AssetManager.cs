using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;

public class AssetManager : MonoBehaviour,
    IAssetAccess
{
/********** Generic **********/
    private void loadAsset<TAsset>(AssetReference assetReference, IAsyncLoadReceiver<TAsset> callback)
    {
        // TODO: release assets from memory
        assetReference.LoadAsset<TAsset>().Completed += callback.onLoadedResource;
    }

/********** Text **********/
    public void loadTextAsset(AssetReference assetReference, IAsyncLoadReceiver<TextAsset> callback)
    {
        this.loadAsset<TextAsset>(assetReference, callback);
    }

/********** Sprites **********/
    public void loadSpriteSheet(AssetReference assetReference, IAsyncLoadReceiver<IList<Sprite>> callback)
    {
        this.loadAsset<IList<Sprite>>(assetReference, callback);
    }

/********** Game Objects **********/
    public void loadGameObject(AssetReference assetReference, IAsyncLoadReceiver<GameObject> callback)
    {
        this.loadAsset<GameObject>(assetReference, callback);
    }

/********** Animation **********/
    public void loadAnimator(AssetReference assetReference, IAsyncLoadReceiver<RuntimeAnimatorController> callback)
    {
        this.loadAsset<RuntimeAnimatorController>(assetReference, callback);
    }

/********** Materials **********/
    public void loadPhysicsMaterial2D(AssetReference assetReference, IAsyncLoadReceiver<PhysicsMaterial2D> callback)
    {
        this.loadAsset<PhysicsMaterial2D>(assetReference, callback);
    }    
}
