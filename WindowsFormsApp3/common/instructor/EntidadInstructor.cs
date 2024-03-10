using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.common.instructor
{
    public class EntidadInstructor
    {

        public String Dni { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public int Id { get; set; }

        // Constructor
        public EntidadInstructor(string dni, string nombres, string apellidos)
        {
            Dni = dni;
            Nombres = nombres;
            Apellidos = apellidos;
        }
        public EntidadInstructor(int id, string dni, string nombres, string apellidos)
        {
            Id = id;
            Dni = dni;
            Nombres = nombres;
            Apellidos = apellidos;
        }
        public EntidadInstructor() { }
    }
}
