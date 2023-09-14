using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace SenatiPractica.datos.alumno
{
    internal class DatosAlumno
    {
        public EntidadAlumno ObtenerAlumno(int idAlumno)
        {
            return null;
        }
        public int InsertarAlumno(EntidadAlumno alumno) {

            try
            {

                using (SqlCommand cmd = new SqlCommand("insertarAlumno", Connection.Singleton.SqlConnetionFactory))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dni", alumno.Dni);
                    cmd.Parameters.AddWithValue("@Nombres", alumno.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", alumno.Apellidos);
                    int numRes = cmd.ExecuteNonQuery();
                    return numRes;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public void EditarAlumno(EntidadAlumno alumno)
        {

        }
        public void EliminarAlumno(int idAlumno)
        {

        }
        public DataTable ObtenerTodosAlumnos()
        {

            try
            {

                using (SqlCommand cmd = new SqlCommand("obtenerTodosAlumnos", Connection.Singleton.SqlConnetionFactory))
                {
                    DataTable dtData = new DataTable();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                    sqlSda.Fill(dtData);
                    return dtData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
    }
}
