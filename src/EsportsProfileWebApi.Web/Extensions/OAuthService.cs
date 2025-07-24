namespace EsportsProfileWebApi.Web.Extensions;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

public static class OAuthService
{
    public static IServiceCollection AddOAuthAuthentication(this IServiceCollection services)
    {
        // gonna change to be google and steam.
        services.AddAuthentication("cookie")
        .AddCookie("cookie")
        .AddOAuth("github", options =>
        {
            options.SignInScheme = "cookie";
            options.ClientId = "";
            options.ClientSecret = ""; // get from configuration.

            options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
            options.TokenEndpoint = "https://github.com/login/oauth/access_token";
            options.CallbackPath = "/oauth/github-cb";
            options.SaveTokens = true;
            options.UserInformationEndpoint = "https://api.github.com/user";

            options.ClaimActions.MapJsonKey("sub", "id");
            options.ClaimActions.MapJsonKey(ClaimTypes.Name, "login");
            options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");

            options.Events.OnCreatingTicket = async context =>
            {
                // store in the db for a better user exp / may need to research this piece more
                using var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
                using var result = await context.Backchannel.SendAsync(request);
                var user = await result.Content.ReadFromJsonAsync<JsonElement>();
                context.RunClaimActions(user);
            };
        });

        return services;
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, WebApplicationBuilder builder)
    {
        var config = builder.Configuration;
        var key = Encoding.UTF8.GetBytes(config["Authentication:Key"] ?? throw new());
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.MapInboundClaims = false;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = config["Authentication:Issuer"],
                ValidAudience = config["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true
            };
        });

        services.AddAuthorization();
        return services;
    }
}