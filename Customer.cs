public class Customer : IPayable
{
    private readonly Wallet _wallet;
    private readonly string _firstName;
    private readonly string _lastName;

    public Customer(string firstName, string lastName, double initialBalance)
    {
        _firstName = firstName;
        _lastName = lastName;
        _wallet = new Wallet(initialBalance);
    }

    public String GetFirstName()
    {
         return firstName; 
    }
    public String GetLastName()
    {
         return lastName;
    }

    public bool Pay(double amount)
    {
        if (_wallet.HasSufficientBalance(amount))
        {
            _wallet.Debit(amount);
            return true;
        }
        return false;
    }
}