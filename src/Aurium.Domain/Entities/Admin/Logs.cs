namespace Aurium.Domain.Entities.Admin;

public enum AdminActions { APPROVED, VERIFIED, UPLOADED }

public class Logs {
    public int Id { get; private set; }
    public int AdminId { get; private set; }
    public AdminActions Action { get; private set; }
    public int? TargetId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Logs() {} //EF later :3

    private Logs(
        int adminId,
        AdminActions action,
        int targetId,
        DateTime createdAt
    )
    {
      AdminId = adminId;
      Action = action;
      TargetId = targetId;
      CreatedAt = createdAt;
    }

    internal static Logs Create(
        int adminId,
        AdminActions action,
        int targetId,
        DateTime createdAt
    )
    {
      if (targetId <= 0) 
          throw new ArgumentException("A valid target ID is required.");

      return new Logs(
          adminId,
          action,
          targetId,
          createdAt
      );
    }
}
