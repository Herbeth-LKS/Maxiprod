using HouseholdExpenses.Models;
using HouseholdExpenses.Services;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpenses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _service;
        public TransactionsController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet("{personId}")]
        public async Task<IActionResult> GetByPerson(int personId)
        {
            var transactions = await _service.GetAllByPersonIdAsync(personId);
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            await _service.AddAsync(transaction);
            return CreatedAtAction(nameof(GetByPerson), new { personId = transaction.PersonId }, transaction);
        }
    }
}
