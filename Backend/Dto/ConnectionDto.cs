namespace Pasqliecli.Backend.Dto;

public class ConnectionDto
{
    public string Host { get; init; }
    public string Username { get; init; }
    public string Password { get; init; }
    public string Database { get; init; }

    public ConnectionDto(
        string host,
        string username,
        string password,
        string database
    ) {
        this.Host = host;
        this.Username = username;
        this.Password = password;
        this.Database = database;
    }
}
