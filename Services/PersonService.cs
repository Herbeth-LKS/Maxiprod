using HouseholdExpenses.Models;
using HouseholdExpenses.Repositories;

namespace HouseholdExpenses.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Person>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task AddAsync(Person person) => await _repository.AddAsync(person);
        public async Task DeleteAsync(int id)
        {
            var person = await _repository.GetByIdAsync(id);
            if (person != null) await _repository.DeleteAsync(person);
        }
    }
}
