namespace Aurium.Application.Student;

using Aurium.Domain.Entities;
using Aurium.Domain.Repositories;

public record SubmitRegistrationRequest(
    int StudentNumber,
    string FirstName,
    string? MiddleName,
    string LastName,
    string PersonalEmail,
    string? SchoolEmail,
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
        
        var student = Student.Create(
            studentNumber: req.StudentNumber,
            firstName: req.FirstName,
            lastName: req.LastName,
            middleName: req.MiddleName,
            personalEmail: req.PersonalEmail,
            schoolEmail: req.SchoolEmail,
            graduationYear: req.GraduationYear,
            graduationTerm: req.GraduationTerm
        );

        await studentRepository.AddAsync(student, ct);
        return student.Id;
    }
}