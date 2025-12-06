namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Exceptions;

public class DisconnectException : Exception
{
    public DisconnectException(string message) : base(message)
    { }
}