using ExampleDocker.Models;

namespace ExampleDocker.Interface;

public interface IUserService
{
    public Task<UserEntities> Create(UserEntities user);
    public Task<UserEntities> Update(UserEntities userEntities);
    public Task<List<UserEntities>> GetAll();
    public Task<UserEntities> GetById(int id);
    public Task<bool> Delete(int id);
}
