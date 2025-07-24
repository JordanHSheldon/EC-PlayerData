namespace EsportsProfileWebApi.Web.Orchestrators;

using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Helpers;
using Models.User;
using Repository;

public struct DiscordUserResponse
{
    public string token_type {get;set;}
    public string access_token {get;set;}
    public int expires_in {get;set;}
    public string refresh_token {get;set;}
    public string scope {get;set;}
}

public struct DiscordUserData
{
    public string id {get;set;}
    public string username {get;set;}
    public string avatar {get;set;}
    public string discriminator {get;set;}
    public int public_flags {get;set;}
    public int flags {get;set;}
    public object banner {get;set;}
    public object accent_color {get;set;}
    public object global_name {get;set;}
    public object avatar_decoration_data {get;set;}
    public object collectibles {get;set;}
    public object banner_color {get;set;}
    public object clan {get;set;}
    public object primary_guild {get;set;}
    public bool mfa_enabled {get;set;}
    public string locale {get;set;}
    public int premium_type {get;set;}
    public string email {get;set;}
    public bool verified {get;set;}
}

public class UserOrchestrator(IUserRepository userRepository, IConfiguration config) : IUserOrchestrator
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new NotImplementedException();
    private readonly TokenBuilder _tokenBuilder = new(config);
    private const string NotFoundResult = "Not found";
    private const string ErrorResult = "Error creating user data";
    private const string UserExistsResult = "User already exists";
    private readonly string clientID = "1362549805502431262";
    private readonly string clientSecret = "nxaB5y27zdP6O_ULeRREpwaCkG46uWFJ";
    private readonly string redirectURI = "https://localhost:7191/api/user/DiscordRedirect";
    private readonly string tokenURL = "https://discord.com/api/oauth2/token";

    private readonly string userURL = "https://discord.com/api/users/@me";

    public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel request)
    {
        try
        {
            var user_id = await _userRepository.RegisterUser(request);

            if (user_id == -1)
            {
                return new UserRegisterResponseModel
                {
                    Result = UserExistsResult
                };
            }
            
            var claims = new List<Claim>
            {
                new("Id", user_id.ToString())
            };

            return new UserRegisterResponseModel
            {
                Result = await _tokenBuilder.BuildToken(claims)
            };
        }
        catch (Exception e)
        {
            return new UserRegisterResponseModel
            {
                Result = ErrorResult+e.Message
            };
        }
    }

    public async Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel request)
    {
        var user_id = await _userRepository.LoginUser(request);
        if (user_id == 0)
        {
            return new UserLoginResponseModel
            {
                Result = NotFoundResult
            };
        }

        var claims = new List<Claim> 
        {
            new ("Id", user_id.ToString())
        };

        return new UserLoginResponseModel
        {
            Result = await _tokenBuilder.BuildToken(claims)
        };
    }

    public async Task<UserLoginResponseModel> DiscordLogin(string code)
    {
        var values = new Dictionary<string, string>
        {
            { "client_id", clientID },
            { "client_secret", clientSecret },
            { "grant_type", "authorization_code" },
            { "code", code },
            { "scope", "identify%20email" },
            { "redirect_uri", redirectURI }
        };

        using var client = new HttpClient();
        var response = await client.PostAsync(tokenURL, new FormUrlEncodedContent(values));

        if (!response.IsSuccessStatusCode)
            return new UserLoginResponseModel{ Result = ErrorResult };

        var responseString = await response.Content.ReadAsStringAsync();

        var tokenResponse = JsonSerializer.Deserialize<DiscordUserResponse>(responseString);

        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, userURL);
        
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.access_token);
        
        var discordUserResponse = await client.SendAsync(requestMessage);
        var discordUserData = await discordUserResponse.Content.ReadAsStringAsync();
        var discordUser = JsonSerializer.Deserialize<DiscordUserData>(discordUserData);

        var userID = await _userRepository.DiscordLogin(discordUser);
        if (userID == 0)
        {
            return new UserLoginResponseModel
            {
                Result = NotFoundResult
            };
        }

        return new UserLoginResponseModel
        {
            Result = await _tokenBuilder.BuildToken([new Claim("DiscordId", discordUser.id)])
        };
    }
}