namespace DTOs.AnswerD;

public class AddAnswerDto
{
    public Guid UserId { get; set; }
    public string Body { get; set; } = string.Empty;
}
