using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestProgram;

// See https://aka.ms/new-console-template for more information
var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var configuration = builder.Build();


var serviceProvider = new ServiceCollection()
    .RegisterApplicationContext(configuration.GetConnectionString("Postgres"))
    .RegisterRepositories()
    .RegisterServices()
    .AddSingleton<IConsoleApplication, ConsoleApplication>()
    .BuildServiceProvider();


IServiceScope scope = serviceProvider.CreateScope();
scope.ServiceProvider.GetRequiredService<IConsoleApplication>().Run();

if (serviceProvider is IDisposable)
{
    serviceProvider.Dispose();
}
