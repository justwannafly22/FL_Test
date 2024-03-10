using FL_Test_2.Infrastructure;
using FL_Test_2.Infrastructure.Logic.Interfaces;
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
    var userBusinessLogic = serviceProvider.GetService<IUserBusinessLogic>();

    var users = await userBusinessLogic!.GetAllAsync();
    users.ForEach(Console.WriteLine);

    #region First Task
    Console.WriteLine("Choouse the user with UserId and Domain.");

    Console.WriteLine("Please, enter the UserId.");
    var userId = new Guid(Console.ReadLine()!);

    Console.WriteLine("Please, enter the Domain.");
    var domain = Console.ReadLine()!;

    _ = await userBusinessLogic!.GetByUserIdAndDomainAsync(userId, domain);
    #endregion
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
