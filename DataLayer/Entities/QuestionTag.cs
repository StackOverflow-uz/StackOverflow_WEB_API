using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class QuestionTag 
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public int TagId { get; set; }
    public virtual Question Question { get; set; }
    public virtual Tag Tag { get; set; }

}
