using Npgsql;
using Pasqliecli.Backend.Dto;

namespace Pasqliecli.Backend.Service;

public class ConnectionService
{
    private NpgsqlConnection? _connection;

    public void CreateConnection(ConnectionDto connectionDto)
    {
        this._connection = new NpgsqlConnection(
            $"Host={connectionDto.Host};Username={connectionDto.Username};Password={connectionDto.Password};Database={connectionDto.Database}"
        );
        this._connection.Open();

        // TODO: добавить отлов исключений и возврат списка баз данных
    }
}
