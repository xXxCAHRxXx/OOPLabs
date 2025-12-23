using Lab5.Application.Contracts.Histories.Models;

namespace Lab5.Application.Contracts.Histories.Operations;

public static class ViewHistory
{
    public readonly record struct Request(long Id);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(HistoryDto History) : Response;

        public sealed record WrongAccountId(string Message) : Response;
    }
}