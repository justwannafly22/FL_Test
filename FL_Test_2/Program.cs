using FL_Test_2.Infrastructure;
using FL_Test_2.Infrastructure.Logic;
using FL_Test_2.Infrastructure.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;
using System.Runtime.CompilerServices;

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

    // For single running.
    // await FirstTask(userBusinessLogic);
    // await SecondTask(userBusinessLogic);
    // await ThirdTask(userBusinessLogic);

    // For running all tasks.
    await Task.WhenAll(FirstTask(userBusinessLogic), SecondTask(userBusinessLogic), ThirdTask(userBusinessLogic));
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

static async Task FirstTask(IUserBusinessLogic userBusinessLogic)
{
    Console.WriteLine("Choose the user with UserId and Domain.");

    Console.WriteLine("Please, enter the UserId.");
    var userId = new Guid(Console.ReadLine()!);

    Console.WriteLine("Please, enter the Domain.");
    var domain = Console.ReadLine()!;

    _ = await userBusinessLogic!.GetByUserIdAndDomainAsync(userId, domain);
}

static async Task SecondTask(IUserBusinessLogic userBusinessLogic)
{
    Console.WriteLine("Choose users by User Domain.");

    Console.WriteLine("Please, enter the Domain.");
    var domain = Console.ReadLine()!;

    Console.WriteLine();
    Console.WriteLine("Getting first five elements:");
    _ = await userBusinessLogic!.GetAllByDomainAsync(position: 0, domain);
}

static async Task ThirdTask(IUserBusinessLogic userBusinessLogic)
{
    Console.WriteLine("Choose users by Tag and Domain.");

    Console.WriteLine("Please, enter the Domain.");
    var domain = Console.ReadLine()!;

    Console.WriteLine("Please, enter the Tag Value.");
    var tagValue = Console.ReadLine()!;

    Console.WriteLine();
    _ = await userBusinessLogic!.GetAllByTagValueAndDomainAsync(tagValue, domain);
}
