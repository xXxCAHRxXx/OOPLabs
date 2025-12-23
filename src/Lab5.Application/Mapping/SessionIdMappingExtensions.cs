using Lab5.Application.Contracts.Sessions.Models;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Mapping;

public static class SessionIdMappingExtensions
{
    public static SessionIdDto MapToDto(this SessionId id)
        => new SessionIdDto(id.Value);
}