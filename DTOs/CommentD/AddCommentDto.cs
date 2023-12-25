using DataAccessLayer.Entities;

namespace DTOs.CommentD;

public class AddCommentDto
{
    public string Text { get; set; } = string.Empty;
    public int QuestionId { get; set; }
    public Guid UserId { get; set; }
    public bool IsReply { get; set; }
    public int RepliedCommentId { get; set; }
    public virtual User UserComment { get; set; } = new ();
    public virtual Question Question { get; set; } = new();
}
