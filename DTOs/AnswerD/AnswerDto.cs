using DataAccessLayer.Entities;
using DTOs.BaseD; 

namespace DTOs.AnswerD;

public class AnswerDto : BaseDto
{
    public string UserId { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    //public User User { get; set; }
}
