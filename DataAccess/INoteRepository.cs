namespace DataAccess;

public interface INoteRepository
{
    Task CreateAsync(Note note, CancellationToken cancellationToken = default);
    Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    //Task UpdateByIdAsync(int id, string text,CancellationToken cancellationToken = default);
    Task UpdateAsync(Note note, CancellationToken cancellationToken = default);
    Task DeleteAsync(Note note, CancellationToken cancellationToken = default);
    Task Login(string email_login, string password_hash, CancellationToken cancellationToken = default);
}