using HouseholdExpenses.Models;

namespace HouseholdExpenses.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(int id);
        Task AddAsync(Person person);
        Task DeleteAsync(Person person);
    }
}
