using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
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
    readonly JwtSettings _jwtSettings;
    readonly GoogleSettings _googleSettings;

    public UserService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings, GoogleSettings googleSettings)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings;
        _googleSettings = googleSettings;
    }


    public async Task<JwtToken> LoginAsync(string token, CancellationToken cancellationToken)
    {

        using HttpClient client = new();
        HttpRequestMessage request = new(HttpMethod.Get, "https://www.googleapis.com/oauth2/v3/userinfo");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await client.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Invalid Google Token");
        }

        var googleUser = await response.Content.ReadFromJsonAsync<GoogleResponse>(cancellationToken: cancellationToken);

        IdentityUser? user = await _userManager.FindByIdAsync(googleUser.Sub);

        if (user is null)
        {
            await RegisterAsync(googleUser, cancellationToken);
        }

        return AuthenticationTokenGeneratorAsync(googleUser);
    }

    async Task RegisterAsync(GoogleResponse googleUser, CancellationToken cancellationToken)
    {
        IdentityResult creationResult = await _userManager.CreateAsync(new IdentityUser
        {
            Email = googleUser.Email,
            UserName = googleUser.Email.Split("@")[0],
            Id = googleUser.Sub
        });
    }

    JwtToken AuthenticationTokenGeneratorAsync(GoogleResponse googleUser)
    {
        byte[] key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        JwtSecurityTokenHandler tokenHandler = new();

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, googleUser.Sub),
                new Claim(JwtRegisteredClaimNames.Email, googleUser.Email),
                new Claim(JwtRegisteredClaimNames.Name, googleUser.Name),
                new Claim("picture", googleUser.Picture)
            }),


            Expires = DateTime.UtcNow.AddHours(1),

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);

        return new JwtToken { AccessToken = tokenHandler.WriteToken(token) };
    }
}

class GoogleResponse
{
    public string Sub { get; set; }
    public string Name { get; set; }
    public string GivenName { get; set; }
    public string FamilyName { get; set; }
    public string Picture { get; set; }
    public string Email { get; set; }
}