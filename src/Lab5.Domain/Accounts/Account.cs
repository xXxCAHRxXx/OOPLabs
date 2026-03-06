using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Accounts;

public sealed class Account
{
    public AccountId Id { get; }

    public string Name { get; }

    public PinCode PinCode { get; }

    public Money Balance { get; private set; }

    public Account(AccountId id, string name, PinCode pinCode, Money balance)
    {
        Id = id;
        Name = name;
        PinCode = pinCode;
        Balance = balance;
    }

    public bool CanWithDraw(Money amount) => Balance >= amount;

    public void WithDraw(Money amount) => Balance -= amount;

    public void Deposit(Money amount) => Balance += amount;
}