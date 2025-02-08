using HouseholdExpenses.Data;
using HouseholdExpenses.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdExpenses.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllAsync() => await _context.People.Include(p => p.Transactions).ToListAsync();
        public async Task<Person?> GetByIdAsync(int id) => await _context.People.Include(p => p.Transactions).FirstOrDefaultAsync(p => p.Id == id);
        public async Task AddAsync(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Person person)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
