using Npgsql;
using Pasqliecli.Backend.Dto;
using Pasqliecli.Backend.Exception;
using Pasqliecli.Backend.Interfaces.Service;
using System;

namespace Pasqliecli.Backend.Service;

public class ConnectionService : IConnectionService
{
    protected NpgsqlConnection? _connection;

    public ConnectionService CreateConnection(in ConnectionDto connectionDto)
    {
        this._connection = new NpgsqlConnection(
            $"Host={connectionDto.Host};Username={connectionDto.Username};Password={connectionDto.Password};Database={connectionDto.Database}"
        );

        return this;
    }

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

    public NpgsqlDataReader? Execute(in string query, out string? errorMessage)
    {
        this._checkConnection()._connection.Open();

        try
        {
            var result = (new NpgsqlCommand(query, this._connection))
                .ExecuteReader();

            this._connection.Close();

            errorMessage = null;

            return result;
        }
        catch (SystemException e)
        {
            errorMessage = e.Message;

            return null;
        }
    }

    public string? Execute(in string query, out NpgsqlDataReader? result)
    {
        string? errorMessage;

        result = this.Execute(query, out errorMessage);

        return errorMessage;
    }

    public ConnectionService Execute(
        in string query,
        out string? errorMessage,
        out NpgsqlDataReader? result
    ) {
        errorMessage = this.Execute(query, out result);

        return this;
    }

    /* <exception>NullConnectionException</exception> */
    protected ConnectionService _checkConnection()
    {
        if (this._connection == null)
        {
            throw new NullConnectionException("Соединение не было создано.");
        }

        return this;
    }
}
