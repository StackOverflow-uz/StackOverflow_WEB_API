using DTOs.UserD;
using LogicLayer.Extended;

namespace LogicLayer.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAll();
    Task<PagedList<UserDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<UserDto> GetById(int id);
    Task Add(AddUserDto addUserDto);
    Task Delete(int id);
    Task Update(UpdateUserDto updateUserDto);
}
