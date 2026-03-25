namespace HPFCBank.Models
{
    public class Customer
    {
        public int Id { get; }
        public string Name { get; }

        public Customer(int customerId, string name)
        {
            Id = customerId;
            Name = name;
        }
    }
}
