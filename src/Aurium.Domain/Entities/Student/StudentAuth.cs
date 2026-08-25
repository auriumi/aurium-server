namespace Aurium.Domain.Entities.Student;

//temp, enums need a better name imo
public enum StudentStatus { REGISTERED, VERIFIED, BOOKED, ATTENDED }

public class StudentAuth
{
    public int StudentNumber { get; private set; }
    public bool IsVerified { get; private set; }
    public bool IsNew { get; private set; }

    public string? HashedPassword { get; private set; }
    public DateTime? LastLogin { get; private set; }

    private StudentAuth() {}

    private StudentAuth(
        int studentNumber,
        bool isVerified,
        bool isNew,
        string? hashedPassword,
        DateTime? lastLogin
    )
    {
        StudentNumber = studentNumber;
        IsVerified = isVerified;
        IsNew = isNew;
        HashedPassword = hashedPassword;
        LastLogin = lastLogin;
    }

    internal static StudentAuth Create(int studentNumber)
    {
        if (studentNumber <= 0) 
            throw new ArgumentException("A valid student number is required.");
        
        return new StudentAuth(
            studentNumber,
            isVerified: false,
            isNew: true,
            hashedPassword: null,
            lastLogin: null
        );
    }
}
