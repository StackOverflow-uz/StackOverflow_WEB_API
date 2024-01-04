using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Helpers
{
    public class AuthResult(bool isSuccess,
                          List<string> errorMessage)
    {
        public bool IsSuccesed = isSuccess;
        public List<string> ErrorMessage = errorMessage;

        public static implicit operator AuthResult(IdentityResult result)
            => new(isSuccess: result.Succeeded,
               errorMessage: result.Errors
                                   .Select(error => error.Description)
                                   .ToList());
    }
}
