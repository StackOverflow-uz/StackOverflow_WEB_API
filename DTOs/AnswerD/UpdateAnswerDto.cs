using DTOs.BaseD;

namespace DTOs.AnswerD;

public class UpdateAnswerDto : BaseDto
{
    public string UserId { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}
