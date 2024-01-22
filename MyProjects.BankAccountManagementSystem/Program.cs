using MyProjects.BankAccountManagementSystem;

Console.Clear(); // clear the terminal

//     var inv = new CreditAccount("Mahmoud Abdul_kareem", 800, 1000);
//     inv.CheckBalance();
//     Console.WriteLine("Please enter amount deposited:");
//     decimal value = Convert.ToDecimal(Console.ReadLine());
//     inv.Deposit(value);
// while(true)
// {
//     Console.WriteLine("Please enter amount Withdrawn:");
//     value = Convert.ToDecimal(Console.ReadLine());
//     inv.Withdraw(value);
// }

/*********** Driver Code ***********/
Console.WriteLine("Enter details for Savings Account (HolderName, Balance):");
var holderName = Console.ReadLine();
var balance = Convert.ToDecimal(Console.ReadLine());
var sav = new SavingsAccount(holderName, balance);

Console.WriteLine("Enter details for Checking Account (HolderName, Balance):");
holderName = Console.ReadLine();
balance = Convert.ToDecimal(Console.ReadLine());
var cha = new CheckingAccount(holderName, balance);

Console.WriteLine("Enter details for Investment Account (HolderName, Balance):");
holderName = Console.ReadLine();
balance = Convert.ToDecimal(Console.ReadLine());
var inv = new InvestmentAccount(holderName, balance);

Console.WriteLine("Enter details for Credit Account (HolderName, Balance, Credit Limit):");
holderName = Console.ReadLine();
balance = Convert.ToDecimal(Console.ReadLine());
var credit = Convert.ToDecimal(Console.ReadLine());
var cra = new CreditAccount(holderName, balance, credit);

/*---------- Savings Account ----------*/
sav.CheckBalance();
Console.WriteLine("Please enter amount deposited:");
decimal value = Convert.ToDecimal(Console.ReadLine());
sav.Deposit(value);

Console.WriteLine("Please enter amount Withdrawn:");
value = Convert.ToDecimal(Console.ReadLine());
sav.Withdraw(value);

Console.WriteLine("Calculating interest between two dates");
sav.CalculateTotalInterest();

/*---------- Checking Account ----------*/
cha.CheckBalance();
Console.WriteLine("Please enter amount deposited:");
value = Convert.ToDecimal(Console.ReadLine());
cha.Deposit(value);

Console.WriteLine("Please enter amount Withdrawn:");
value = Convert.ToDecimal(Console.ReadLine());
cha.Withdraw(value);

/*---------- Investment Account ----------*/
inv.CheckBalance();
Console.WriteLine("Please enter amount deposited:");
value = Convert.ToDecimal(Console.ReadLine());
inv.Deposit(value);

Console.WriteLine("Please enter amount Withdrawn:");
value = Convert.ToDecimal(Console.ReadLine());
inv.Withdraw(value);

Console.WriteLine("Calculating interest between two dates");
inv.CalculateTotalInterest();
inv.ApplyInterest();

/*---------- Credit Account ----------*/
cra.CheckBalance();
Console.WriteLine("Please enter amount deposited:");
value = Convert.ToDecimal(Console.ReadLine());
cra.Deposit(value);

Console.WriteLine("Please enter amount Withdrawn:");
value = Convert.ToDecimal(Console.ReadLine());
cra.Withdraw(value);


/*************************     Apply These Changes     *************************/
/*
    NOTES:
        8. When testing in Main method, make sure you create an object of each type and add them all to one list.
    
    Hints:
        Use the is operator to check if an object is of a particular type before performing a specific operation. And use patterns to cast the object to a reference if the type is matched.

    Links:
        Microsoft Documentation on the is Operator
        Microsoft Documentation on Declaration Pattern

    Extension Methods:
        In C#, an extension method is a static method that is defined in a static class.
        It provides a way to add new methods to existing types without modifying their source code.
        Extension methods are especially useful for adding functionality to types that you don't control, 
        such as types from third-party libraries or built-in .NET types.
*/
