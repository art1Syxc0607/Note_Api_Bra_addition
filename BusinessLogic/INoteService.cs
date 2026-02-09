namespace BussinessLogic;

public interface INoteService
{
    Task CreateAsync(string text, CancellationToken cancellationToken = default);
    Task<string?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    //Task UpdateByIdAsync(int id, string text, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, string newtext,CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);

    Task Login(string? email_login, string? password, CancellationToken cancellationToken = default);
}