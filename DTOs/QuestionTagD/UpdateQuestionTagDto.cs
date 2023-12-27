using DTOs.BaseD;

namespace DTOs.QuestionTagD;

public class UpdateQuestionTagDto : BaseDto
{
    public int QuestionId { get; set; }
    public int TagId { get; set; }
}
