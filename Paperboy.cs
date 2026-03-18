public class Paperboy
{
    public void CollectPayment(IPayable customer, double amount)
    {
        if (!customer.Pay(amount))
        {
            Console.WriteLine($"Payment of {customer.GetFirstName()} is failed due to insufficient balance.");
            return;
        }
        Console.WriteLine($"{customer.GetFirstName()} has paid Rs.{amount}.");
    }
}