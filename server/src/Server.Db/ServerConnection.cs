using Annium.linq2db.Extensions.Models;
using Annium.Logging.Abstractions;
using Core.Domain.Models;
using LinqToDB;
using LinqToDB.Data;

namespace Server.Db;

public class ServerConnection : DataConnection, ILogSubject<ServerConnection>
{
    public ILogger<ServerConnection> Logger { get; }
    public ITable<User> Users { get; }

    public ServerConnection(
        Config<ServerConnection> config,
        ILogger<ServerConnection> logger
    ) : base(config.Options)
    {
        Logger = logger;
        Users = this.GetTable<User>();
    }
}
