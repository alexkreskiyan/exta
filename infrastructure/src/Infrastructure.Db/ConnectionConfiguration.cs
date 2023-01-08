using Annium.linq2db.PostgreSql;

namespace Infrastructure.Db;

public class ConnectionConfiguration : IPostgreSqlConfiguration
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public string Database { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string ConnectionString => string.Join(';',
        $"Host={Host}",
        $"Port={Port}",
        $"Database={Database}",
        $"Username={User}",
        $"Password={Password}",
        "SSL Mode=Prefer",
        "Trust Server Certificate=true",
        "Tcp Keepalive=true"
    );
}