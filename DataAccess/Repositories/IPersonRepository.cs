using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories;
public interface IPersonRepository
{
    Task<Person?> GetByEmailLoginAsync(string emailLogin);
    Task<Person?> GetByIdAsync(int id);
    Task<bool> EmailExistsAsync(string email);
    Task CreateAsync(Person person);
    //Task UpdateAsync(Person person);
}
