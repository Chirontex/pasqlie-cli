using Npgsql;
using Pasqliecli.Backend.Dto;
using Pasqliecli.Backend.Service;

namespace Pasqliecli.Backend.Interfaces.Service;

public interface IConnectionService
{
    public ConnectionService CreateConnection(in ConnectionDto connectionDto);

    public NpgsqlDataReader RequestDatabasesList();

    public NpgsqlDataReader? Execute(in string query, out string? errorMessage);

    public string? Execute(in string query, out NpgsqlDataReader? result);

    public ConnectionService Execute(
        in string query,
        out string? errorMessage,
        out NpgsqlDataReader? result
    );
}
