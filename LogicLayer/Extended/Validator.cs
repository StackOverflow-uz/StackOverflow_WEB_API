using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Extended;

public static class Validator
{
    public static bool IsValid(this Answer answer)
    => answer != null && !string.IsNullOrEmpty(answer.Body);
    public static bool IsExist(this Answer answer, IEnumerable<Answer> answers)
        => answers.Any(c => c.Body == answer.Body && c.Id != answer.Id);
}
