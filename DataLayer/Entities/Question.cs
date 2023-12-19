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
    public User User { get; set; }
    public QuestionTag QuestionTag { get; set; }
    public virtual List<Saved> Saves { get; set; } = new List<Saved>();
    public virtual List<Comment> Comments { get; set; } = new List<Comment>();
}
