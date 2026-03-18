public class Wallet
{
    private double _balance;

    public Wallet(double initialBalance)
    {
        _balance = initialBalance;
    }

    public bool HasSufficientBalance(double amount)
    {
        return _balance >= amount;
    }

    public void Debit(double amount)
    {
        _balance -= amount;
    }
}