using Microsoft.Extensions.DependencyInjection;
using System;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddSingleton<ATMWithdrawalService>();
        services.AddSingleton<ATMService>();

        var provider = services.BuildServiceProvider();

        var atmService = provider.GetService<ATMService>();

        atmService.PerformWithdrawal("ACC123", 500);
    }
}