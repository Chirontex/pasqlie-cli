namespace Pasqliecli.Backend.Exception;

public class InvalidArgsNumberException : BasicException
{
    public InvalidArgsNumberException() : base()
    {
    }

    public InvalidArgsNumberException(string message) : base(message)
    {
    }
}
