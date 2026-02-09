using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppContext(DbContextOptions<AppContext> options) : DbContext(options)
{
    public DbSet<Note> Notes { get; set; }
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().HasKey(x => x.Id);
        modelBuilder.Entity<Note>().Property(x => x.Text).HasMaxLength(140);

        // Конфигурация для Person
        modelBuilder.Entity<Person>().HasKey(x => x.Id);
        modelBuilder.Entity<Person>().Property(x => x.Email_login)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Person>().Property(x => x.Password_hash)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}