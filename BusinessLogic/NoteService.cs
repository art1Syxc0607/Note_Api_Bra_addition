using BCrypt.Net;
using DataAccess.Repositories;
using DataAccess.Entities;
namespace BussinessLogic;

internal class NoteService(INoteRepository noteRepository) : INoteService
{


    public async Task CreateNoteAsync(string text, int personId)
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

    public async Task<List<Note>> GetPersonNotesAsync(int personId)
    {
        // Возвращаем только заметки этого пользователя
        return await noteRepository.GetByPersonIdAsync(personId);
    }

    public async Task UpdateNoteAsync(int noteId, string newText, int personId)
    {
        var note = await noteRepository.GetByIdAsync(noteId);

        // Важно! Проверяем, что заметка принадлежит пользователю
        if (note.Id_person != personId)
            throw new UnauthorizedAccessException("Это не ваша заметка");

        note.Text = newText;
        note.Updated = DateTime.UtcNow;

        await noteRepository.UpdateAsync(note);
    }



}