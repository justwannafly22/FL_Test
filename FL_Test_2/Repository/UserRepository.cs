using FL_Test_2.Repository.Entities;
using FL_Test_2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FL_Test_2.Repository;

public class UserRepository (AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<User>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
}
