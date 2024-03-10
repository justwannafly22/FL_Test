using FL_Test_2.Infrastructure.Logic.Interfaces;
using FL_Test_2.Repository.Entities;
using FL_Test_2.Repository.Interfaces;
using System.Net.NetworkInformation;

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
        ArgumentException.ThrowIfNullOrEmpty(userId.ToString(), nameof(domain));
        ArgumentException.ThrowIfNullOrEmpty(domain, nameof(domain));
        await Console.Out.WriteLineAsync($"Getting user by provided UserId: {userId} and Domain: {domain}");

        var user = await _userRepository.GetByUserIdAndDomainAsync(userId, domain);
        ShowUser(user);

        return user;
    }

    public async Task<List<User>> GetAllByDomainAsync(int position, string domain)
    {
        ArgumentException.ThrowIfNullOrEmpty(domain, nameof(domain));
        await Console.Out.WriteLineAsync($"Getting users by provided Domain: {domain}");

        var users = await _userRepository.GetAllByDomainAsync(position, domain);
        users.ForEach(ShowUser);

        return users;
    }

    private static void ShowUser(User user)
    {
        Console.WriteLine(user);
        Console.WriteLine($"User tags:");
        user.TagToUsers!
            .Select(t => t.Tag!)
            .ToList()
            .ForEach(Console.WriteLine);

        Console.WriteLine();
    }
}
