namespace MyProjects.BankAccountManagementSystem;

internal interface IInterestEarning
{
    decimal CalculateInterest();
    void ApplyInterest();
    decimal CalculateTotalInterest();
    
}