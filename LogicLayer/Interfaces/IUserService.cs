using DTOs.UserD;
using LogicLayer.Extended;

namespace LogicLayer.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAll();
    Task<PagedList<UserDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<UserDto> GetById(Guid id);
    Task Add(AddUserDto addUserDto);
    Task Delete(Guid id);
    Task Update(UpdateUserDto updateUserDto);
}
