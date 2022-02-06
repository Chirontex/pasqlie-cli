using Garner;
using Pasqliecli.Backend.Controller;
using Pasqliecli.Backend.Factory;
using Pasqliecli.Backend.Helper;
using System;

namespace Pasqliecli;

class Program
{
    public static void Main(string[] args)
    {
        Container.ServicesDictionaryFactory = new ServicesDictionaryFactory();
        Container container = Container.GetInstance();

        MainController mainController = container.Get(
            ClassNameHelper.GetClassName(typeof(MainController))
        );

        Console.WriteLine(mainController.ToString());
    }
}
