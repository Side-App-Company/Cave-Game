public interface IPubAccess<TEvent>
{
    public void publishEvent(TEvent e);
}
