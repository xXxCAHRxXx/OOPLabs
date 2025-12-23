using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Domain.Accounts;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly List<AccountOperation> _values = [];

    public void Add(AccountOperation operation)
    {
        _values.Add(operation);
    }

    public IEnumerable<AccountOperation> Query(AccountOperationQuery query)
    {
        return _values
            .Where(x => query.Ids is [] || query.Ids.Contains(x.Id));
    }
}