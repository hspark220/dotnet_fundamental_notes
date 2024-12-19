# dotnet_fundamental_notes
Some notes from reading .NET fundamentals documentation at https://learn.microsoft.com/en-us/dotnet/fundamentals/

## Table of Contents
- [Day 1](#day-1)
- [Day 2](#day-2)



## Day 1
- Learning Markdown to write better documentation
- Hostbuilder [HostBuilder (generic host)](#hostbuilder-generic-host) the base of the app for hosting and running the app
- Have something running by the end of the day

### HostBuilder (generic host)
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

## Day 2
- Fortmat overview?
- Running a console app through generic host

### Format numbers, dates, other types
Main purpose is to change different data types into string using the `Object.ToString()` method--which can also be overridden to return different results. Another reason would be to conver the datatype into different types of string for different data standards, eg. representing a number in binary or hexadecimal.

### Console App via generic host
After going through multiple resources and reading through a couple of blogs, I found this [article](https://codingfreaks.de/consoleapp-01/) to be the most straight forward,,, there still some questions left unanswered but at least I can run a basic console app, use Dependency Injection and do some basic logging.
One question I still how I can run the app using `await app.RunAsync();` instead of `await app.Services.GetRequiredService<SomeService>().StartAsync();`
