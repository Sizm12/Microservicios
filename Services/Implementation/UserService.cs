using System.Data.Common;
using ExampleDocker.Data;
using ExampleDocker.Interface;
using ExampleDocker.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ExampleDocker.Implementation;

public class UserService : IUserService
{
    private readonly ExampleDbContext _DbContext;
    public UserService(ExampleDbContext DbContext)
    {
        _DbContext = DbContext;
    }
    public async Task<UserEntities> Create(UserEntities user)
    {
        _DbContext.Users.Add(user);
        await _DbContext.SaveChangesAsync();
        return user;
    }

    public async Task<bool> Delete(int id)
    {
        var user = await _DbContext.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }
        _DbContext.Users.Remove(user);
        await _DbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<UserEntities>> GetAll()
    {
        return await _DbContext.Users.ToListAsync();
    }

    public async Task<UserEntities> GetById(int id)
    {
        var user = await _DbContext.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }
        return user;
    }

    public async Task<UserEntities> Update(UserEntities userEntities)
    {
        var user = await _DbContext.Users.FindAsync(userEntities.Id);
        if (user == null)
        {
            return null;
        }

        user.Name = userEntities.Name;
        user.Email = userEntities.Email;
        _DbContext.Users.Update(user);
        await _DbContext.SaveChangesAsync();
        return user;
    }
}
