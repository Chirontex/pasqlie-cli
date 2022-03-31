using Garner;
using Pasqliecli.Backend.Controller;
using Pasqliecli.Backend.Exception;
using Pasqliecli.Backend.Factory;
using Pasqliecli.Backend.Helper;
using Pasqliecli.Backend.Service;
using Pasqliecli.Frontend.Dto;
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

        ConnectionService connectionService = container.Get(
            ClassNameHelper.GetClassName(typeof(ConnectionService))
        );

        ConnectionDtoFactory connectionDtoFactory = container.Get(
            ClassNameHelper.GetClassName(typeof(ConnectionDtoFactory))
        );

        try
        {
            connectionService.CreateConnection(
                connectionDtoFactory.createConnectionDto(args)
            );

            // TODO: Добавить логику взаимодействия с пользователем
            mainController.GetDatabasesList().OutputContent();
        }
        catch (BasicException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
