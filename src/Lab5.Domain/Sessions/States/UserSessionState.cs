namespace Lab5.Domain.Sessions.States;

public class UserSessionState : ISessionState
{
    public SessionStates States => SessionStates.User;

    public bool CanViewBalance() => true;

    public bool CanWithDraw() => true;

    public bool CanDeposit() => true;

    public bool CanCreateAccount() => false;
}