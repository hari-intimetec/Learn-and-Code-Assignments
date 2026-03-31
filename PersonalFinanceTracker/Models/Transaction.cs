using PersonalFinanceTracker.Enum;

namespace PersonalFinanceTracker.Models
{ 
    public class Transaction
    {
        public Guid Id { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }
}
