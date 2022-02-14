using Npgsql;
using Pasqliecli.Frontend.Dto;
using System.Collections.Generic;

namespace Pasqliecli.Frontend.Factory;

public class ViewFactory
{
    public View CreateViewFromDataReader(NpgsqlDataReader dataReader)
    {
        List<List<string>> data = new();

        while (dataReader.Read())
        {
            List<string> row = new();

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                row.Add(dataReader.GetString(i));
            }

            data.Add(row);
        }

        return new View(data);
    }
}
