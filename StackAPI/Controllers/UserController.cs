using DTOs.UserD;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StackAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
}
    //public async Task<IActionResult> Register(RegisterUserDto dto)
    //{
    //    var result = await _userService.RegisterUserAsync(dto, "User");
    //    if (result.IsSuccesed)
    //    {
    //        return Ok("User Created!");
    //    }

    //    return BadRequest(result.ErrorMessage);
    //}
