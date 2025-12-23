using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Application.Contracts.Sessions.Models;

namespace Lab5.Application.Contracts.Accounts.Operations;

public static class CreateAccount
{
    public readonly record struct Request(SessionIdDto SessionId, string Name, int PinCode, decimal Balance);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(AccountDto Account) : Response;

        public sealed record CannotFindSession(string Message) : Response;

        public sealed record CannotCreateAccount(string Message) : Response;
    }
}