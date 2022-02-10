using Pasqliecli.Backend.Dto;

namespace Pasqliecli.Backend.Factory;

public class ConnectionDtoFactory
{
    public ConnectionDto createConnectionDto(string[] args)
    {
        return new ConnectionDto(
            args[0],
            args[1],
            args[2],
            args[3]
        );
    }
}
