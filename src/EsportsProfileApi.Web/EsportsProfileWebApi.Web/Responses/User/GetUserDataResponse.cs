using System.Security.Claims;

namespace EsportsProfileWebApi.Web.Responses.User;

public class GetUserDataResponse
{
    public string Token { get; set; } = string.Empty;

    public string? Id { get; set; }

    public string? Name { get; set; }
}
