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
    
    public static bool IsValid(this User answer)
    => answer != null && !string.IsNullOrEmpty(answer.UserName);
    public static bool IsExist(this User answer, IEnumerable<User> answers)
        => answers.Any(c => c.UserName == answer.UserName && c.Id != answer.Id);

    public static bool IsValid(this Comment answer)
    => answer != null && !string.IsNullOrEmpty(answer.Text);
    public static bool IsExist(this Comment answer, IEnumerable<Comment> answers)
        => answers.Any(c => c.Text == answer.Text && c.Id != answer.Id);

    public static bool IsValid(this Tag answer)
    => answer != null && !string.IsNullOrEmpty(answer.Name);
    public static bool IsExist(this Tag answer, IEnumerable<Tag> answers)
        => answers.Any(c => c.Name == answer.Name && c.Id != answer.Id);
}
