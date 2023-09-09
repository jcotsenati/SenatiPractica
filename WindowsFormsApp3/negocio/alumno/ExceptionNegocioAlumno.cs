using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.negocio.alumno
{
    internal class ExceptionNegocioAlumno:Exception
    {
        public ExceptionNegocioAlumno(string mensaje) : base(mensaje) { }
    }
}
