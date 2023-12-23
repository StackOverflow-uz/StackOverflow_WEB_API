using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class Answer : BaseEntity
{
    public Guid UserId { get; set; }
    public string Body { get; set; } = string.Empty;
    public int AnswersCount { get; set; }
    public virtual User User { get; set; } = new();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Saved> Saveds { get; set; } = new List<Saved>();
}
