using DataAccess.Entities;

namespace BussinessLogic;

public interface INoteService
{
    Task CreateAsync(string text, int Personid, CancellationToken cancellationToken = default);

    // до связи пользователя и заметок
    //Task<string?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    ////Task UpdateByIdAsync(int id, string text, CancellationToken cancellationToken = default);
    //Task UpdateAsync(int id, string newtext,CancellationToken cancellationToken = default);
    //Task DeleteAsync(int id, CancellationToken cancellationToken = default);

    Task<List<Note>> GetPersonNotesAsync(int personId, CancellationToken cancellationToken = default);
    Task UpdateNoteAsync(int noteId, string newText, int personId, CancellationToken cancellationToken = default);
    Task DeleteNoteAsync(int noteId, int personId, CancellationToken cancellationToken = default);

}