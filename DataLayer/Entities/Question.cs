using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class Question : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = new();
    public ICollection<QuestionTag> QuestionTags { get; set; } = new List<QuestionTag>();
    public virtual ICollection<Saved> Saves { get; set; } = new List<Saved>();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
