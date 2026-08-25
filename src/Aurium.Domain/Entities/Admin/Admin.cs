namespace Aurium.Domain.Entities.Admin;

public enum AdminRoles { MEMBER, MODERATOR, ADMINISTRATOR }

public class Admin {
    public int Id { get; private set; }
    public string? Email { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string HashedPassword { get; private set; } = string.Empty;
    public DateTime? LastLogin { get; private set; }
    public AdminRoles Role { get; private set; }
    public bool CanApproveImages { get; private set; }

    private Admin() {} //EF later :3

    public static Admin Create(
        string? email,
        string? firstName,
        string? lastName,
        string hashedPassword
    )
    {
        if (string.IsNullOrWhiteSpace(hashedPassword))
            throw new ArgumentException("No password is set.");

        return new Admin
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            HashedPassword = hashedPassword,
            Role = AdminRoles.MEMBER,
            CanApproveImages = false 
        };
    }
}
