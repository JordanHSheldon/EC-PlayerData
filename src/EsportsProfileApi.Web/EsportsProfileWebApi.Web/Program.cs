using EsportsProfileWebApi.DOMAIN;
using EsportsProfileWebApi.DOMAIN.Orchestrators.Settings;
using EsportsProfileWebApi.INFRASTRUCTURE;
using EsportsProfileWebApi.Web.Extensions;
using Microsoft.AspNetCore.Authentication;

// Initial
var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddOAuthAuthentication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDataOrchestrator, DataOrchestrator>();
builder.Services.AddSingleton<IDataRepository, DataRepository>();

var app = builder.Build();

app.UseAuthentication();

// just for testing jwt authentication for now.
app.MapGet("/", (HttpContext ctx) => {
    return ctx.User.Claims.Select(x => new { x.Type, x.Value}).ToList();
});

app.MapGet("/oauth/github-cb", (HttpContext ctx) => {
    return ctx.User.Claims.Select(x => new { x.Type, x.Value }).ToList();
});

app.MapGet("/login", (HttpContext ctx) => {
return Results.Challenge(
    new AuthenticationProperties()
    {
        RedirectUri = "https://localhost:32774/"
    },
    authenticationSchemes: new List<string>() { "github" }
    );
});

//Configure the HTTP request pipeline.
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

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();