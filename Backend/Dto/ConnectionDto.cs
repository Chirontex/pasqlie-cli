namespace Pasqliecli.Backend.Dto;

public class ConnectionDto
{
    public string Host { get; }
    public string Username { get; }
    public string Password { get; }
    public string Database { get; }

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
