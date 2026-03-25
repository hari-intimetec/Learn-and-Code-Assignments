using System;

public class ATMService
{
    private readonly ATMWithdrawalService _withdrawalService;

    public ATMService(ATMWithdrawalService withdrawalService)
    {
        _withdrawalService = withdrawalService;
    }

    public void PerformWithdrawal(string accountId, double amount)
    {
        try
        {
            _withdrawalService.Withdraw(accountId, amount);
            Console.WriteLine("Withdrawal successful.");
        }
        catch (DeviceLockedException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (NetworkConnectionException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (DeviceNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Unexpected error occurred.");
        }
    }
}