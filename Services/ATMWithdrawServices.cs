using System;

public class ATMWithdrawalService
{
    public void Withdraw(string accountId, double amount)
    {
        var handle = GetValidHandle();
        var record = GetActiveDevice(handle);

        EnsureNetworkAvailable(record);
        EnsureSufficientBalance(accountId, amount);

        DispenseCash(handle, amount);
    }

    private DeviceHandle GetValidHandle()
    {
        var handle = GetHandle();

        if (!handle.IsValid)
            throw new DeviceNotFoundException();

        return handle;
    }

    private DeviceRecord GetActiveDevice(DeviceHandle handle)
    {
        var record = RetrieveDeviceRecord(handle);

        if (record.IsLocked)
            throw new DeviceLockedException();

        return record;
    }

    private void EnsureNetworkAvailable(DeviceRecord record)
    {
        if (!record.IsWifiConnected)
            throw new NetworkConnectionException();
    }

    private void EnsureSufficientBalance(string accountId, double amount)
    {
        var balance = GetBalance(accountId);

        if (balance < amount)
            throw new InsufficientFundsException();
    }

    private DeviceHandle GetHandle()
    {
        return new DeviceHandle(true);
    }

    private DeviceRecord RetrieveDeviceRecord(DeviceHandle handle)
    {
        return new DeviceRecord
        {
            IsLocked = false,
            IsWifiConnected = true
        };
    }

    private double GetBalance(string accountId)
    {
        return 1000;
    }

    private void DispenseCash(DeviceHandle handle, double amount)
    {
        Console.WriteLine($"Dispensed {amount}");
    }
}