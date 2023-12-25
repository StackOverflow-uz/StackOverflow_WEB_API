using DataAccessLayer.Entities;
using DTOs.BaseD;

namespace DTOs.CommentD;

public class CommentDto : BaseDto
{
    public string Text { get; set; } = string.Empty;
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public Guid UserId { get; set; }
    public bool IsReply { get; set; }
    public int RepliedCommentId { get; set; }
    public virtual User UserComment { get; set; } = new();
    public virtual Answer Answer { get; set; } = new();
    public virtual Question Question { get; set; } = new();
}
