using CMPS278Backend.Models;

namespace CMPS278Backend.Services.Contracts;

public interface IUserService
{
    Task RegisterAsync();
    Task<JwtToken> LoginAsync(string token, CancellationToken cancellationToken);
}