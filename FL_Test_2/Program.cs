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
    Console.WriteLine();

    #region First Task
    Console.WriteLine("Choose the user with UserId and Domain.");

    Console.WriteLine("Please, enter the UserId.");
    var userId = new Guid(Console.ReadLine()!);

    Console.WriteLine("Please, enter the Domain.");
    var domain = Console.ReadLine()!;

    _ = await userBusinessLogic!.GetByUserIdAndDomainAsync(userId, domain);
    #endregion

    #region Second Task
    Console.WriteLine("Choose users by User Domain.");

    Console.WriteLine("Please, enter the Domain.");
    domain = Console.ReadLine()!;

    Console.WriteLine();
    Console.WriteLine("Getting first five elements:");
    _ = await userBusinessLogic!.GetAllByDomainAsync(position: 0, domain);
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
