namespace Aurium.Application.Student;

using Aurium.Domain.Entities.Student;
using Aurium.Domain.Repositories;

public record SubmitRegistrationRequest(
    int StudentNumber,
    Suffix? Suffix,
    string FirstName,
    string? MiddleName,
    string LastName,
    string Nickname,
    string PersonalEmail,
    string? SchoolEmail,
    string Department,
    string Course,
    string? Major,
    string? ThesisTitle,
    int GraduationYear,
    GraduationTerm GraduationTerm
);

public class SubmitRegistration(IStudentRepository studentRepository)
{
    public async Task<int> Handle(SubmitRegistrationRequest req, CancellationToken ct = default)
    {
        var existing = await studentRepository.GetByStudentNumberAsync(req.StudentNumber, ct);
        if (existing is not null)
            throw new ArgumentException($"Student number {req.StudentNumber} is already registered");

        var now = DateTime.UtcNow;

        var student = Student.Create(
            studentNumber: req.StudentNumber,
            suffix: req.Suffix,
            firstName: req.FirstName,
            lastName: req.LastName,
            nickname: req.Nickname,
            middleName: req.MiddleName,
            personalEmail: req.PersonalEmail,
            schoolEmail: req.SchoolEmail,
            department: req.Department,
            course: req.Course,
            major: req.Major,
            thesisTitle: req.ThesisTitle,
            graduationYear: req.GraduationYear,
            graduationTerm: req.GraduationTerm,
            createdAt: now,
            updatedAt: now
        );

        await studentRepository.AddAsync(student, ct);
        return student.Id;
    }
}