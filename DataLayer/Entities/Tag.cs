namespace DataAccessLayer.Entities;

public class Tag : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public List<QuestionTag> QuestionTags { get; set; } = new ();
}
