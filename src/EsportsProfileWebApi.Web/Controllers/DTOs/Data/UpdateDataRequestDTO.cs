namespace EsportsProfileWebApi.Web.Controllers.DTOs.Data;

using System.ComponentModel.DataAnnotations;

public class UpdateDataRequestDTO
{
    public string? Id { get; set; } = string.Empty;

    [Required]
    public string? FirstName { get; set; }
    
    [Required]
    public string? LastName { get; set; }
    
    [Required]
    public string? Email { get;set; }
    
    [Required]
    public string? UserName { get; set; }
    
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
