using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Models;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("api/session")]
public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("createAdminSession")]
    public ActionResult<SessionIdDto> CreateAdminSession(string adminPassword)
    {
        var request = new CreateAdminSession.Request(adminPassword);
        CreateAdminSession.Response response = _sessionService.CreateAdminSession(request);

        return response switch
        {
            CreateAdminSession.Response.Success success => Ok(success.SessionId),
            CreateAdminSession.Response.WrongPassword wrongPassword => Unauthorized(wrongPassword.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("createUserSession")]
    public ActionResult<SessionIdDto> CreateUserSession([FromBody] AddUserSessionRequest httpRequest)
    {
        var request = new CreateUserSession.Request(httpRequest.AccountId, httpRequest.PinCode);
        CreateUserSession.Response response = _sessionService.CreateUserSession(request);

        return response switch
        {
            CreateUserSession.Response.Success success => Ok(success.SessionId),
            CreateUserSession.Response.WrongAccountId wrongAccountId => NotFound(wrongAccountId.Message),
            CreateUserSession.Response.WrongPinCode wrongPinCode => Unauthorized(wrongPinCode.Message),
            _ => throw new UnreachableException(),
        };
    }
}