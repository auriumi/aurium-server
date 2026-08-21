namespace Aurium.Domain.Entities;

public enum GraduationTerm { MidYear, EndYear }

public class Student
{
    public int Id { get; private set; }
    public int StudentNumber { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string? MiddleName { get; private set; }
    public string LastName { get; private set; } = string.Empty;
    public string PersonalEmail { get; private set; } = string.Empty;
    public string? SchoolEmail { get; private set; }
    public int GraduationYear { get; private set; }
    public GraduationTerm GraduationTerm { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Student() { }

    public static Student Create(
        int studentNumber,
        string firstName,
        string lastName,
        string? middleName,
        string personalEmail,
        string? schoolEmail,
        int graduationYear,
        GraduationTerm graduationTerm)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name is required");
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name is required");
        if (string.IsNullOrWhiteSpace(personalEmail) || personalEmail.Contains('@'))
            throw new ArgumentException("A valid personal email is required");
        if (graduationYear < 0)
            throw new ArgumentException("A valid graduation year is required");


        return new Student
        {
            StudentNumber = studentNumber,
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            PersonalEmail = personalEmail,
            SchoolEmail = schoolEmail,
            GraduationYear = graduationYear,
            GraduationTerm = graduationTerm,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
    }
}