using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acti.Models
{
    public class Empleos
    {
        public string id_empleo { get; set; }
        public string puesto { get; set; }

        public string empresa { get; set; }

        public string salario { get; set; }

        public string? descripcion { get; set; }

        public string? lugar { get; set; }
        public string? correo { get; set; }
    }
}
