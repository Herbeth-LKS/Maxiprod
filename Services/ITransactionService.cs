using HouseholdExpenses.Models;

namespace HouseholdExpenses.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllByPersonIdAsync(int personId);
        Task AddAsync(Transaction transaction);
    }


}
