using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsProfileWebApi.CROSSCUTTING
{
    public class PlayerCreationDTO
    {
        [Required]
        public string? Firstname { get; set; } 

        [Required]
        public string? Lastname { get; set; } 

        [Required]
        public string? Alias { get; set; } 
        
        [Required]
        public string? Email{ get; set; } 

        [Required]
        public string? Password { get; set; } 

    }
}
