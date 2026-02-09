using DataAccess;
using BCrypt.Net;
namespace BussinessLogic;

internal class NoteService(INoteRepository noteRepository) : INoteService
{
    public async Task CreateAsync(string text, CancellationToken cancellationToken = default)
    {
        var note = new Note
        {
            Text = text
        };

        await noteRepository.CreateAsync(note, cancellationToken);
    }

    public async Task<string?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var note = await noteRepository.GetByIdAsync(id, cancellationToken);
        if (note is null)
            throw new Exception("Note note found");

        return note.Text;
    }

    // my
    //public async Task UpdateByIdAsync(int id, string text, CancellationToken cancellationToken = default)
    //{
    //    await noteRepository.UpdateByIdAsync(id, text, cancellationToken);
    //}

    public async Task UpdateAsync(int id, string newtext, CancellationToken cancellationToken = default)
    {
        var note = await noteRepository.GetByIdAsync(id, cancellationToken);
        if (note is null)
            throw new Exception("Note note found");

        note.Text = newtext;
        await noteRepository.UpdateAsync(note, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var note = await noteRepository.GetByIdAsync(id, cancellationToken);
        if (note is null)
            throw new Exception("Note note found");

        await noteRepository.DeleteAsync(note, cancellationToken);
    }

    public async Task Login(string? email_login, string? password, CancellationToken cancellationToken = default)
    {
        if (email_login == null || password == null)
            throw new Exception("Login or passwort is empty");

        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, 12);

        await noteRepository.Login(email_login, hashedPassword, cancellationToken);
    }

}