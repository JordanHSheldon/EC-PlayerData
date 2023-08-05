
namespace EsportsProfileWebApi.CROSSCUTTING
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetPeripheralsRequestDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
