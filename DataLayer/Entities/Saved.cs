﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class Saved : BaseEntity
{
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public virtual User User { get; set; }
    public virtual Question Question { get; set; }
    public virtual Answer Answer { get; set; }

}
