using HouseholdExpenses.Models;

namespace HouseholdExpenses.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllByPersonIdAsync(int personId);
        Task AddAsync(Transaction transaction);
    }
}
