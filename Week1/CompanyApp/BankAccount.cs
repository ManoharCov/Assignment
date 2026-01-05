using System;

class BankAccount
{
    //  Private fields
    private double balance;
    private string accountNumber;

    //  Property with validation for Account Number
    public string AccountNumber
    {
        get { return accountNumber; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length >= 8)
                accountNumber = value;
            else
                throw new ArgumentException("Invalid Account Number");
        }
    }

    //  Property with validation for Balance (read-only outside)
    public double Balance
    {
        get { return balance; }
        private set
        {
            if (value >= 0)
                balance = value;
            else
                throw new InvalidOperationException("Balance cannot be negative");
        }
    }

    //  Constructor
    public BankAccount(string accountNumber, double initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    // Deposit Method
    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive");

        Balance += amount;
        Console.WriteLine($"Deposited: {amount}");
    }

    // Withdraw Method
    public void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive");

        if (amount > Balance)
            throw new InvalidOperationException("Insufficient balance");

        Balance -= amount;
        Console.WriteLine($"Withdrawn: {amount}");
    }
}
