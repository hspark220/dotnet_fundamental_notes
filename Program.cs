using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<SomeService>();
builder.Services.AddTransient<IMyLogic, MyLogic>();

IHost app = builder.Build();

// Can run by running app or just run a service??
await app.Services.GetRequiredService<SomeService>().StartAsync();

//await app.RunAsync();

// Background Service
public class PrintService : BackgroundService
{
    private readonly ILogger _logger;
    public PrintService(ILogger<PrintService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Hello from the printing service!");
            await Task.Delay(1000, stoppingToken);
        }
    }
}

// Running sample app
class SomeService
{
    private IHostEnvironment _env;
    private ILogger<SomeService> _logger;
    private IConfiguration _config;
    private IMyLogic _logic;
    public SomeService(IHostEnvironment env, ILogger<SomeService> logger, IConfiguration config, IMyLogic logic)
    {
        _env = env;
        _logger = logger;
        _config = config;
        _logic = logic;
        
    }
    public Task StartAsync()
    {
        _logger.LogInformation($"{_env.ContentRootFileProvider}");
        _logger.LogInformation($"Value1 : {_config["App:Value1"]} ,,, Value2 : {_config["App:Value2"]}");
        _logic.Say("Hello World!");
        return Task.CompletedTask;
    }
}

// Sample DI and Logger
public interface IMyLogic
{
    void Say(string message);
}

public class MyLogic : IMyLogic
{
    public void Say(string message)
    {
        Console.WriteLine(message);
    }
}