namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public sealed record Success<T>(T Value) : Result<T>;