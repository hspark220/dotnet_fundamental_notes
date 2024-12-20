# dotnet_fundamental_notes
Some notes from reading .NET fundamentals documentation at https://learn.microsoft.com/en-us/dotnet/fundamentals/

## Table of Contents
- [Day 1](#day-1)



## Day 1
- Learning Markdown to write better documentation
- Hostbuilder [HostBuilder (generic host)](#hostbuilder-generic-host) the base of the app for hosting and running the app
- Have something running by the end of the day

## HostBuilder (generic host)
Using Microsoft.Extension.Hosting NuGet package to create a generic host that is responsible for app startup and lifetime management. A host is an object that encapsulates an app's resource and lifetime functionality, such as:

- Dependency Injection (DI)
- Logging
- Configuration
- App shutdown
- IHostedService implementation

### IHostApplicationBuilder and IHost
```c#
IHostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
IHost host = builder.Build()
```
- Calls a CreateApplicationBUilder method to create and configure a builder object
- Calls `Build()` to create an `IHost` instance
- Calls `Run()` or `RunAsync()` method on the host object--`Run()` calls the `RunAsync()`