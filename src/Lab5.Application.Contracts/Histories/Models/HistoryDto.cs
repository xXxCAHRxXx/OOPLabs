namespace Lab5.Application.Contracts.Histories.Models;

public sealed record HistoryDto(IReadOnlyCollection<AccountOperationDto> AccountOperations);