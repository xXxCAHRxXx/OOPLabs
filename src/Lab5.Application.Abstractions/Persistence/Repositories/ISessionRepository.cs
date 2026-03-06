using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Abstractions.Persistence.Repositories;

public interface ISessionRepository
{
    Session Add(Session session);

    IEnumerable<Session> Query(SessionQuery query);
}