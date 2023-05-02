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
    readonly GoogleSettings            _googleSettings;

    public UserService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings, GoogleSettings googleSettings)
    {
        _userManager    = userManager;
        _jwtSettings    = jwtSettings;
        _googleSettings = googleSettings;
    }


    public async Task<JwtToken> LoginAsync(string token, CancellationToken cancellationToken)
    {
        GoogleJsonWebSignature.Payload? googleUser =
            await GoogleJsonWebSignature.ValidateAsync(token, new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { _googleSettings.ClientId }
            });


        IdentityUser? user = await _userManager.FindByIdAsync(googleUser.Subject);

        if (user is null)
        {
            await RegisterAsync(googleUser, cancellationToken);
        }

        return AuthenticationTokenGeneratorAsync(googleUser);
    }

    async Task RegisterAsync(GoogleJsonWebSignature.Payload googleUser, CancellationToken cancellationToken)
    {
        IdentityResult creationResult = await _userManager.CreateAsync(new IdentityUser
        {
            Email    = googleUser.Email,
            UserName = googleUser.Email.Split("@")[0],
            Id       = googleUser.Subject
        });
    }

    JwtToken AuthenticationTokenGeneratorAsync(GoogleJsonWebSignature.Payload googleUser)
    {
        byte[]                  key          = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        JwtSecurityTokenHandler tokenHandler = new();

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier,   googleUser.Subject),
                new Claim(JwtRegisteredClaimNames.Email, googleUser.Email),
                new Claim(JwtRegisteredClaimNames.Name,  googleUser.Name),
                new Claim("picture",                     googleUser.Picture)
            }),


            Expires = googleUser.ExpirationTimeSeconds.HasValue
                ? DateTime.UnixEpoch.AddSeconds(googleUser.ExpirationTimeSeconds.Value)
                : DateTime.UtcNow.AddHours(1),

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                        SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);

        return new JwtToken { AccessToken = tokenHandler.WriteToken(token) };
    }
}