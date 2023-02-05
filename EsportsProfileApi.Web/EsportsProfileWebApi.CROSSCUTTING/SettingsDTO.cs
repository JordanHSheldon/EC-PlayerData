using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsProfileWebApi.CROSSCUTTING
{
    public class SettingsDTO
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string purchaseLink{ get; set; } = string.Empty;

    }
}
