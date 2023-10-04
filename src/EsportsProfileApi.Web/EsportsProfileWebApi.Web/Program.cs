using EsportsProfileWebApi.DOMAIN;
using EsportsProfileWebApi.DOMAIN.Orchestrators.Settings;
using EsportsProfileWebApi.INFRASTRUCTURE;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// key creation
var rsaKey = RSA.Create();
// replace the File.ReadAllBytes("key") with a cloud provided key generation.
rsaKey.ImportRSAPrivateKey(File.ReadAllBytes("key"), out _);

// JWT Authentication Configuration
builder.Services.AddAuthentication("jwt")
    .AddJwtBearer("jwt", opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidateIssuer = false
        };

        opts.Events = new JwtBearerEvents()
        {
            OnMessageReceived = (ctx) => 
            {
                if (ctx.Request.Query.ContainsKey("t"))
                {
                    ctx.Token = ctx.Request.Query["t"];
                }
                return Task.CompletedTask;
            }
        };

        opts.Configuration = new OpenIdConnectConfiguration()
        {
            SigningKeys =
            {
                new RsaSecurityKey(rsaKey)
            }
        };

        opts.MapInboundClaims = false;
    });

//Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "You api title", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
                {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
});

// dependency injection on these custom services
builder.Services.AddSingleton<IDataOrchestrator, DataOrchestrator>();
builder.Services.AddSingleton<IDataRepository, DataRepository>();

var app = builder.Build();
app.UseAuthentication();


app.MapGet("/", (HttpContext ctx) => ctx.User.FindFirst("name")?.Value ?? "Empty");

// login controller
app.MapGet("/jwt", () =>
{
    var handler = new JsonWebTokenHandler();
    var key = new RsaSecurityKey(rsaKey);
    var token = handler.CreateToken(new SecurityTokenDescriptor
    {
        Issuer = "https://localhost:32786/",
        // setting the claims
        Subject = new ClaimsIdentity(new[] 
        {
            new Claim("sub", Guid.NewGuid().ToString()),// using a db call go down and get the id for this by username / password.
            new Claim("name", "Anton")
        }),
        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256)
    });

    return token;
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