namespace DataAccessLayer.Entities;

public class Saved : BaseEntity
{
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public virtual User User { get; set; } = new();
    public virtual Question Question { get; set; } = new();
    public virtual Answer Answer { get; set; } = new();

}
