namespace DTOs.AnswerD;

public class UpdateAnswerDto
{
    public Guid UserId { get; set; }
    public string Body { get; set; } = string.Empty;
}
