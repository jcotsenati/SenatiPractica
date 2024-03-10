using SenatiPractica.common.alumno;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.common.instructor;
using WindowsFormsApp3.datos.instructor;

namespace WindowsFormsApp3.negocio.instructor
{
    public class NegocioInstructor
    {
        DatosInstructor _datosInstructor = new DatosInstructor();

        public int InsertarInstructorN(EntidadInstructor instructor)
        {
            //validaciones
            if (instructor.Dni.Length != 8)
            {
                MessageBox.Show("Longitud de dni incorrecta");
                return 0;
            }
            if (instructor.Nombres.Length == 0)
            {
                MessageBox.Show("Nombres esta vacio");
                return 0;
            }
            if (instructor.Apellidos.Length == 0)
            {
                MessageBox.Show("Apellidos esta vacio");
                return 0;
            }

            int numRes = _datosInstructor.InsertarInstructor(instructor);
            return numRes;
            //return 0;
        }

        public DataTable ObtenerTodosInstructoresN()
        {

            return _datosInstructor.ObtenerTodosInstructores();
        }
    }
}
