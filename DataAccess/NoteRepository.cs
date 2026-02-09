using Microsoft.EntityFrameworkCore;

namespace DataAccess;

internal class NoteRepository(AppContext context) : INoteRepository
{
    public async Task CreateAsync(Note note, CancellationToken cancellationToken = default)
    {
        note.Created = DateTime.Now;
        await context.Notes.AddAsync(note, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Notes.FirstOrDefaultAsync(x => x.Id == id); // возвращаю x(Note) если x.Id == id
    }

    //public async Task UpdateByIdAsync(int id, string text, CancellationToken cancellationToken = default)
    //{
    //    var note = await context.Notes.FirstOrDefaultAsync(x=> x.Id == id);
    //    if (note is null)
    //        throw new Exception("Note note found");

    //    note.Text = text;

    //    note.Updated = DateTime.Now;
    //    await context.SaveChangesAsync(cancellationToken);
    //}

    public async Task UpdateAsync(Note note, CancellationToken cancellationToken = default)
    {
        note.Updated = DateTime.Now;
        context.Notes.Update(note);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Note note, CancellationToken cancellationToken = default)
    {
        context.Notes.Remove(note);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task Login(string email_login, string password_hash, CancellationToken cancellationToken = default)
    {
        //return await context.Persons.FirstOrDefaultAsync(x => x.Email_password == person.Email_password && x.Password_ == person.Password_);
        var person = await context.Persons.FirstOrDefaultAsync(x => x.Email_login == email_login && x.Password_hash == password_hash);
        if (person == null)
        {
            context.Persons.Add(new Person { Email_login = email_login, Password_hash = password_hash });

            await context.SaveChangesAsync(cancellationToken);


        }
    }

}
