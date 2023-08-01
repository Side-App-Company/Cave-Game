public interface ITouchHub
{
    public ITouchAccess getTouchAccess();
    public ISubAccess<IPubAccess<TouchEvent>> getTouchSubAccess();
}
