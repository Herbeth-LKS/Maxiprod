using HouseholdExpenses.Models;
using HouseholdExpenses.Services;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpenses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _service;
        public PeopleController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            await _service.AddAsync(person);
            return CreatedAtAction(nameof(GetAll), new { id = person.Id }, person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("totals")]
        public async Task<IActionResult> GetPeopleWithTotals()
        {
            var people = await _service.GetAllAsync();
            var result = people.Select(person => new
            {
                person.Id,
                person.Name,
                person.Age,
                TotalIncome = person.Transactions?.Where(t => t.Type == "income").Sum(t => t.Amount) ?? 0,
                TotalExpenses = person.Transactions?.Where(t => t.Type == "expense").Sum(t => t.Amount) ?? 0,
                Balance = (person.Transactions?.Where(t => t.Type == "income").Sum(t => t.Amount) ?? 0) -
                        (person.Transactions?.Where(t => t.Type == "expense").Sum(t => t.Amount) ?? 0)
            }).ToList();

            var totalIncome = result.Sum(p => p.TotalIncome);
            var totalExpenses = result.Sum(p => p.TotalExpenses);
            var totalBalance = totalIncome - totalExpenses;

            return Ok(new
            {
                data = result,
                Totals = new
                {
                    TotalIncome = totalIncome,
                    TotalExpenses = totalExpenses,
                    TotalBalance = totalBalance
                }
            });
        }

    }
}
