using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Contracts.Sessions.Models;
using Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("create")]
    public ActionResult<AccountDto> CreateAccount([FromBody] CreateAccountRequest httpRequest)
    {
        var request = new CreateAccount.Request(
            new SessionIdDto(httpRequest.SessionId),
            httpRequest.Name,
            httpRequest.PinCode,
            httpRequest.Balance);
        CreateAccount.Response response = _accountService.CreateAccount(request);

        return response switch
        {
            CreateAccount.Response.Success success => Ok(success.Account),
            CreateAccount.Response.CannotFindSession cannotFindSession => Unauthorized(cannotFindSession.Message),
            CreateAccount.Response.CannotCreateAccount cannotCreateAccount => Forbid(cannotCreateAccount.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("viewBalance")]
    public ActionResult<MoneyDto> ViewBalance(Guid sessionId)
    {
        var request = new ViewBalance.Request(new SessionIdDto(sessionId));
        ViewBalance.Response response = _accountService.ViewBalance(request);

        return response switch
        {
            ViewBalance.Response.Success success => Ok(success.Money),
            ViewBalance.Response.CannotFindSession cannotFindSession => Unauthorized(cannotFindSession.Message),
            ViewBalance.Response.CannotViewBalance cannotViewBalance => Forbid(cannotViewBalance.Message),
            ViewBalance.Response.NoAccountIdInSession noAccountIdInSession => BadRequest(noAccountIdInSession.Message),
            ViewBalance.Response.WrongAccountId wrongAccountId => NotFound(wrongAccountId.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("withDraw")]
    public ActionResult<MoneyDto> WithDraw([FromBody] WithDrawRequest httpRequest)
    {
        var request = new WithDraw.Request(new SessionIdDto(httpRequest.SessionId), httpRequest.DeductibleAmount);
        WithDraw.Response response = _accountService.WithDraw(request);

        return response switch
        {
            WithDraw.Response.Success success => Ok(success.Money),
            WithDraw.Response.CannotFindSession cannotFindSession => Unauthorized(cannotFindSession.Message),
            WithDraw.Response.CannotWithDraw cannotWithDraw => BadRequest(cannotWithDraw.Message),
            WithDraw.Response.NoAccountIdInSession noAccountIdInSession => BadRequest(noAccountIdInSession.Message),
            WithDraw.Response.WrongAccountId wrongAccountId => NotFound(wrongAccountId.Message),
            WithDraw.Response.UnsufficientFunds unsufficientFunds => Conflict(unsufficientFunds.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("deposit")]
    public ActionResult<MoneyDto> Deposit([FromBody] DepositRequest httpRequest)
    {
        var request = new Deposit.Request(new SessionIdDto(httpRequest.SessionId), httpRequest.Amount);
        Deposit.Response response = _accountService.Deposit(request);

        return response switch
        {
            Deposit.Response.Success success => Ok(success.Money),
            Deposit.Response.CannotFindSession cannotFindSession => Unauthorized(cannotFindSession.Message),
            Deposit.Response.CannotDeposit cannotDeposit => BadRequest(cannotDeposit.Message),
            Deposit.Response.NoAccountIdInSession noAccountIdInSession => BadRequest(noAccountIdInSession.Message),
            Deposit.Response.WrongAccountId wrongAccountId => NotFound(wrongAccountId.Message),
            _ => throw new UnreachableException(),
        };
    }
}