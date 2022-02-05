using Pasqliecli.Backend.DI;
using Pasqliecli.Backend.Service;
using System;

namespace Pasqliecli;

class Program
{
    public static void Main(string[] args)
    {
        var container = Container.GetInstance();
        ConnectionService connectionService = container
            .GetService(typeof(ConnectionService).FullName);

        Console.WriteLine(connectionService.ToString());
    }
}
