using Pasqliecli.Backend.Dto;
using Pasqliecli.Backend.Service;
using Pasqliecli.Frontend.Dto;

namespace Pasqliecli.Backend.Controller;

public class MainController
{
    protected ConnectionService _connectionService;

    public MainController(ConnectionService connectionService)
    {
        this._connectionService = connectionService;
    }

    public View Connect(ConnectionDto connection)
    {
        // TODO: использование сервиса для подключения к БД

        return new View();
    }
}
