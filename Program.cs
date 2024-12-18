using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

IHost app = builder.Build();

await app.RunAsync();