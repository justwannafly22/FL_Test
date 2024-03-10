using FL_Test_2.Repository.Entities;

namespace FL_Test_2.Repository.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> GetAllAsync();
    public Task<User> GetByUserIdAndDomainAsync(Guid userId, string domain);
    public Task<List<User>> GetAllByDomainAsync(int position, string domain);
    public Task<List<User>> GetAllByTagValueAndDomainAsync(string tagValue, string domain);
}
