using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Application.Contracts.Sessions.Models;

namespace Lab5.Application.Contracts.Accounts.Operations;

public static class ViewBalance
{
    public readonly record struct Request(SessionIdDto SessionId);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(MoneyDto Money) : Response;

        public sealed record CannotFindSession(string Message) : Response;

        public sealed record CannotViewBalance(string Message) : Response;

        public sealed record NoAccountIdInSession(string Message) : Response;

        public sealed record WrongAccountId(string Message) : Response;
    }
}