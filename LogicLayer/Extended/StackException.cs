using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Extended;

public class StackException(string Message) : Exception
{
    public string ErrorMessage { get; } = Message;
}
