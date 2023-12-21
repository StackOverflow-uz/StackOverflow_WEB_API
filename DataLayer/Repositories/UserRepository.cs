using DataAccessLayer.DB;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.Repositories;

public class UserRepository(AppDbContext dbContext) : IUserInterface
{
    protected readonly AppDbContext _dbContext = dbContext;
    public async Task AddAsync(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateAsync(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        var existingEntity = await GetByIdAsync(user.Id);

        if (existingEntity == null)
        {
            throw new ArgumentException($"Entity with Id {user.Id} not found.", nameof(user));
        }

        _dbContext.Entry(existingEntity).CurrentValues.SetValues(user);
        await _dbContext.SaveChangesAsync();
    }
}
