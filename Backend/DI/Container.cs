using Npgsql;
using Pasqliecli.Backend.Exception.DI;
using Pasqliecli.Backend.Service;
using System.Collections.Generic;
using System;

namespace Pasqliecli.Backend.DI;

public class Container
{
    public static Container? Instance;

    protected Dictionary<string, dynamic> _services;

    protected Container(Dictionary<string, dynamic> services)
    {
        this._services = services;
    }

    public dynamic GetService(string id)
    {
        foreach (var service in this._services)
        {
            if (service.Key == id
                || Type.GetType(service.Value) == id)
            {
                return service;
            }
        }

        throw new ServiceNotFoundException($"Service {id} not found.");
    }

    public static Container GetInstance()
    {
        if (Container.Instance != null)
        {
            return Container.Instance;
        }

        return Container.Instance = new Container(
            Container._createServicesList()
        );
    }

    protected static Dictionary<string, dynamic> _createServicesList()
    {
        Dictionary<string, dynamic> servicesList = new Dictionary<string, dynamic>()
        {
            ["basic_connection"] = new NpgsqlConnection(),
        };

        servicesList.Add(
            "connection_service",
            new ConnectionService(servicesList["basic_connection"])
        );

        return servicesList;
    }
}
