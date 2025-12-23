namespace Lab5.Application.Contracts.Accounts.Models;

public sealed record AccountDto(long AccountId, string Name, int PinCode, MoneyDto Balance);
