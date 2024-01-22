namespace MyProjects.BankAccountManagementSystem;

internal class CreditAccount : BankAccount
{
    public decimal CreditLimit { get; set; }
    public CreditAccount(string accountHolderName, decimal balance, decimal creditLimit)
    {
        AccountNumber = "CRA" + GenerateAccountID();
        AccountHolderName = accountHolderName;
        Balance = balance;
        CreditLimit = creditLimit;
    }

    public override void Withdraw(decimal money)
    {
        /*
            Please enter amount withdrawn:
            800
            Withdrawn E£800.00 from account CRA8087917 using credit. Balance: E£500.00, Credit: E£100.00
        */
        try
        {
            if(money <= 0) // -ve
                throw new ArgumentException("Error: Please enter +ve value more than zero!");
            else if(money <= Balance)
                Balance -= money;
            else if(money <= CreditLimit) // deduct from CreditLimit
                CreditLimit -= money;
            else
                throw new ArgumentException("Error: Limit reached!");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Withdrawn E£{money.ToString("F2")} from account {AccountNumber}. Balance: E£{Balance.ToString("F2")}, Credit: E£{CreditLimit.ToString("F2")}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch(ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public override void CheckBalance()
    {
        Console.WriteLine($"Account Type:\t{nameof(CreditAccount)}");
        Console.WriteLine($"Account Holder:\t{AccountHolderName}");
        Console.WriteLine($"Account Number:\t{AccountNumber}");
        Console.WriteLine($"Account Blance:\tE£{Balance.ToString("F2")}");
        Console.WriteLine("---------------------------------------");
    }
}