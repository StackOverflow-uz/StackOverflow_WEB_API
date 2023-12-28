using DTOs.UserD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;

public class UserService : IUserService
{
    public Task Add(AddUserDto addUserDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<UserDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateUserDto updateUserDto)
    {
        throw new NotImplementedException();
    }
}
