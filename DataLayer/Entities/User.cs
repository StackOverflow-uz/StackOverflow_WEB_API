using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities;

public class User : IdentityUser
{
    public string Location { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public int Reputation { get; set; }
    public virtual ICollection<Saved> Saves { get; set;} = new List<Saved>();
    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();
    public virtual ICollection<Answer> Answers { get; } = new List<Answer>();
    public virtual ICollection<Question> Questions { get; } = new List<Question>();
}
