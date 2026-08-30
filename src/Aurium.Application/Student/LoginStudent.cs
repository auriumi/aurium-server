namespace Aurium.Application.Student;

using Aurium.Domain.Repositories;

public record LoginStudentRequest(int StudentNumber, string Password);

public class LoginStudent(IStudentRepository studentRepository)
{
    public async Task<bool> Handle(LoginStudentRequest req, CancellationToken ct = default)
    {
        //boilerplate
        var student = await studentRepository.GetByStudentNumberAsync(req.StudentNumber, ct);
        if (student is null)
            return false;

        var auth = student.Auth;
        if (auth is null)
            return false;

        var storedPassword = auth.HashedPassword;
        if (storedPassword is null)
            return false;

        var passwordMatches = storedPassword == req.Password;
        return passwordMatches;
    }
}