using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.UserD;

public class RegisterUserDto
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
}
