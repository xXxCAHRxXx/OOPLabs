using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Services;

internal sealed class AccountService : IAccountService
{
    private readonly IPersistenceContext _context;

    public AccountService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateAccount.Response CreateAccount(CreateAccount.Request request)
    {
        var sessionId = new SessionId(request.SessionId.Id);

        Session? session = _context.Sessions
            .Query(SessionQuery.Build(builder => builder.WithId(sessionId)))
            .SingleOrDefault();

        if (session is null)
            return new CreateAccount.Response.CannotFindSession("Error: cannot find session.");

        if (session.State.CanCreateAccount() is false)
            return new CreateAccount.Response.CannotCreateAccount("Error: no rights to create account.");

        var account = new Account(
            AccountId.Default,
            request.Name,
            new PinCode(request.PinCode),
            new Money(request.Balance));

        account = _context.Accounts.Add(account);

        return new CreateAccount.Response.Success(account.MapToDto());
    }

    public ViewBalance.Response ViewBalance(ViewBalance.Request request)
    {
        var sessionId = new SessionId(request.SessionId.Id);

        Session? session = _context.Sessions
            .Query(SessionQuery.Build(builder => builder.WithId(sessionId)))
            .SingleOrDefault();

        if (session is null)
            return new ViewBalance.Response.CannotFindSession("Error: cannot find session.");

        if (session.State.CanViewBalance() is false)
            return new ViewBalance.Response.CannotViewBalance("Error: no rights to view the balance.");

        if (session.AccountId is null)
            return new ViewBalance.Response.NoAccountIdInSession("Error: no account ID in session.");

        AccountId accountId = session.AccountId.Value;

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(accountId)))
            .SingleOrDefault();

        if (account is null)
            return new ViewBalance.Response.WrongAccountId("Error: account not found.");

        _context.History.Add(new AccountOperation(accountId, AccountOperationType.View, account.Balance));

        return new ViewBalance.Response.Success(account.Balance.MapToDto());
    }

    public WithDraw.Response WithDraw(WithDraw.Request request)
    {
        var sessionId = new SessionId(request.SessionId.Id);

        Session? session = _context.Sessions
            .Query(SessionQuery.Build(builder => builder.WithId(sessionId)))
            .SingleOrDefault();

        if (session is null)
            return new WithDraw.Response.CannotFindSession("Error: cannot find session.");

        if (session.State.CanWithDraw() is false)
            return new WithDraw.Response.CannotWithDraw("Error: no rights to withdraw the balance.");

        if (session.AccountId is null)
            return new WithDraw.Response.NoAccountIdInSession("Error: no account ID in session.");

        AccountId accountId = session.AccountId.Value;

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(accountId)))
            .SingleOrDefault();

        if (account is null)
            return new WithDraw.Response.WrongAccountId("Error: account not found.");

        var deductibleAmount = new Money(request.DeductibleAmount);
        if (account.CanWithDraw(deductibleAmount) is false)
            return new WithDraw.Response.UnsufficientFunds("Error: insufficient funds in the balance.");

        account.WithDraw(deductibleAmount);

        _context.History.Add(new AccountOperation(accountId, AccountOperationType.WithDraw, account.Balance));

        return new WithDraw.Response.Success(account.Balance.MapToDto());
    }

    public Deposit.Response Deposit(Deposit.Request request)
    {
        var sessionId = new SessionId(request.SessionId.Id);

        Session? session = _context.Sessions
            .Query(SessionQuery.Build(builder => builder.WithId(sessionId)))
            .SingleOrDefault();

        if (session is null)
            return new Deposit.Response.CannotFindSession("Error: cannot find session.");

        if (session.State.CanDeposit() is false)
            return new Deposit.Response.CannotDeposit("Error: no rights to deposit the balance.");

        if (session.AccountId is null)
            return new Deposit.Response.NoAccountIdInSession("Error: no account ID in session.");

        AccountId accountId = session.AccountId.Value;

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(accountId)))
            .SingleOrDefault();

        if (account is null)
            return new Deposit.Response.WrongAccountId("Error: account not found.");

        var amount = new Money(request.Amount);

        account.Deposit(amount);

        _context.History.Add(new AccountOperation(accountId, AccountOperationType.Deposit, account.Balance));

        return new Deposit.Response.Success(account.Balance.MapToDto());
    }
}