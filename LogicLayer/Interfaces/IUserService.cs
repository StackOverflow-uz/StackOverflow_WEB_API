using DTOs.UserD;

namespace LogicLayer.Interfaces;

public interface IUserService
{
    Task RegisterAsync(RegisterUserDto dto);
    Task<LoginResultDto> LoginAsync(LoginUserDto dto);
    Task DeleteAccountAsync(LoginUserDto dto);
    Task LogoutAsync(LoginUserDto dto);
    Task ChangePasswordAsync(ChangePasswordDto dto);
    Task CreateAsync(RegisterUserDto dto, string role);
}
