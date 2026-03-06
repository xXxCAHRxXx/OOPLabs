using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions;
using Lab5.Domain.Sessions.States;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Services;

public class SessionService : ISessionService
{
    private readonly IPersistenceContext _context;
    private readonly Password _adminPassword;

    public SessionService(IPersistenceContext context, Password adminPassword)
    {
        _context = context;
        _adminPassword = adminPassword;
    }

    public CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request)
    {
        var password = new Password(request.AdminPassword);
        if (_adminPassword.IsEqual(password) is false)
            return new CreateAdminSession.Response.WrongPassword("Error: admin password does not match.");

        var session = new Session(SessionId.Default, new AdminSessionState(), null);
        session = _context.Sessions.Add(session);

        return new CreateAdminSession.Response.Success(session.Id.MapToDto());
    }

    public CreateUserSession.Response CreateUserSession(CreateUserSession.Request request)
    {
        var accountId = new AccountId(request.AccountId);
        Account? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(accountId)))
            .SingleOrDefault();

        if (account is null)
            return new CreateUserSession.Response.WrongAccountId("Error: account not found.");

        var pinCode = new PinCode(request.PinCode);
        if (account.PinCode.IsEqual(pinCode) is false)
            return new CreateUserSession.Response.WrongPinCode("Error: pin code does not match.");

        var session = new Session(SessionId.Default, new UserSessionState(), accountId);
        session = _context.Sessions.Add(session);

        return new CreateUserSession.Response.Success(session.Id.MapToDto());
    }
}