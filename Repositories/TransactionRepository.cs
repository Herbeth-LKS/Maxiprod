using HouseholdExpenses.Data;
using HouseholdExpenses.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdExpenses.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetAllByPersonIdAsync(int personId) => 
            await _context.Transactions.Where(t => t.PersonId == personId).ToListAsync();

        public async Task AddAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
