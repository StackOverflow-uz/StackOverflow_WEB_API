namespace DTOs.User;

public class UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public string AvatarUrl { get; set; } = string.Empty;

    public string About { get; set; } = string.Empty;
    public int Reputation { get; set; }
}
