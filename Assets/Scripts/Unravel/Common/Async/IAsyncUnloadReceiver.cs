using UnityEngine.ResourceManagement.AsyncOperations;

public interface IAsyncUnloadReceiver<TResource>
{
    public void onUnloadedResource(AsyncOperationHandle<TResource> resource);
}
