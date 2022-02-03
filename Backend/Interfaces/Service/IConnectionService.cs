using Npgsql;
using Pasqliecli.Backend.Dto;
using Pasqliecli.Backend.Service;

namespace Pasqliecli.Backend.Interfaces.Service;

public interface IConnectionService
{
    public ConnectionService CreateConnection(in ConnectionDto connectionDto);

    /* <exception>NullConnectionException</exception> */
    public NpgsqlDataReader RequestDatabasesList();

    /* <exception>NullConnectionException</exception> */
    public NpgsqlDataReader? Execute(in string query, out string? errorMessage);

    /* <exception>NullConnectionException</exception> */
    public string? Execute(in string query, out NpgsqlDataReader? result);

    /* <exception>NullConnectionException</exception> */
    public ConnectionService Execute(
        in string query,
        out string? errorMessage,
        out NpgsqlDataReader? result
    );
}
