using Horus.Infra.Database;

namespace Horus.Worker;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddDatabaseInfrastructure(builder.Configuration);

        builder.Services.AddHostedService<Worker>();

        var host = builder.Build();
        host.Run();
    }
}