public interface ISceneHub
{
    public ISceneAccess getSceneAccess();
    public ISubAccess<IPubAccess<SceneEvent>> getSceneSubAccess();
}