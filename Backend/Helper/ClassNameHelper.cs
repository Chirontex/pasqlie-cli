using System;

namespace Pasqliecli.Backend.Helper;

public class ClassNameHelper
{
    public static string GetClassName(Type type)
    {
        return type.FullName == null ? type.Name : type.FullName;
    }
}
