using EsportsProfileWebApi.DOMAIN;
using EsportsProfileWebApi.DOMAIN.Orchestrators.Settings;
using EsportsProfileWebApi.INFRASTRUCTURE;
using EsportsProfileWebApi.Web.Extensions;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOAuthAuthentication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDataOrchestrator, DataOrchestrator>();
builder.Services.AddSingleton<IDataRepository, DataRepository>();

var app = builder.Build();

app.MapGet("/", (HttpContext ctx) => {
    return ctx.User.Claims.Select(x => new { x.Type, x.Value }).ToList();
});

app.MapGet("/oauth/github-cb", (HttpContext ctx) =>
{
    return ctx.User.Claims.Select(x => new { x.Type, x.Value }).ToList();
});

app.MapGet("/login", (HttpContext ctx) =>
{
    return Results.Challenge(
        new AuthenticationProperties()
        {
            RedirectUri = "https://localhost:32774/"
        },
        authenticationSchemes: new List<string>() { "github" }
        );
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});

app.UseHttpsRedirection();
app.MapControllers();
app.Run();