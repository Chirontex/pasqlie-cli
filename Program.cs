using Garner;
using Pasqliecli.Backend.Controller;
using Pasqliecli.Backend.Dto;
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

        ConnectionDtoFactory connectionDtoFactory = container.Get(
            ClassNameHelper.GetClassName(typeof(ConnectionDtoFactory))
        );

        ConnectionDto connectionDto = connectionDtoFactory
            .createConnectionDto(args);

        Console.WriteLine(connectionDto.Host);
        Console.WriteLine(connectionDto.Username);
        Console.WriteLine(connectionDto.Password);
        Console.WriteLine(connectionDto.Database);
    }
}
