using AutoMapper;
using layer2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace layer2.Models
{
    
    public class UserService
    { 

    private readonly layer2Context _dataContext;

    public UserService(layer2Context dataContext)
    {
        _dataContext = dataContext;
    }

        public async Task<ActionResult<IEnumerable<User>>> GetAllAsync()
        {
            return await _dataContext.User.ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            var person = await _dataContext.User.FindAsync(id);
            return person;
        }

        public async Task CreatAsync(User person)
        {
            _dataContext.Add(person);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(User person)
        {
            var personToUpdate = await _dataContext.User.FindAsync(person.id);
            personToUpdate.name = person.name;
            personToUpdate.age = person.age;
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var personToDelete = await _dataContext.User.FindAsync(id);
            _dataContext.Remove(personToDelete);
            await _dataContext.SaveChangesAsync();
        }
    }
}
