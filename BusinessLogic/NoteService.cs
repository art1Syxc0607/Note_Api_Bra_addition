using BCrypt.Net;
using DataAccess.Repositories;
using DataAccess.Entities;
namespace BussinessLogic;

internal class NoteService(INoteRepository noteRepository) : INoteService
{


    public async Task CreateNoteAsync(string text, int personId, CancellationToken cancellationToken = default)
    {
        var note = new Note
        {
            Text = text,
            Id_person = personId, // ← Привязываем к конкретному пользователю
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow
        };

        await noteRepository.CreateAsync(note);
    }

    public async Task<List<Note>?> GetPersonNotesAsync(int personId, CancellationToken cancellationToken = default)
    {
        // Возвращаем только заметки этого пользователя
        return await noteRepository.GetNotesByPersonIdAsync(personId);
    }

    public async Task<Note?> GetPersonNoteAsync(int personId, int noteId, CancellationToken cancellationToken = default)
    {
        var note = await noteRepository.GetByIdAsync(noteId);

        // Важно! Проверяем, что заметка принадлежит пользователю
        if (note.Id_person != personId || note == null)
            throw new UnauthorizedAccessException("Это не ваша заметка");

        return note;
    }

    public async Task UpdateNoteAsync(int noteId, string newText, int personId, CancellationToken cancellationToken = default)
    {
        var note = await noteRepository.GetByIdAsync(noteId);

        // Важно! Проверяем, что заметка принадлежит пользователю
        if (note.Id_person != personId || note == null)
            throw new UnauthorizedAccessException("Это не ваша заметка");

        note.Text = newText;
        note.Updated = DateTime.UtcNow;

        await noteRepository.UpdateAsync(note);
    }

    public async Task DeleteNoteAsync(int noteId, int personId, CancellationToken cancellationToken = default)
    {
        var note = await noteRepository.GetByIdAsync(noteId);

        if (note.Id_person != personId || note == null)
            throw new UnauthorizedAccessException("Это не ваша заметка");

        await noteRepository.UpdateAsync(note);
    }



}