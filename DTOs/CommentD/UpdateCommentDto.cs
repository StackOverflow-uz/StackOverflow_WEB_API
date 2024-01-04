namespace DTOs.CommentD;

public class UpdateCommentDto
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public int QuestionId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public bool IsReply { get; set; }
}
