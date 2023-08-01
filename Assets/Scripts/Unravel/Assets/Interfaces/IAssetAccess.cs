using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;

public interface IAssetAccess
{
    public void loadTextAsset(AssetReference assetReference, IAsyncLoadReceiver<TextAsset> callback);

    public void loadSpriteSheet(AssetReference assetReference, IAsyncLoadReceiver<IList<Sprite>> callback);

    public void loadGameObject(AssetReference assetReference, IAsyncLoadReceiver<GameObject> callback);

    public void loadAnimator(AssetReference assetReference, IAsyncLoadReceiver<RuntimeAnimatorController> callback);

    public void loadPhysicsMaterial2D(AssetReference assetReference, IAsyncLoadReceiver<PhysicsMaterial2D> callback);
}
