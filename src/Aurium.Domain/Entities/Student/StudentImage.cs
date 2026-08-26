namespace Aurium.Domain.Entities.Student;

public enum ImageType { GRADUATION, THEME }
public enum ImageStatus { PENDING, APPROVED, REJECTED }

public class StudentImage 
{
    public int Id { get; private set; }
    public int StudentNumber { get; private set; }
    public int Year { get; private set; }

    public string PhotoUrl { get; private set; } = string.Empty;
    public ImageType Type { get; private set; }
    public ImageStatus Status { get; private set; }

    public int UploadedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private StudentImage() {}

    private StudentImage(
        int studentNumber,
        int year,
        string photoUrl,
        ImageType type,
        ImageStatus status,
        int uploadedBy,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        StudentNumber = studentNumber;
        Year = year;
        PhotoUrl = photoUrl;
        Type = type;
        Status = status;
        UploadedBy = uploadedBy;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    internal static StudentImage Create(
        int studentNumber,
        int year,
        string photoUrl,
        ImageType type,
        int uploadedBy,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        if (studentNumber <= 0)
            throw new ArgumentException("A valid student number is required.");
        if (year <= 0)
            throw new ArgumentException("A valid year is required.");
        if (string.IsNullOrWhiteSpace(photoUrl))
            throw new ArgumentException("A photo url is required.");
        if (uploadedBy <= 0)
            throw new ArgumentException("A valid admin id is required.");
        
        return new StudentImage(
            studentNumber,
            year,
            photoUrl,
            type,
            status: ImageStatus.PENDING,
            uploadedBy,
            createdAt,
            updatedAt
        );
    }
}
