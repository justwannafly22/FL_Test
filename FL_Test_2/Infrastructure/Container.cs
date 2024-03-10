using FL_Test_2.Repository;
using FL_Test_2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FL_Test_2.Infrastructure;

public sealed class Container
{
    private static readonly Lazy<Container?> _instance = new(() => new Container());
    private readonly IServiceProvider _serviceProvider;

    private Container()
    {
        _serviceProvider = new ServiceCollection()
            .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"))
            .AddScoped<IUserRepository, UserRepository>()
            .BuildServiceProvider();
    }

    public static Container ServiceContainer => _instance.Value!;

    public IServiceProvider Services { get { return _serviceProvider; } }
}
