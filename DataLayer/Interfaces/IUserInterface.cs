using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces;

public interface IUserInterface
{
    Task<IEnumerable<User>> GetAllAsync();

    Task<User?> GetByIdAsync(string id);

    Task AddAsync(User user);

    Task UpdateAsync(User user);

    Task DeleteAsync(User user);
}
