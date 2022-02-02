using System;

namespace Pasqliecli.Backend.Exception;

public class BasicException : SystemException
{
    public Int64 Code { get; } = 0;

    public BasicException() : base ()
    {
    }

    public BasicException(string message) : base (message)
    {
    }

    public BasicException(Int64 code)
    {
        this.Code = code;
    }

    public BasicException(string? message, Int64? code) : base (message)
    {
        if (code != null)
        {
            this.Code = (Int64)code;
        }
    }
}
