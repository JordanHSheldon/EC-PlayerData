using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsProfileWebApi.CROSSCUTTING
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string? Firstname { get; set; } = string.Empty;

        public string? Lastname { get; set; } = string.Empty;

        public string? Alias { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        //public List<string> strings { get; set; } = new List<string>();
    }
}
