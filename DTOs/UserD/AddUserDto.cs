namespace DTOs.UserD;

public class AddUserDto
{
    public string UserName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string AvatarUrl { get; set; } = string.Empty;

    public string About { get; set; } = string.Empty;
}
