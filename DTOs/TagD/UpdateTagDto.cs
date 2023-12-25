using DTOs.BaseD;

namespace DTOs.TagD;

public class UpdateTagDto : BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
