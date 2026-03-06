using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Mapping;
using Lab5.Application.Services;
using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions;
using Lab5.Domain.Sessions.States;
using Lab5.Domain.ValueObjects;
using Lab5.Infrastructure.Persistence;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class CashMachineTests
{
    private readonly AccountService _accountService;
    private readonly Account _account;

    public CashMachineTests()
    {
        _account = new Account(new AccountId(1), "User", new PinCode(1111), new Money(1000));
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository.Query(Arg.Any<AccountQuery>()).Returns([_account]);

        IHistoryRepository historyRepository = Substitute.For<IHistoryRepository>();

        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        sessionRepository.Query(Arg.Any<SessionQuery>()).Returns(
            [new Session(SessionId.Default, new UserSessionState(), _account.Id)]);

        IPersistenceContext context = new PersistenceContext(accountRepository, historyRepository, sessionRepository);

        _accountService = new AccountService(context);
    }

    [Fact]
    public void WithDraw_WithDrawMoneyFromAccount_Success()
    {
        Money startBalance = _account.Balance;
        WithDraw.Response sucessResultWithDraw = _accountService.WithDraw(new WithDraw.Request(
            SessionId.Default.MapToDto(),
            startBalance.Value - 1));
        Assert.IsType<WithDraw.Response.Success>(sucessResultWithDraw);

        ViewBalance.Response resultViewBalance = _accountService.ViewBalance(new ViewBalance.Request(
            SessionId.Default.MapToDto()));
        Assert.IsType<ViewBalance.Response.Success>(resultViewBalance);
        var balance = (ViewBalance.Response.Success)resultViewBalance;
        Assert.Equal(1, _account.Balance.Value);
    }

    [Fact]
    public void WithDraw_WithDrawMoneyFromAccount_Failure()
    {
        Money startBalance = _account.Balance;
        WithDraw.Response failureResultWithDraw = _accountService.WithDraw(new WithDraw.Request(
            SessionId.Default.MapToDto(),
            startBalance.Value + 1));
        Assert.IsType<WithDraw.Response.UnsufficientFunds>(failureResultWithDraw);
    }

    [Fact]
    public void Deposit_WithDrawMoneyFromAccount_Success()
    {
        Money startBalance = _account.Balance;
        decimal depositValue = 777;
        Deposit.Response successResultWithDraw = _accountService.Deposit(new Deposit.Request(
            SessionId.Default.MapToDto(),
            depositValue));
        Assert.IsType<Deposit.Response.Success>(successResultWithDraw);
        Assert.Equal(startBalance.Value + depositValue, _account.Balance.Value);
    }
}