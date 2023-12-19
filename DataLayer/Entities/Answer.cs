using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class Answer : BaseEntity
{
    [Key, Required]
    public Guid UserId { get; set; }
    public string Body { get; set; } = string.Empty;
    public int AnswersCount { get; set; }

}
