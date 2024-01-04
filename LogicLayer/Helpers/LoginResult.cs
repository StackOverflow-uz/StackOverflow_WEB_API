using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Helpers
{
    public class LoginResult
    {
        public bool IsSuccesed { get; set; } = true;
        public List<string> ErrorMessage { get; set; } = new();
        public string Token { get; set; } = string.Empty;
        public LoginResult(bool isSuccessed,
                           List<string> errorMessages,
                           string token = "")
        {
            IsSuccesed = isSuccessed;
            ErrorMessage = errorMessages;
            Token = token;
        }
    }
}
