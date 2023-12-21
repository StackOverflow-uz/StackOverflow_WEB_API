using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class Tag : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public List<QuestionTag> QuestionTags { get; set; } = new List<QuestionTag>();
}
