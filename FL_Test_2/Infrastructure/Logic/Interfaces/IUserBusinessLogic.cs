﻿using FL_Test_2.Repository.Entities;

namespace FL_Test_2.Infrastructure.Logic.Interfaces;

public interface IUserBusinessLogic
{
    public Task<List<User>> GetAllAsync();
    public Task<User> GetByUserIdAndDomainAsync(Guid userId, string domain);
}
