using DTOs.BaseD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.TagD;

public class AddTagDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
}
