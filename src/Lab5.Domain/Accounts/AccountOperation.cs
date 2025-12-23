using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Accounts;

public sealed class AccountOperation
{
    public AccountOperation(AccountId id, AccountOperationType operationType, Money balance)
    {
        Id = id;
        OperationType = operationType;
        Balance = balance;
    }

    public AccountId Id { get; }

    public AccountOperationType OperationType { get; }

    public Money Balance { get; }
}