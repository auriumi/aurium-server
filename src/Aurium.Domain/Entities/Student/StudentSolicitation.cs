namespace Aurium.Domain.Entities.Student;

public enum SolicitationType { PERSON, COMPANY }

public class StudentSolicitation
{
    public int Id { get; private set; }
    public int StudentNumber { get; private set; }
    public SolicitationType Type { get; private set; }
    public int Slot { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Title { get; private set; }

    private StudentSolicitation() {}

    private StudentSolicitation(
        int studentNumber,
        SolicitationType solicitationType,
        int slot,
        string? title,
        string name
    )
    {
        StudentNumber = studentNumber;
        Type = solicitationType;
        Slot = slot;
        Title = title;
        Name = name;
    }

    //dependency scoped
    internal static StudentSolicitation Create(
        int studentNumber,
        SolicitationType solicitationType,
        int slot,
        string? title,
        string name
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("A name is required.");
        if (slot <= 0)
            throw new ArgumentException("A valid slot number is required.");

        return new StudentSolicitation(
            studentNumber, //FK
            solicitationType,
            slot,
            title,
            name
        );
    }
}
