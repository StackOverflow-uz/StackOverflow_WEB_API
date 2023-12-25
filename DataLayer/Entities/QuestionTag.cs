namespace DataAccessLayer.Entities;

public class QuestionTag 
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public int TagId { get; set; }
    public virtual Question Question { get; set; } = new ();
    public virtual Tag Tag { get; set; } = new();

}
