using System.Text;
using CMPS278Backend.Data;
using CMPS278Backend.Models;
using CMPS278Backend.Services;
using CMPS278Backend.Services.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CMPS278DbContext>(options =>
                                                    options
                                                       .UseSqlServer(builder.Configuration
                                                                            .GetConnectionString("CMPS278ProjectDB")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<CMPS278DbContext>();


JwtSettings jwtSettings = new();
builder.Configuration.Bind(nameof(JwtSettings), jwtSettings);
builder.Services.AddSingleton(jwtSettings);

GoogleSettings googleSettings = new();
builder.Configuration.Bind(nameof(GoogleSettings), googleSettings);
builder.Services.AddSingleton(googleSettings);


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
        });

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
                      policyBuilder =>
                      {
                          policyBuilder
                             .WithOrigins(builder.Configuration.GetSection("Cors:AllowedOrigins")
                                                 .Get<string[]>())
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