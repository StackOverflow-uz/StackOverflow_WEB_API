﻿using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DTOs.UserD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace LogicLayer.Services;

public class UserService(UserManager<User> userManager,
                         IConfiguration configuration) : IUserService
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;

    public async Task RegisterAsync(RegisterUserDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        var user = (User)dto;
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            throw new StackException("User creation failed! Check user details and try again.");
        }

        await _userManager.AddToRoleAsync(user, "User");
    }

    public async Task<LoginResultDto> LoginAsync(LoginUserDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        var user = await _userManager.FindByNameAsync(dto.PhoneNumber);
        if (user == null)
        {
            throw new StackException("User not found! Check user details and try again.");
        }

        var result = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!result)
        {
            throw new StackException("Password is incorrect!");
        }

        var roles = await _userManager.GetRolesAsync(user);
        string token = GenerateToken(user, roles);

        return new LoginResultDto()
        {
            Id = user.Id,
            PhoneNumber = user.PhoneNumber!,
            ExpireAt = DateTime.UtcNow.AddDays(1),
            FullName = user.FullName!,
            Token = token,
        };
    }

    private string GenerateToken(User user, IList<string> roles)
    {
        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];
        var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]!);
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.GivenName, user.FullName!),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber!),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            }),
            Issuer = issuer,
            Audience = audience,
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        foreach (var role in roles)
        {
            tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
        }

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task ChangePasswordAsync(ChangePasswordDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        var user = await _userManager.FindByNameAsync(dto.PhoneNumber);
        if (user is null)
        {
            throw new ArgumentNullException("User not found");
        }

        var resul = await _userManager.ChangePasswordAsync(user,
                                                      dto.OldPassword,
                                                      dto.NewPassword);
        if (!resul.Succeeded)
        {
            throw new StackException("Failed to change password");
        }
    }

    public async Task DeleteAccountAsync(LoginUserDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.PhoneNumber);
        if (user is null)
        {
            throw new ArgumentException("User not found");
        }

        await _userManager.RemoveAuthenticationTokenAsync(user, _configuration["Jwt:Issuer"] ?? "", "Token");
        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            throw new StackException("Failed to delete user");
        }
    }

    public async Task LogoutAsync(LoginUserDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.PhoneNumber);
        if (user is null)
        {
            throw new ArgumentNullException("User not found");
        }

        await _userManager.RemoveAuthenticationTokenAsync(user,
                                                          _configuration["Jwt:Issuer"] ?? "",
                                                          "Token");
    }

    public async Task CreateAsync(RegisterUserDto dto, string role)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        var user = new User()
        {
            FullName = dto.FullName,
            PhoneNumber = dto.PhoneNumber
        };

        await _userManager.SetUserNameAsync(user, dto.PhoneNumber);
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            throw new StackException($"Failed to create user: {string.Join("\n", result.Errors
                                                                                  .Select(er => er.Description))}");
        }

        result = await _userManager.AddToRoleAsync(user, role);
        if (!result.Succeeded)
        {
            throw new StackException($"Failed to add user to role: {string.Join("\n", result.Errors)}");
        }
    }


}
