using DataAccessLayer.Entities;

namespace DTOs.QuestionTagD;

public class QuestionTagDto
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public int TagId { get; set; }
    public virtual Question? Question { get; set; }
    public virtual Tag? Tag { get; set; }
}
