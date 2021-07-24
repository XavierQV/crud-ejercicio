using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_ejercicio.Models
{
    public class Genero
    {
        public Genero()
        {
            Personas = new HashSet<Persona>();
        }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
