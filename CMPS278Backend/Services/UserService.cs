using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CMPS278Backend.Models;
using CMPS278Backend.Services.Contracts;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace CMPS278Backend.Services;

public class UserService : IUserService
{
    readonly UserManager<IdentityUser> _userManager;
    readonly JwtSettings               _jwtSettings;

    public UserService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings;
    }

    public Task RegisterAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<JwtToken> LoginAsync(string token, CancellationToken cancellationToken)
    {
        GoogleJsonWebSignature.Payload? googleUser =
            await GoogleJsonWebSignature.ValidateAsync(token, new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new[] { "841180126145-d7m3288q5uuvij6ber21tnjsvd2kke59.apps.googleusercontent.com" }
            });

        IdentityUser user = new()
        {
            Email    = googleUser.Email,
            UserName = googleUser.Email.Split("@")[0],
            Id       = googleUser.Subject
        };

        IdentityResult creationResult = await _userManager.CreateAsync(user);

        // if (creationResult.Succeeded)
        // {
        return AuthenticationTokenGeneratorAsync(googleUser);
        // }
    }

    JwtToken AuthenticationTokenGeneratorAsync(GoogleJsonWebSignature.Payload googleUser)
    {
        byte[]                  key          = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        JwtSecurityTokenHandler tokenHandler = new();

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", googleUser.Subject),
            }),


            Expires = googleUser.ExpirationTimeSeconds.HasValue
                ? DateTimeOffset.FromUnixTimeSeconds(googleUser.ExpirationTimeSeconds.Value).DateTime.AddMinutes(1)
                : DateTime.UtcNow.AddHours(1),

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                        SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);

        return new JwtToken { AccessToken = tokenHandler.WriteToken(token) };
    }
}