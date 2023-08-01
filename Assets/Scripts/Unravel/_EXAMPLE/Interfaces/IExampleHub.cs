using Unravel.Example;
public interface IExampleHub
{
    public IExampleAccess getExampleAccess();
    public ISubAccess<IPubAccess<EXAMPLE_EVENT>> getExampleSubAccess();
}
