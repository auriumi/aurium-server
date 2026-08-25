namespace Aurium.Domain.Entities;

public enum AdminRoles { MEMBER, MODERATOR, ADMINISTRATOR }

public class Admin {
  public int Id { get; private set; }
  public string? Email { get; private set; }
  public string? FirstName { get; private set; }
  public string? LastName { get; private set; }
  public string HashedPassword { get; private set; } = string.Empty;
  public DateTime? LastLogin { get; private set; }
  public AdminRoles Role { get; private set; } = AdminRoles.MEMBER;
  public bool CanApproveImages { get; private set; }

  private Admin() {} //EF later :3

  public static Admin Create(
      int id,
      string? email,
      string? firstName,
      string? lastName,
      string hashedPassword,
      DateTime? lastLogin,
      AdminRoles role,
      bool canApproveImages
  )
  {
      if (id <= 0)
          throw new ArgumentException("A valid ID is required.");
      if (string.IsNullOrWhiteSpace(hashedPassword))
          throw new ArgumentException("No password is set.");

      return new Admin
      {
          Id = id,
          Email = email,
          FirstName = firstName,
          LastName = lastName,
          HashedPassword = hashedPassword,
          LastLogin = lastLogin,
          Role = role,
          CanApproveImages = canApproveImages 
      };
  }
