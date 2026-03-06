using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Lab5.Infrastructure.Persistence;

public class PersistenceContext : IPersistenceContext
{
    public PersistenceContext(IAccountRepository accounts, IHistoryRepository history, ISessionRepository sessions)
    {
        Accounts = accounts;
        History = history;
        Sessions = sessions;
    }

    public IAccountRepository Accounts { get; }

    public IHistoryRepository History { get; }

    public ISessionRepository Sessions { get; }
}