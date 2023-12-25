using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.QuestionTagD;

public class AddQuestionTagDto
{
    public int QuestionId { get; set; }
    public int TagId { get; set; }
}
