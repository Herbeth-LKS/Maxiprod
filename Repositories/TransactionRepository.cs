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
            var person = await _context.People.FirstOrDefaultAsync(p => p.Id == transaction.PersonId);
            
            if (person == null)
                throw new InvalidOperationException("Pessoa não encontrada.");

            var age = person.Age;

            if (age < 18 && transaction.Type == "income")
                throw new InvalidOperationException("Pessoas menores de 18 anos não podem registrar transações do tipo 'income'.");

            
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
