namespace DataAccessLayer.Entities;

public class Question : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = new();
    public List<QuestionTag> QuestionTags { get; set; } = new ();
    public virtual List<Saved> Saves { get; set; } = new ();
    public virtual List<Comment> Comments { get; set; } = new ();
}
