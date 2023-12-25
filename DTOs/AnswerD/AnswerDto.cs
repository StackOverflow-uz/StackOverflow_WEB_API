using DataAccessLayer.Entities;
using DTOs.BaseD;
namespace DTOs.AnswerD;

public class AnswerDto : BaseDto
{
    public Guid UserId { get; set; }
    public string Body { get; set; } = string.Empty;
    public User User { get; set; }
}
