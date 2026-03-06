using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly Dictionary<SessionId, Session> _values = [];

    public Session Add(Session session)
    {
        session = new Session(
            new SessionId(Guid.NewGuid()),
            session.State,
            session.AccountId);

        _values.Add(session.Id, session);
        return session;
    }

    public IEnumerable<Session> Query(SessionQuery query)
    {
        return _values.Values
            .Where(x => query.Ids is [] || query.Ids.Contains(x.Id));
    }
}