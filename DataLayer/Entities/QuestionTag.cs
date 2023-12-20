using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class QuestionTag
{
    public int QuestionId { get; set; }
    public int TagId { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
    public List<Tag> Tags { get; set; } = new List<Tag>();
}