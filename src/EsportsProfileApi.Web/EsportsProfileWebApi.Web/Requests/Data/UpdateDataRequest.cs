namespace EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using System.ComponentModel.DataAnnotations;

public class UpdateDataRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public double Sensitivity { get; set; }

    [Required]
    public int Dpi { get; set; }

    [Required]
    public int ResolutionX { get; set; }

    [Required]
    public int ResolutionY { get; set; }

    [Required]
    public string ResolutionType { get; set; }

    [Required]
    public string? Mouse { get; set; }

    [Required]
    public string? MousePad { get; set; }

    [Required]
    public string? KeyBoard { get; set; }

    [Required]
    public string? HeadSet { get; set; }

    [Required]
    public string? Monitor { get; set; }
}