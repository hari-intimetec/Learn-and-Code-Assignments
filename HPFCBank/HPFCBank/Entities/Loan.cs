namespace HPFCBank.Entities
{
    public class Loan
    {
        public int Id { get; }
        public int CustomerId { get; }
        public decimal Principal { get; }
        public double InterestRate { get; }
        public int DurationInYears { get; }

        public Loan(int loadId,int customerId, decimal principal, double interestRate, int years)
        {
            Id = loadId;
            CustomerId = customerId;
            Principal = principal;
            InterestRate = interestRate;
            DurationInYears = years;
        }

        public decimal CalculateTotalPayable()
        {
            return Principal + (Principal * (decimal)InterestRate * DurationInYears);
        }

    }
}
