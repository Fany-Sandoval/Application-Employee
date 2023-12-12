using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acti.Models
{
    public class Personas
    {
        public string id { get; set; }
        public string nombre { get; set; }

        public string apellidoPaterno { get; set; }

        public string? apellidoMaterno { get; set; }

        public string? telefono { get; set; }

        public string? email { get; set; }

        public string? password { get; set; }
    }
}
