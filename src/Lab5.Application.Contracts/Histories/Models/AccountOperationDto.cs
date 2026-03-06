using Lab5.Application.Contracts.Accounts.Models;

namespace Lab5.Application.Contracts.Histories.Models;

public sealed record AccountOperationDto(long Id, AccountOperationTypeDto AccountOperation, MoneyDto Money);