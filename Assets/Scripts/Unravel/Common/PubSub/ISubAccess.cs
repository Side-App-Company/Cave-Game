public interface ISubAccess<T> where T : class
{
    public void subscribe(T endPoint);
    public void unsubscribe(T endPoint);
}
