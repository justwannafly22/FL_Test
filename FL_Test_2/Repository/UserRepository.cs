using FL_Test_2.Repository.Entities;
using FL_Test_2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FL_Test_2.Repository;

public class UserRepository (AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByUserIdAndDomainAsync(Guid userId, string domain)
    {
        try
        {
            var user = await _context.Users
                .Include(t => t.TagToUsers!)
                .ThenInclude(t => t.Tag)
                .SingleOrDefaultAsync(t => t.UserId == userId && t.Domain == domain);

            if (user is not null)
            {
                Log.Information($"Retrieved user: {userId}");
                return user!;
            }
            else
            {
                throw new Exception($"User: {userId} doesn`t exist in the database.");
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Error occured during retrieving user: {userId}");
            throw;
        }
    }
}
