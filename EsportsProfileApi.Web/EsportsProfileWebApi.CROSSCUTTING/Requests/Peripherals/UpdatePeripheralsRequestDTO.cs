
namespace EsportsProfileWebApi.CROSSCUTTING
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class UpdatePeripheralsRequestDTO
    {
        [Required]
        public int Id { get; set; }

        public string? Mouse { get; set; }

        public string? MousePad { get; set; }

        public string? KeyBoard { get; set; }

        public string? HeadSet { get; set; }

        public string? Monitor { get; set; }
    }
}
