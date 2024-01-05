using DataAccessLayer.Entities;
using DTOs.BaseD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.SavedD;

public class AddSavedDto : BaseDto
{
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public string UserId { get; set; } = string.Empty;
}
