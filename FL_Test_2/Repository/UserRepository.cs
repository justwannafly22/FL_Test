using FL_Test_2.Repository.Entities;
using FL_Test_2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace FL_Test_2.Repository;

public class UserRepository (AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<User>> GetAllAsync()
    {
        return await GetAllUsers()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User> GetByUserIdAndDomainAsync(Guid userId, string domain)
    {
        try
        {
            var user = await _context.Users
                .Include(t => t.TagToUsers!)
                    .ThenInclude(t => t.Tag)
                .AsNoTracking()
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

    public async Task<List<User>> GetAllByDomainAsync(int position, string domain)
    {
        var pageSize = 5;

        try
        {
            var users = await GetUsersByExpression(t => t.Domain == domain)
                .Include(t => t.TagToUsers!)
                    .ThenInclude(t => t.Tag)
                .AsNoTracking()
                .Skip(position * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return users;
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Error occured during retrieving users");
            throw;
        }
    }

    private IQueryable<User> GetAllUsers() =>
        _context.Set<User>();

    private IQueryable<User> GetUsersByExpression(Expression<Func<User, bool>> expression) =>
        _context.Set<User>()
                .Where(expression);
}
