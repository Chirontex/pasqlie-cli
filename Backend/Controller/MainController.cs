using Npgsql;
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

    public View GetDatabasesList()
    {
        NpgsqlDataReader result = this._connectionService
            .RequestDatabasesList();

        // TODO: форматирование дата ридера в объект фронта

        return new View();
    }
}
