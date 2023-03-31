
namespace EsportsProfileWebApi.CROSSCUTTING
{
    using System.Diagnostics.CodeAnalysis;
    [ExcludeFromCodeCoverage]
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string? Firstname { get; set; } = string.Empty;

        public string? Lastname { get; set; } = string.Empty;

        public string? Alias { get; set; } = string.Empty;

        public string? Pass { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

    }
}
