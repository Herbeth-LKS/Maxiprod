using System.Text.Json.Serialization;

namespace HouseholdExpenses.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Type { get; set; } = string.Empty; // "income" or "expense"
        public int PersonId { get; set; }

        [JsonIgnore]
        public Person? Person { get; set; }
    }
}
