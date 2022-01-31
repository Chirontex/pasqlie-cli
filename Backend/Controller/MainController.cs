using Pasqliecli.Backend.Dto;
using Pasqliecli.Frontend.Dto;

namespace Pasqliecli.Backend.Controller;

public class MainController
{
    public View Connect(ConnectionDto connection)
    {
        // TODO: использование сервиса для подключения к БД

        return new View();
    }
}
