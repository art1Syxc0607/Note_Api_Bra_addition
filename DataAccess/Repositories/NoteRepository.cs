using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess.Repositories;

internal class NoteRepository(AppContext context) : INoteRepository
{

    public async Task<List<Note>?> GetNotesByPersonIdAsync(int personId)
    {
        return await context.Notes
            .Where(n => n.Id_person == personId) // ← Фильтр по пользователю
            .OrderByDescending(n => n.Created)
            .ToListAsync();
    }

    public async Task<Note?> GetByIdAsync(int id) // Task<Note?>  ?
    {
        return await context.Notes
            .Include(n => n.Person) // Можно загрузить связанного Person
            .FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task CreateAsync(Note note)
    {
        context.Notes.Add(note);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Note note)
    {
        context.Notes.Update(note);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Note note)
    {
        context.Notes.Remove(note);
        await context.SaveChangesAsync();
    }

}
