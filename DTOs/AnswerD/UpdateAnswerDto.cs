using DTOs.BaseD;

namespace DTOs.AnswerD;

public class UpdateAnswerDto : BaseDto
{
    public Guid UserId { get; set; }
    public string Body { get; set; } = string.Empty;
}
