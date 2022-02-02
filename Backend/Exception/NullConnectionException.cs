using System;

namespace Pasqliecli.Backend.Exception;

public class NullConnectionException : BasicException
{
    public NullConnectionException() : base ()
    {
    }

    public NullConnectionException(string message) : base (message)
    {
    }
}
