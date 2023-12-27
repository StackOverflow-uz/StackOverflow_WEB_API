using DTOs.AnswerD;
using DTOs.UserD;
using LogicLayer.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAll();
    Task<PagedList<UserDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<UserDto> GetById(int id);
    Task Add(AddUserDto addCategoryDto);
    Task Delete(int id);
    Task Update(UpdateUserDto updateCategoryDto);
}
