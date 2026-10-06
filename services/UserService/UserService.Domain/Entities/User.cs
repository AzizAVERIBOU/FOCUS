namespace UserService.Domain.Entities;

public class User
{
    public Guid AuthUserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}