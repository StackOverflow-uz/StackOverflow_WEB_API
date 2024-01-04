using DTOs.BaseD;

namespace DTOs.TagD;

public class AddTagDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
}
