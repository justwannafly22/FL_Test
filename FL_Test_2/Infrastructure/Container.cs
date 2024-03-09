using FL_Test_2.Repository;
using FL_Test_2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FL_Test_2.Infrastructure;

public sealed class Container
{
    private static Container? _instance = null;
    private readonly IServiceProvider _serviceProvider;

    private Container()
    {
        _serviceProvider = new ServiceCollection()
            .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"))
            .AddScoped<IUserRepository, UserRepository>()
            .BuildServiceProvider();
    }

    // ToDo: think about implementation via Lazy.
    public static Container ServiceContainer
    {
        get
        {
            _instance ??= new Container();

            return _instance;
        }
    }

    public IServiceProvider Services { get { return _serviceProvider; } }
}
