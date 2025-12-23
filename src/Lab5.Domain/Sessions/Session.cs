using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions.States;

namespace Lab5.Domain.Sessions;

public class Session
{
    public Session(SessionId sessionId, ISessionState state, AccountId? accountId = null)
    {
        Id = sessionId;
        State = state;
        AccountId = accountId;
    }

    public SessionId Id { get; }

    public ISessionState State { get; private set; }

    public AccountId? AccountId { get; private set; }
}