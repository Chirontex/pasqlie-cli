using Npgsql;
using Pasqliecli.Backend.Exception.DI;
using Pasqliecli.Backend.Service;
using System.Collections.Generic;

namespace Pasqliecli.Backend.DI;

public class Container
{
    protected static Container? _instance;

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
                || service.Value.GetType().ToString() == id)
            {
                return service.Value;
            }
        }

        throw new ServiceNotFoundException($"Service {id} not found.");
    }

    public static Container GetInstance()
    {
        if (Container._instance != null)
        {
            return Container._instance;
        }

        return Container._instance = new Container(
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
