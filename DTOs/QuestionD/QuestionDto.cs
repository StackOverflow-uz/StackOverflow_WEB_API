using DataAccessLayer.Entities;

namespace DTOs.QuestionD;

public class QuestionDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    //public virtual User User { get; set; }
    public List<QuestionTag> QuestionTags { get; set; } = new List<QuestionTag>();
    public virtual List<Saved> Saves { get; set; } = new List<Saved>();
    public virtual List<Comment> Comments { get; set; } = new List<Comment>();
}
