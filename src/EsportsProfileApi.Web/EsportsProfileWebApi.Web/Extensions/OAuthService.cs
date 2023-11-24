namespace EsportsProfileWebApi.Web.Extensions;

using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
using System.Security.Claims;
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

            options.ClaimActions.MapJsonKey("sub","id");
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
}