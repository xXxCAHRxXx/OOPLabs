namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public sealed record Failure<T>(IBusinessError Error) : Result<T>;