using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class Comment : BaseEntity
{
    public string Text { get; set; } = string.Empty;
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public string UserId { get; set; }
    public bool IsReply { get; set; }
    public int RepliedCommentId { get; set; }
    public virtual User UserComment { get; set; }
    public virtual Answer Answer { get; set; }
    public virtual Question Question { get; set; }
    public virtual List<Comment> RepliComments { get; set; } = new List<Comment>();
}
