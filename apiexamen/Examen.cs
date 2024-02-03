using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiexamen
{
    public class Examen
    {
        public int IdExamen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class ExamenCreate
    {
        public bool Respuesta { get; set; }
        public string Descripcion { get; set; }
    }
}
