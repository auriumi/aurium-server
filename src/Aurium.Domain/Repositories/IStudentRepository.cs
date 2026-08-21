namespace Aurium.Domain.Repositories;

using Aurium.Domain.Entities;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Student?> GetByStudentNumberAsync(int studentNumber, CancellationToken ct = default);
    Task AddAsync(Student student, CancellationToken ct = default);
}