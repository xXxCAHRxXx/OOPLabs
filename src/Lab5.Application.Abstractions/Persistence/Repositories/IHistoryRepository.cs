using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Abstractions.Persistence.Repositories;

public interface IHistoryRepository
{
    void Add(AccountOperation operation);

    IEnumerable<AccountOperation> Query(AccountOperationQuery query);
}