namespace MyProjects.BankAccountManagementSystem;

internal class CheckingAccount : BankAccount
{
    public CheckingAccount(string accountHolderName, decimal balance)
    {
        AccountNumber = "CHA" + GenerateAccountID();
        AccountHolderName = accountHolderName;
        Balance = balance;
    }
    public override void CheckBalance()
    {
        Console.WriteLine($"Account Type:\t{nameof(CheckingAccount)}");
        Console.WriteLine($"Account Holder:\t{AccountHolderName}");
        Console.WriteLine($"Account Number:\t{AccountNumber}");
        Console.WriteLine($"Account Blance:\tE£{Balance.ToString("F2")}");
        Console.WriteLine("---------------------------------------");
    }
}
