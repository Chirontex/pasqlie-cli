using Npgsql;
using Pasqliecli.Backend.Dto;
using Pasqliecli.Backend.Interfaces.Service;
using System;

namespace Pasqliecli.Backend.Service;

public class ConnectionService : IConnectionService
{
    protected NpgsqlConnection _connection;

    public ConnectionService(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public void ConnectionOpen()
    {
        this._connection.Open();
    }

    public void ConnectionClose()
    {
        this._connection.Close();
    }

    public ConnectionService CreateConnection(in ConnectionDto connectionDto)
    {
        this._connection.ConnectionString = $"Host={connectionDto.Host};Username={connectionDto.Username};Password={connectionDto.Password};Database={connectionDto.Database}";

        return this;
    }

    public NpgsqlDataReader RequestDatabasesList()
    {
        var result = (new NpgsqlCommand(
            "SELECT t.datname FROM pg_database AS t",
            this._connection
        )).ExecuteReader();

        return result;
    }

    public NpgsqlDataReader? Execute(in string query, out string? errorMessage)
    {
        try
        {
            var result = (new NpgsqlCommand(query, this._connection))
                .ExecuteReader();
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
}
