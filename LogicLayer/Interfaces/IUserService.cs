using DTOs.UserD;

namespace LogicLayer.Interfaces;

public interface IUserService
{
    Task RegisterAsync(RegisterUserDto dto);
    Task<LoginResultDto> LoginAsync(LoginUserDto dto);
}
