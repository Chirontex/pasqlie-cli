using Garner.Interfaces;
using Npgsql;
using Pasqliecli.Backend.Controller;
using Pasqliecli.Backend.Factory;
using Pasqliecli.Backend.Helper;
using Pasqliecli.Backend.Service;
using System.Collections.Generic;

namespace Pasqliecli.Backend.Factory;

public class ServicesDictionaryFactory : IServicesDictionaryFactory
{
    public Dictionary<string, dynamic> createServicesDictionary()
    {
        var dictionary = new Dictionary<string, dynamic>()
        {
            [ClassNameHelper.GetClassName(typeof(NpgsqlConnection))] = new NpgsqlConnection(),
        };

        this
            .AddConnectionService(in dictionary)
            .AddConnectionDtoFactory(in dictionary)
            .AddMainController(in dictionary);

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

    protected ServicesDictionaryFactory AddMainController(
        in Dictionary<string, dynamic> dictionary
    ) {
        dictionary.Add(
            ClassNameHelper.GetClassName(typeof(MainController)),
            new MainController(
                dictionary[ClassNameHelper.GetClassName(typeof(ConnectionService))]
            )
        );

        return this;
    }

    protected ServicesDictionaryFactory AddConnectionDtoFactory(
        in Dictionary<string, dynamic> dictionary
    ) {
        dictionary.Add(
            ClassNameHelper.GetClassName(typeof(ConnectionDtoFactory)),
            new ConnectionDtoFactory()
        );

        return this;
    }
}
