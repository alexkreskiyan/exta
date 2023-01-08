using Annium.linq2db.Extensions.Models;
using Annium.Logging.Abstractions;
using Core.Domain.Models;
using LinqToDB;

namespace Server.Db;

public class ServerConnection : DataConnectionBase, ILogSubject<ServerConnection>
{
    public ILogger<ServerConnection> Logger { get; }
    public ITable<Account> Accounts { get; }

    public ServerConnection(
        Config<ServerConnection> config,
        ILogger<ServerConnection> logger
    ) : base(config.Options)
    {
        Logger = logger;
        Accounts = this.GetTable<Account>();
    }
}
