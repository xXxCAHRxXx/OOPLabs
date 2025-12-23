using Lab5.Application.Contracts.Histories.Models;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Mapping;

public static class AccountOperationMappingExtensions
{
    public static AccountOperationTypeDto MapToDto(this AccountOperationType accountOperationType)
        => accountOperationType switch
        {
            AccountOperationType.View => AccountOperationTypeDto.View,
            AccountOperationType.WithDraw => AccountOperationTypeDto.WithDraw,
            AccountOperationType.Deposit => AccountOperationTypeDto.Deposit,
            _ => throw new ArgumentOutOfRangeException(nameof(accountOperationType), accountOperationType, null),
        };

    public static AccountOperationDto MapToDto(this AccountOperation accountOperation)
        => new AccountOperationDto(accountOperation.Id.Value, accountOperation.OperationType.MapToDto(), accountOperation.Balance.MapToDto());
}