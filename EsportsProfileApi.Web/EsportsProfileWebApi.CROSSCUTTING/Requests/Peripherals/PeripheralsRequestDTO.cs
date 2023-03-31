namespace EsportsProfileWebApi.CROSSCUTTING.RequestDTOs.PeripheralDTOs
{
    using System.ComponentModel.DataAnnotations;
    public class PeripheralsRequestDTO
    {
        [Required]
        public string Alias { get; set; } = string.Empty;
    }
}
