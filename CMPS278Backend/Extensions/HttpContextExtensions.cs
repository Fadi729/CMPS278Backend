using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace CMPS278Backend.Extensions;

public static class HttpContextExtensions
{
    public static string GetUserId(this HttpContext httpContext)
    {
        return httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException();
    }
}