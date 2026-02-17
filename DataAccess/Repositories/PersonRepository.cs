using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppContext _context;

        public PersonRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<Person?> GetByEmailLoginAsync(string emailLogin)
        {
            return await _context.Persons
                .FirstOrDefaultAsync(p => p.Email_login == emailLogin);
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            return await _context.Persons
               .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> EmailExistsAsync(string emailLogin)
        {
            return await _context.Persons
                .AnyAsync(p => p.Email_login == emailLogin);
        }

        public async Task CreateAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        // другие методы...
    }
}
