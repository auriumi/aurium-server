namespace Aurium.Domain.Entities.Student;

public enum GraduationTerm { MID_YEAR , END_YEAR }

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

    public StudentAuth? Auth { get; private set; }
    public StudentDetail? Detail { get; private set; }
    public StudentSolicitation? Solicitation { get; private set; }

    private Student() {} //EF for later

    public static Student Create(
        int studentNumber, string firstName,
        string lastName, string? middleName,
        string personalEmail, string? schoolEmail,
        int graduationYear, GraduationTerm graduationTerm
    )
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name is required");
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name is required");
        if (string.IsNullOrWhiteSpace(personalEmail) || personalEmail.Contains('@'))
            throw new ArgumentException("A valid personal email is required");
        if (graduationYear < 2020)
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
    
    //attach additional details
    public StudentDetail AttachDetails(
        DateTime birthdate,
        string? contactNum = null,
        string? photoUrl = null,
        string? province = null,
        string? city = null,
        string? barangay = null,
        string? mothersName = null,
        string? mothersTitle = null,
        string? fathersName = null,
        string? fathersTitle = null,
        string? guardiansName = null,
        string? guardiansTitle = null
    )
    {
        if (Detail is not null)
            throw new InvalidOperationException("Student already has a detail record.");
        
        Detail = StudentDetail.Create(
            Id, birthdate, contactNum, photoUrl, province, city, barangay, 
            mothersName, mothersTitle, fathersName, fathersTitle, guardiansName, guardiansTitle
        );

        return Detail;
    }

    //attach solicitations
    public StudentSolicitation AttachSolicitation(
        SolicitationType solicitationType,
        int slot,
        string? title = null,
        string? name = null
    )
    {
        if (Solicitation is not null)
            throw new InvalidOperationException("Student already has a solicitation record.");
        
        Solicitation = StudentSolicitation.Create(
            StudentNumber, 
            solicitationType,
            slot,
            title,
            name
        );

        return Solicitation;
    }

    public StudentAuth AttachAuth()
    {
        if (Auth is not null)
            throw new InvalidOperationException("Student already has an auth record.");
        
        Auth = StudentAuth.Create(StudentNumber);
        return Auth;
    }
}
