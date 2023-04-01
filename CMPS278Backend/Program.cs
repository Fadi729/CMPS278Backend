using System.Text;
using CMPS278Backend.Data;
using CMPS278Backend.Models;
using CMPS278Backend.Services;
using CMPS278Backend.Services.Contracts;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CMPS278DbContext>(options =>
                                                    options
                                                       .UseSqlServer(builder.Configuration
                                                                         ["ConnectionStrings:DevDB"]));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<CMPS278DbContext>();


JwtSettings jwtSettings = new();
builder.Configuration.Bind(nameof(JwtSettings), jwtSettings);
builder.Services.AddSingleton(jwtSettings);


builder.Services
       .AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme             = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
        })
       .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey         = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                ValidateIssuer           = false,
                ValidateAudience         = false,
                RequireExpirationTime    = false,
                ValidateLifetime         = true,
                ClockSkew                = TimeSpan.Zero
            };
            options.Events = new JwtBearerEvents
            {
                // Todo: Create Exception Handler
                // OnChallenge = _ => throw new UnauthorizedRequestException()
            };
        });

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
                      policyBuilder =>
                      {
                          policyBuilder
                             .WithOrigins("http://localhost:5173")
                             .AllowAnyHeader()
                             .AllowAnyMethod();
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();