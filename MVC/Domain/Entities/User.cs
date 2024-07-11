namespace MVC.Domain.Entities;
public class User
{
    public required string UserId { get; set; }
    public required string UserName { get; set; }
    public required string HashPassword { get; set; }
    public required string Role { get; set; }
}
