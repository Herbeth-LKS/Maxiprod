using HouseholdExpenses.Models;

namespace HouseholdExpenses.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task AddAsync(Person person);
        Task DeleteAsync(int id);
    }
}
