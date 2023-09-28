using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SenatiPractica.common;
using SenatiPractica.common.alumno;
using WindowsFormsApp3.common.alumno;

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
        public DataTable BuscarAlumnoByTipoAndParametroN(ETipoBusquedaAlumno tipo, string parametro) {

            //validaciones
            if (tipo == ETipoBusquedaAlumno.Dni) {//DNI 
                if (Regex.IsMatch(parametro, "[aeiouAEIOU]", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("El DNI no puede tener vocales");
                    return null;
                }
            }

            return _datosAlumno.BuscarAlumnoByTipoAndParametro(tipo,parametro);
        }

        public int EditarAlumnoN(EntidadAlumno alumno)
        {
            //validaciones
            if (alumno.Dni.Length != 8)
            {
                MessageBox.Show("Longitud de dni incorrecta");
                return 0;
            }
            if (alumno.Nombres.Length == 0)
            {
                MessageBox.Show("Nombres esta vacio");
                return 0;
            }
            if (alumno.Apellidos.Length == 0)
            {
                MessageBox.Show("Apellidos esta vacio");
                return 0;
            }

            return _datosAlumno.EditarAlumno(alumno);
        }
        public int EliminarAlumnoN(int idAlumno) {

            return _datosAlumno.EliminarAlumno(idAlumno);
        }
    }
}
