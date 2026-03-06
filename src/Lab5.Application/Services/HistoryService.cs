using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Contracts.Histories;
using Lab5.Application.Contracts.Histories.Models;
using Lab5.Application.Contracts.Histories.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Services;

internal sealed class HistoryService : IHistoryService
{
    private readonly IPersistenceContext _context;

    public HistoryService(IPersistenceContext context)
    {
        _context = context;
    }

    public ViewHistory.Response ViewHistory(ViewHistory.Request request)
    {
        var accountId = new AccountId(request.Id);

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(accountId)))
            .SingleOrDefault();

        if (account is null)
            return new ViewHistory.Response.WrongAccountId("Error: cannot find account.");

        var history = _context.History
            .Query(AccountOperationQuery.Build(builder => builder.WithId(accountId)))
            .Select(operation => operation.MapToDto())
            .ToList();

        return new ViewHistory.Response.Success(new HistoryDto(history));
    }
}