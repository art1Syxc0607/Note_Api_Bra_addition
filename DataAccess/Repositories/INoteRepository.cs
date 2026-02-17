using DataAccess.Entities;
namespace DataAccess.Repositories;

public interface INoteRepository
{
    Task<List<Note>?> GetNotesByPersonIdAsync(int personId);
    Task<Note?> GetByIdAsync(int id);
    Task CreateAsync(Note note); 
    Task UpdateAsync(Note note);
    Task DeleteAsync(Note note);
}