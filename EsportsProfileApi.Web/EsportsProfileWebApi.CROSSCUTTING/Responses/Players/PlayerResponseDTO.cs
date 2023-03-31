
namespace EsportsProfileWebApi.CROSSCUTTING
{
    using System.Diagnostics.CodeAnalysis;
    [ExcludeFromCodeCoverage]
    public class PlayerResponseDTO
    {
        public string Alias { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}