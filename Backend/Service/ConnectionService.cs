using Npgsql;
using Pasqliecli.Backend.Dto;
using Pasqliecli.Backend.Exception;

namespace Pasqliecli.Backend.Service;

public class ConnectionService
{
    protected NpgsqlConnection? _connection;

    public ConnectionService CreateConnection(in ConnectionDto connectionDto)
    {
        this._connection = new NpgsqlConnection(
            $"Host={connectionDto.Host};Username={connectionDto.Username};Password={connectionDto.Password};Database={connectionDto.Database}"
        );

        return this;
    }

    //<exception>NullConnectionException</exception>
    public NpgsqlDataReader RequestDatabasesList()
    {
        this._checkConnection()._connection.Open();

        var result = (new NpgsqlCommand(
            "SELECT dataname FROM pg_database",
            this._connection
        )).ExecuteReader();

        this._connection.Close();

        return result;
    }

    protected ConnectionService _checkConnection()
    {
        if (this._connection == null)
        {
            throw new NullConnectionException("Соединение не было создано.");
        }

        return this;
    }
}
