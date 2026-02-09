using Microsoft.EntityFrameworkCore;          // Для UseSqlite и DbContextOptionsBuilder
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddDbContext<AppContext>(options =>
        {
            options.UseSqlite("Data Source=notes_bra.db"); // Теперь это должно работать
            options.UseSqlite("Data Source=persons.db"); 
        });
        return services;
    }


}