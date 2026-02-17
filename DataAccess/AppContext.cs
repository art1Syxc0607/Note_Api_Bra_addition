using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess;

public class AppContext(DbContextOptions<AppContext> options) : DbContext(options)
{
    public DbSet<Note> Notes { get; set; }
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().HasKey(x => x.Id);
        modelBuilder.Entity<Note>().Property(x => x.Text).HasMaxLength(140).IsRequired();
        modelBuilder.Entity<Note>().Property(x => x.Id_person)
           .IsRequired();

        // Конфигурация для Person
        //modelBuilder.Entity<Person>().HasKey(x => x.Id);
        //modelBuilder.Entity<Person>().Property(x => x.Email_login)
        //    .IsRequired()
        //    .HasMaxLength(100);
        //modelBuilder.Entity<Person>().Property(x => x.Password_hash)
        //    .IsRequired();

        // Настройка Person
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();

            entity.Property(x => x.Email_login)
                .IsRequired()
                .HasMaxLength(100);
            entity.HasIndex(x => x.Email_login).IsUnique();

            entity.Property(x => x.Password_hash)
                .IsRequired()
                .HasMaxLength(255);

            // Связь с заметками (один ко многим)
            entity.HasMany(x => x.Notes)           // У Person много Notes
                .WithOne(x => x.Person)             // У Note один Person
                .HasForeignKey(x => x.Id_person)     // Внешний ключ в Note
                .OnDelete(DeleteBehavior.Cascade);  // При удалении Person удаляются его Notes
        });


        base.OnModelCreating(modelBuilder);
    }
}