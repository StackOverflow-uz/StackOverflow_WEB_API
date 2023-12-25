namespace DataAccessLayer.Entities;

public class Answer : BaseEntity
{
    public Guid UserId { get; set; }
    public string Body { get; set; } = string.Empty;
    public int AnswersCount { get; set; }
    public virtual User User { get; set; } = new();
    public virtual List<Comment> Comments { get; set; } = new ();
    public virtual List<Saved> Saveds { get; set; } = new ();
}
