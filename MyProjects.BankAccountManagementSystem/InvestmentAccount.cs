
namespace MyProjects.BankAccountManagementSystem;

internal class InvestmentAccount : BankAccount, IInterestEarning // 5%
{
    public InvestmentAccount(string accountHolderName, decimal balance)
    {
        AccountNumber = "INV" + GenerateAccountID();
        AccountHolderName = accountHolderName;
        Balance = balance;
    }

    public void ApplyInterest()
    {
        /*
            Interest earned on investment account INV5832179: E£34.50. New balance: E£724.50
        */
        Balance += CalculateInterest();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Interest earned on investment account {AccountNumber}: E£{CalculateInterest().ToString("F2")}. New balance: E£{Balance.ToString("F2")}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public decimal CalculateInterest()
    {
        return Balance * 0.05m;
    }

    public decimal CalculateTotalInterest()
    {
        Console.WriteLine("Please insert start date: (dd/MM/yyyy)");
        string line1 = Console.ReadLine();
        var splitLine1 = line1.Split('/');
        Console.WriteLine("Please insert end date: (dd/MM/yyyy)");
        string line2 = Console.ReadLine();
        var splitLine2 = line2.Split('/');
        
        var date1 = new DateOnly(Convert.ToInt32(splitLine1[2]), Convert.ToInt32(splitLine1[1]), Convert.ToInt32(splitLine1[0]));
        var date2 = new DateOnly(Convert.ToInt32(splitLine2[2]), Convert.ToInt32(splitLine2[1]), Convert.ToInt32(splitLine2[0]));
        
        int months = Math.Abs(((date1.Year - date2.Year) * 12) + date1.Month - date2.Month);
        decimal total = months * CalculateInterest();
        Console.WriteLine($"Total interest earned in {months} months: E£{total.ToString("F2")}");
        return total;
    }

    public override void CheckBalance()
    {
        /*
            Account Type: SavingsAccount
            AccountHolder: Mohammed Kareem

            Account SAV1640361 balance: E£600.00
        */
        Console.WriteLine($"Account Type:\t{nameof(InvestmentAccount)}");
        Console.WriteLine($"Account Holder:\t{AccountHolderName}");
        Console.WriteLine($"Account Number:\t{AccountNumber}");
        Console.WriteLine($"Account Blance:\tE£{Balance.ToString("F2")}");
        Console.WriteLine("---------------------------------------");
    }
}
