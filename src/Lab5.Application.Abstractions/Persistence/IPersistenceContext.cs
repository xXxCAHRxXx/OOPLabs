using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Lab5.Application.Abstractions.Persistence;

public interface IPersistenceContext
{
    IAccountRepository Accounts { get; }

    IHistoryRepository History { get; }

    ISessionRepository Sessions { get; }
}