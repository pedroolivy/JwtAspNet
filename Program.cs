using System.Text;
using JwtAspNet;
using JwtAspNet.Models;
using JwtAspNet.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TokenService>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.PrivateKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/login", (TokenService service)
    =>
{
    return service.Create(new User(
        Id: 1,
        Name: "John Doe",
        Email: "teste@gmail.com",
        Image: "https://www.google.com",
        Password: "123456789",
        Roles: new [] { "student", "premium" }));
});

app.Run();
