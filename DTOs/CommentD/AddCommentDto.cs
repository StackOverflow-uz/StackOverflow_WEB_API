using DataAccessLayer.Entities;

namespace DTOs.CommentD;

public class AddCommentDto
{
    public string Text { get; set; } = string.Empty;
    public int QuestionId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public bool IsReply { get; set; }
    public int RepliedCommentId { get; set; }
}
