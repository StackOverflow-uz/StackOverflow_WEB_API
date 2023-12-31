using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DTOs.UserD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;

public class UserService(IUnitOfWorkInterface unitOfWork,
                         IMapper mapper) : IUserService
{
    private readonly IUnitOfWorkInterface _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task Add(AddUserDto addUserDto)
    {
        if (addUserDto == null)
            throw new ArgumentNullException("User null bo'lib qoldi!");
        
        var users = await _unitOfWork.UserInterface.GetAllAsync();
        var user = _mapper.Map<User>(addUserDto);
        if (!user.IsValid())
            throw new StackException("Invalid User"); 

        if (user.IsExist(users))
            throw new StackException($"{user} uje bor!");
        
        await _unitOfWork.UserInterface.AddAsync(user);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        var user = await _unitOfWork.UserInterface.GetByIdAsync(id);
        if (user == null)
        {
            throw new ArgumentNullException("Bunday User mavjud emas");
        }
        await _unitOfWork.UserInterface.DeleteAsync(user);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<UserDto>> GetAll()
    {
        var users = await _unitOfWork.UserInterface.GetAllAsync();
        return users.Select(c => _mapper.Map<UserDto>(c)).ToList();
    }

    public async Task<PagedList<UserDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        var list = await _unitOfWork.UserInterface.GetAllAsync();
        var dtos = list.Select(c => _mapper.Map<UserDto>(c))
                                   .ToList();

        PagedList<UserDto> pagedList = new PagedList<UserDto>(dtos, 
                                                              dtos.Count(), 
                                                              pageSize, 
                                                              pageNumber);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task<UserDto> GetById(Guid id)
    {
        var user = await _unitOfWork.UserInterface.GetByIdAsync(id);

        if (user == null)
        {
            throw new ArgumentNullException("Bunday User mavjud emas");
        }
        return _mapper.Map<UserDto>(user);
    }

    public async Task Update(UpdateUserDto updateUserDto)
    {
        var user = await _unitOfWork.UserInterface.GetByIdAsync(updateUserDto.Id);
        var updateUser = _mapper.Map<User>(user);
        if (updateUserDto == null)
            throw new ArgumentNullException("UserDto is null here!");
        if (user == null)
            throw new ArgumentNullException("User is null here!");

        await _unitOfWork.UserInterface.UpdateAsync(updateUser);
        await _unitOfWork.SaveAsync();
    }
}
