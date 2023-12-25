namespace DTOs.QuestionD;

public class AddQuestionDto
{
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}
