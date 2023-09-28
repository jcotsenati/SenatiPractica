using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenatiPractica.common.alumno
{
    public class EntidadAlumno
    {
        public String Dni { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public int Id { get; set; }

        // Constructor
        public EntidadAlumno(string dni, string nombres, string apellidos)
        {
            Dni = dni;
            Nombres = nombres;
            Apellidos = apellidos;
        }
        public EntidadAlumno(int id,string dni, string nombres, string apellidos)
        {
            Id = id;
            Dni = dni;
            Nombres = nombres;
            Apellidos = apellidos;
        }
        public EntidadAlumno() { }
    }
}
