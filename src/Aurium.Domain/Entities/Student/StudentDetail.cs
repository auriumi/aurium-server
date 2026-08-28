namespace Aurium.Domain.Entities.Student;

public class StudentDetail
{
    public int Id { get; private set; }
    public DateTime Birthdate { get; private set; }

    public string? PhotoUrl { get; private set; }
    public string? ContactNum { get; private set; }

    public string? Province { get; private set; }
    public string? City { get; private set; }
    public string? Barangay { get; private set; }

    public string? MothersName { get; private set; }
    public string? MothersTitle { get; private set; }
    public string? FathersName { get; private set; }
    public string? FathersTitle { get; private set; }
    public string? GuardiansName { get; private set; }
    public string? GuardiansTitle { get; private set; }

    private StudentDetail() {}

    private StudentDetail(
        DateTime birthdate, 
        string? contactNum,
        string? photoUrl,
        string? province,
        string? city, 
        string? barangay,
        string? mothersName,
        string? mothersTitle,
        string? fathersName,
        string? fathersTitle,
        string? guardiansName,
        string? guardiansTitle
    )
    {
        Birthdate = birthdate;
        PhotoUrl = photoUrl;
        ContactNum = contactNum;
        Province = province;
        City = city;
        Barangay = barangay;
        MothersName = mothersName;
        MothersTitle = mothersTitle;
        FathersName = fathersName;
        FathersTitle = fathersTitle;
        GuardiansName = guardiansName;
        GuardiansTitle = guardiansTitle;
    }

    //dependency scoped
    internal static StudentDetail Create(
        DateTime birthdate, 
        string? contactNum,
        string? photoUrl,
        string? province,
        string? city, 
        string? barangay,
        string? mothersName,
        string? mothersTitle,
        string? fathersName,
        string? fathersTitle,
        string? guardiansName,
        string? guardiansTitle
    )
    {
        if (birthdate == default || birthdate >= DateTime.UtcNow)
            throw new ArgumentException("A valid birthdate is required");
        
        return new StudentDetail(
            birthdate, 
            contactNum, 
            photoUrl, 
            province, 
            city, 
            barangay,
            mothersName, 
            mothersTitle, 
            fathersName, 
            fathersTitle, 
            guardiansName, 
            guardiansTitle
        );
    }
}
