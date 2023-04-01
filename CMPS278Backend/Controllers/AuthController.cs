using CMPS278Backend.Models;
using CMPS278Backend.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMPS278Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    readonly IUserService _auth;

    public AuthController(IUserService auth)
    {
        _auth = auth;
    }

    [HttpPost("login")]
    // [AllowAnonymous]
    public async Task<ActionResult<JwtToken>> Login(string token, CancellationToken cancellationToken)
    {
        return Ok(await _auth.LoginAsync(token, cancellationToken));
    }
}