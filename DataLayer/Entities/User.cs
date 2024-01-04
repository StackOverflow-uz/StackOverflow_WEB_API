using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities;

public class User : IdentityUser
{
    public string Location { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public int Reputation { get; set; }
    public virtual List<Saved> Saves { get; set; } = new List<Saved>();
    public virtual List<Comment> Comments { get; set; } = new List<Comment>();
    public virtual List<Answer> Answers { get; set; } = new List<Answer>();
    public virtual List<Question> Questions { get; set; } = new List<Question>();
}
