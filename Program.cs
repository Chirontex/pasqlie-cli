using Garner;
using Pasqliecli.Backend.Factory;
using Pasqliecli.Backend.Helper;
using Pasqliecli.Backend.Service;
using System;

namespace Pasqliecli;

class Program
{
    public static void Main(string[] args)
    {
        Container.ServicesDictionaryFactory = new ServicesDictionaryFactory();
        Container container = Container.GetInstance();

        ConnectionService connectionService = container.Get(
            ClassNameHelper.GetClassName(typeof(ConnectionService))
        );

        Console.WriteLine(connectionService.ToString());
    }
}
