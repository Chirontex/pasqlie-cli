using Pasqliecli.Backend.Service;
using Pasqliecli.Frontend.Dto;
using Pasqliecli.Frontend.Factory;

namespace Pasqliecli.Backend.Controller;

public class MainController
{
    protected ConnectionService _connectionService;
    protected ViewFactory _viewFactory;

    public MainController(
        ConnectionService connectionService,
        ViewFactory viewFactory
    ) {
        this._connectionService = connectionService;
        this._viewFactory = viewFactory;
    }

    public View GetDatabasesList()
    {
        this._connectionService.ConnectionOpen();

        View result = this._viewFactory.CreateViewFromDataReader(
            this._connectionService.RequestDatabasesList()
        );

        this._connectionService.ConnectionClose();

        return result;
    }
}
