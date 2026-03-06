namespace Lab5.Domain.Sessions.States;

public interface ISessionState
{
    SessionStates States { get; }

    bool CanViewBalance();

    bool CanWithDraw();

    bool CanDeposit();

    bool CanCreateAccount();
}