using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class User
{
    [Key, Required]
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public string AvatarUrl { get; set; } = string.Empty;

    public string About { get; set; } = string.Empty;
    public int Reputation { get; set; }
    public virtual List<Saved> Saves { get; set;} = new List<Saved>();
    public virtual List<Comment> Comments { get; } = new List<Comment>();
    public virtual List<Answer> Answers { get; } = new List<Answer>();
    public virtual List<Question> Questions { get; } = new List<Question>();
}
