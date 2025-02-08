using HouseholdExpenses.Models;
using HouseholdExpenses.Repositories;

namespace HouseholdExpenses.Services
{


    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Transaction>> GetAllByPersonIdAsync(int personId)
        {
            return await _repository.GetAllByPersonIdAsync(personId);
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _repository.AddAsync(transaction);
        }
    }
}
