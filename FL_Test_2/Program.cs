using FL_Test_2.Infrastructure;
using FL_Test_2.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var container = Container.ServiceContainer;
    var serviceProvider = container.Services;

    var userRepository = serviceProvider.GetService<IUserRepository>();
    var users = await userRepository!.GetUsersAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
