using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;          // Для UseSqlite и DbContextOptionsBuilder
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddDbContext<AppContext>(options =>
        {
            options.UseSqlite("Data Source=notes_persons.db");

        });
        return services;
    }


}