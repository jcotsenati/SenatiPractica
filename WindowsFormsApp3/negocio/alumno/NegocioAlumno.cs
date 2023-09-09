using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.datos;
using WindowsFormsApp3.negocio.alumno;

namespace WindowsFormsApp3.negocio
{
    internal class NegocioAlumno
    {
        DatosAlumno datosAlumno = new DatosAlumno();

        public int InsertarAlumnoN(EntidadAlumno alumno)
        {
            //validaciones
            if (alumno.Dni.Length != 8)
            {
                throw new ExceptionNegocioAlumno("Longitud de dni incorrecta");
            }
            if (alumno.Nombres.Length == 0) {
                throw new ExceptionNegocioAlumno("Nombres esta vacio");
            }
            if (alumno.Apellidos.Length == 0)
            {
                throw new ExceptionNegocioAlumno("Apellidos esta vacio");
            }
            
            int numRes = datosAlumno.InsertarAlumno(alumno);
            return numRes;
        }
    }
}
