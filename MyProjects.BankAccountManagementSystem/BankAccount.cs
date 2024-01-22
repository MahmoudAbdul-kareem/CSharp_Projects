namespace MyProjects.BankAccountManagementSystem;

internal abstract class BankAccount
{
    public string? AccountHolderName { get; set; }
    public string?  AccountNumber { get; protected set; } // childs only can set
    public decimal Balance { get; set; }
    
    public void Deposit(decimal money)
    {
        /*
            Please enter amount deposited:
            10
            Deposited E£10.00 into account SAV1640361. New balance: E£610.00
        */
        try
        {
            if(money <= 0) // -ve
                throw new ArgumentException("Error: Please enter +ve value more than zero!");
            // operation 
            Balance += money;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Deposited E£{money.ToString("F2")} into account {AccountNumber}. New balance: E£{Balance.ToString("F2")}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch(ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public virtual void Withdraw(decimal money)
    {
        /* 
            Please enter amount withdrawn:
            500
            Withdrawn E£500.00 from account SAV1640361. New balance: E£110.00
        */
        try
        {
            if(money <= 0) // -ve
                throw new ArgumentException("Error: Please enter +ve value more than zero!");
            else if(money > Balance)
                throw new ArgumentException($"Error: Insufficient funds in account {AccountNumber}!");
            else
            {
                // operation 
                Balance -= money;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Withdrawn E£{money.ToString("F2")} from account {AccountNumber}. New balance: E£{Balance.ToString("F2")}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        catch(ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public abstract void CheckBalance();

    protected static string GenerateAccountID()
    {
        var random = new Random();
        // Generate a random number between 1000000 (inclusive) and 9999999 (inclusive)
        string AccountID = random.Next(1000000, 10000000).ToString();
        return AccountID;
    }
}