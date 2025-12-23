using Lab5.Application.Contracts.Accounts.Operations;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    CreateAccount.Response CreateAccount(CreateAccount.Request request);

    ViewBalance.Response ViewBalance(ViewBalance.Request request);

    WithDraw.Response WithDraw(WithDraw.Request request);

    Deposit.Response Deposit(Deposit.Request request);
}