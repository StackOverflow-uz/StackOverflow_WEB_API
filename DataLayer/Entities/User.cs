using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public string AvatarUrl { get; set; } = string.Empty;

    public string About { get; set; } = string.Empty;
    public int Reputation { get; set; }
    public virtual List<Saved> Saves { get; set;} = new ();
    public virtual List<Comment> Comments { get; } = new ();
    public virtual List<Answer> Answers { get; } = new ();
    public virtual List<Question> Questions { get; } = new ();
}
