namespace DataAccessLayer.Entities;

public class Comment : BaseEntity
{
    public string Text { get; set; } = string.Empty;
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public Guid UserId { get; set; }
    public bool IsReply { get; set; }
    public int RepliedCommentId { get; set; }
    public virtual User UserComment { get; set; }
    public virtual Answer Answer { get; set; }
    public virtual Question Question { get; set; }
    public virtual List<Comment> RepliComments { get; set; } = new List<Comment>();
}