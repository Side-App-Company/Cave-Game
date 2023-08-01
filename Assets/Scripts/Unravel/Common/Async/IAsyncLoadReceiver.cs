using UnityEngine.ResourceManagement.AsyncOperations;

public interface IAsyncLoadReceiver<TResource>
{
    public void onLoadedResource(AsyncOperationHandle<TResource> resource);
}
