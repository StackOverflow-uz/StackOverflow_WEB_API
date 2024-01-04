using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.UserD;

public class LoginUserDto
{
    [Required, MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    [Required, MaxLength(100)]
    public string Password { get; set; }
}
