using Lab5.Application.Contracts.Sessions.Models;

namespace Lab5.Application.Contracts.Sessions.Operations;

public static class CreateUserSession
{
    public readonly record struct Request(long AccountId, int PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(SessionIdDto SessionId) : Response;

        public sealed record WrongAccountId(string Message) : Response;

        public sealed record WrongPinCode(string Message) : Response;
    }
}