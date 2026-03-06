using Lab5.Application.Contracts.Histories.Operations;

namespace Lab5.Application.Contracts.Histories;

public interface IHistoryService
{
    ViewHistory.Response ViewHistory(ViewHistory.Request request);
}