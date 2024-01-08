using DTOs.BaseD;

namespace DTOs.SavedD;

public class UpdateSavedDto : BaseDto
{
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
}
