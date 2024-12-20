using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Program
{
    public static async Task Main(String[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        IHost app = builder.Build();

        await app.RunAsync();
    }
}
