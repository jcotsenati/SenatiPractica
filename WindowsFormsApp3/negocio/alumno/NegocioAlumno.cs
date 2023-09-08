using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.datos;

namespace WindowsFormsApp3.negocio
{
    internal class NegocioAlumno
    {
        DatosAlumno datosAlumno = new DatosAlumno();

        public int InsertarAlumnoN(EntidadAlumno alumno)
        {
            int numRes = datosAlumno.InsertarAlumno(alumno);
            return numRes;
        }
    }
}
