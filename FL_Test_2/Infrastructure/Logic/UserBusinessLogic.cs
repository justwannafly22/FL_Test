using FL_Test_2.Infrastructure.Logic.Interfaces;
using FL_Test_2.Repository.Entities;
using FL_Test_2.Repository.Interfaces;
using Serilog;

namespace FL_Test_2.Infrastructure.Logic;

public class UserBusinessLogic (IUserRepository userRepository) : IUserBusinessLogic
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<List<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetByUserIdAndDomainAsync(Guid userId, string domain)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(userId), nameof(domain));
        await Console.Out.WriteLineAsync($"Getting user by provided UserId: {userId} and Domain: {domain}");

        var user = await _userRepository.GetUserByUserIdAndDomainAsync(userId, domain);
        Console.WriteLine($"User tags:");
        user.TagToUsers!
            .Select(t => t.Tag!)
            .ToList()
            .ForEach(Console.WriteLine);

        return user;
    }
}
