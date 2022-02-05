namespace Pasqliecli.Backend.Exception.DI;

public class ServiceNotFoundException : BasicException
{
    public ServiceNotFoundException() : base()
    {
    }

    public ServiceNotFoundException(string message) : base(message)
    {
    }
}
