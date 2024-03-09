using FL_Test_2.Repository.Entities;

namespace FL_Test_2.Repository.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> GetUsersAsync();
}
