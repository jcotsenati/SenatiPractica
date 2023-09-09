using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.datos.alumno
{
    internal class ExceptionDatosAlumno : Exception
    {
        public ExceptionDatosAlumno(string mensaje):base(mensaje) {
        }
    }
}
