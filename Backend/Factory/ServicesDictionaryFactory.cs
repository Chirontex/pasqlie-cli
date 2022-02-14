using Garner.Interfaces;
using Npgsql;
using Pasqliecli.Backend.Controller;
using Pasqliecli.Backend.Helper;
using Pasqliecli.Backend.Service;
using Pasqliecli.Frontend.Factory;
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
            .AddViewFactory(in dictionary)
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
                dictionary[ClassNameHelper.GetClassName(typeof(ConnectionService))],
                dictionary[ClassNameHelper.GetClassName(typeof(ViewFactory))]
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

    protected ServicesDictionaryFactory AddViewFactory(
        in Dictionary<string, dynamic> dictionary
    ) {
        dictionary.Add(
            ClassNameHelper.GetClassName(typeof(ViewFactory)),
            new ViewFactory()
        );

        return this;
    }
}
