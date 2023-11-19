using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

/// <inheritdoc />
internal class UserRepository : IUserRepository
{
    private readonly ApplicationEfContext _efContext;

    public UserRepository(ApplicationEfContext efContext)
    {
        _efContext = efContext;
    }
    
    public async Task<User?> GetById(long userId)
    {
        return await _efContext.Users.FindAsync(userId);
    }

    public async Task<User?> GetByName(string userName)
    {
        return await _efContext.Users.FirstOrDefaultAsync(user => user.Name == userName);
    }

    public async Task<IReadOnlyList<User>> SearchByName(string searchTerm)
    {
        return (await _efContext.Users
            .Where(user => EF.Functions.Like(user.Name, $"%{searchTerm}%"))
            .AsNoTracking()
            .ToListAsync())
            .AsReadOnly();
    }

    public async Task<long> AddUser(User user)
    {
        var entry = await _efContext.Users.AddAsync(user);
        await _efContext.SaveChangesAsync();

        return entry.Entity.Id;
    }

    public async Task UpdateUser(User user)
    {
        _efContext.Update(user);
        await _efContext.SaveChangesAsync();
    }
}