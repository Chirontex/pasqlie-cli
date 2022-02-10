using Pasqliecli.Backend.Dto;
using Pasqliecli.Backend.Exception;

namespace Pasqliecli.Backend.Factory;

public class ConnectionDtoFactory
{
    public ConnectionDto createConnectionDto(string[] args)
    {
        string errorMessage = args.Length == 4 ? "" : (
            args.Length > 4 ?
                "Некорректные данные для подключения к БД - переданы лишние аргументы." :
                "Не указаны необходимые данные для подключения к БД."
            );

        if (errorMessage != "")
        {
            throw new InvalidArgsNumberException(errorMessage);
        }

        return new ConnectionDto(
            args[0],
            args[1],
            args[2],
            args[3]
        );
    }
}
