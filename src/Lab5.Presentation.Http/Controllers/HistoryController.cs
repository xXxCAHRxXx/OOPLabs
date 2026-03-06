using Lab5.Application.Contracts.Histories;
using Lab5.Application.Contracts.Histories.Models;
using Lab5.Application.Contracts.Histories.Operations;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("api/history")]
public class HistoryController : ControllerBase
{
    private readonly IHistoryService _historyService;

    public HistoryController(IHistoryService historyService)
    {
        _historyService = historyService;
    }

    [HttpPost("view")]
    public ActionResult<HistoryDto> ViewHistory(long accountId)
    {
        var request = new ViewHistory.Request(accountId);
        ViewHistory.Response response = _historyService.ViewHistory(request);

        return response switch
        {
            ViewHistory.Response.Success success => Ok(success.History),
            ViewHistory.Response.WrongAccountId wrongAccountId => NotFound(wrongAccountId.Message),
            _ => throw new UnreachableException(),
        };
    }
}