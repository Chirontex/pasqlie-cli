namespace Pasqliecli.Backend.Dto;

public class ConnectionDto
{
    string Host { get; }
    string Username { get; }
    string Password { get; }
    string Database { get; }

    public ConnectionDto(
        in string host,
        in string username,
        in string password,
        in string database
    )
    {
        this.Host = host;
        this.Username = username;
        this.Password = password;
        this.Database = database;
    }
}
