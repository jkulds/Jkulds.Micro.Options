using Jkulds.Micro.Options.Base;
using Jkulds.Micro.Options.Helpers;

namespace Jkulds.Micro.Options.Postgres;

public class PostgresOptions : BaseOption
{
    public string Server { get; set; } = string.Empty;
    public string ContainerHostName { get; set; } = string.Empty;
    public long Port { get; set; }
    public string DbName { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string GetConnectionString()
    {
        var host = Server;
        if (EnvironmentHelper.IsDockerRunning())
        {
            host = ContainerHostName;
        }
        
        return $"Server={host};Port={Port};Database={DbName};UserId={UserId};Password={Password}";
    }
}