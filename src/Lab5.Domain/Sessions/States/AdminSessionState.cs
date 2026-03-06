namespace Lab5.Domain.Sessions.States;

public class AdminSessionState : ISessionState
{
    public SessionStates States => SessionStates.Admin;

    public bool CanViewBalance() => false;

    public bool CanWithDraw() => false;

    public bool CanDeposit() => false;

    public bool CanCreateAccount() => true;
}