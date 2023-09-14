using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SenatiPractica.datos;
using SenatiPractica.datos.alumno;

namespace SenatiPractica.negocio.alumno
{
    internal class NegocioAlumno
    {
        private DatosAlumno _datosAlumno = new DatosAlumno();

        public int InsertarAlumnoN(EntidadAlumno alumno)
        {
            //validaciones
            if (alumno.Dni.Length != 8)
            {
                MessageBox.Show("Longitud de dni incorrecta");
                return 0;
            }
            if (alumno.Nombres.Length == 0) {
                MessageBox.Show("Nombres esta vacio");
                return 0;
            }
            if (alumno.Apellidos.Length == 0)
            {
                MessageBox.Show("Apellidos esta vacio");
                return 0;
            }

            int numRes = _datosAlumno.InsertarAlumno(alumno);
            return numRes;
        }

        public DataTable ObtenerTodosAlumnosN()
        {

            return _datosAlumno.ObtenerTodosAlumnos();
        }
    }
}
