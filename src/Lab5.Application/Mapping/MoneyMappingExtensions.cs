using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Mapping;

public static class MoneyMappingExtensions
{
    public static MoneyDto MapToDto(this Money money)
        => new MoneyDto(money.Value);
}