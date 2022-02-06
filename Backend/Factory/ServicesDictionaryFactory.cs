using Garner.Interfaces;
using Npgsql;
using Pasqliecli.Backend.Helper;
using Pasqliecli.Backend.Service;
using System.Collections.Generic;

namespace Pasqliecli.Backend.Factory;

public class ServicesDictionaryFactory : IServicesDictionaryFactory
{
    public const string BASIC_CONNECTION = "basic_connection";

    public Dictionary<string, dynamic> createServicesDictionary()
    {
        var dictionary = new Dictionary<string, dynamic>()
        {
            [ClassNameHelper.GetClassName(typeof(NpgsqlConnection))] = new NpgsqlConnection(),
        };

        this.AddConnectionService(in dictionary);

        return dictionary;
    }

    protected ServicesDictionaryFactory AddConnectionService(
        in Dictionary<string, dynamic> dictionary
    ) {
        dictionary.Add(
            ClassNameHelper.GetClassName(typeof(ConnectionService)),
            new ConnectionService(
                dictionary[ClassNameHelper.GetClassName(typeof(NpgsqlConnection))]
            )
        );

        return this;
    }
}
