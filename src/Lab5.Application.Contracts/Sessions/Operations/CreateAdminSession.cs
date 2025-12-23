using Lab5.Application.Contracts.Sessions.Models;

namespace Lab5.Application.Contracts.Sessions.Operations;

public static class CreateAdminSession
{
    public readonly record struct Request(string AdminPassword);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(SessionIdDto SessionId) : Response;

        public sealed record WrongPassword(string Message) : Response;
    }
}