using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using SenatiPractica.common.alumno;

namespace SenatiPractica.common.alumno
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
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //error específico de violación de restricción de unicidad
                {
                    int index=ex.Message.IndexOf("uc_DNI_ALUMNO");//encontramos el nombre de la restriccion
                    if (index != 0) {
                        MessageBox.Show($"El valor del campo DNI: '{alumno.Dni}' ya existe. Por favor, ingrese un DNI único.", "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }                  
                }

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int EditarAlumno(EntidadAlumno alumno)
        {
            try
            {

                using (SqlCommand cmd = new SqlCommand("editarAlumno", Connection.Singleton.SqlConnetionFactory))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", alumno.Id);
                    cmd.Parameters.AddWithValue("@Dni", alumno.Dni);
                    cmd.Parameters.AddWithValue("@Nombres", alumno.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", alumno.Apellidos);
                    int numRes = cmd.ExecuteNonQuery();
                    return numRes;

                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //error específico de violación de restricción de unicidad
                {
                    int index = ex.Message.IndexOf("uc_DNI_ALUMNO");//encontramos el nombre de la restriccion
                    if (index != 0)
                    {
                        MessageBox.Show($"El valor del campo DNI: '{alumno.Dni}' ya existe. Por favor, ingrese un DNI único.", "Error de actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                }

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public int EliminarAlumno(int idAlumno)
        {
            try
            {

                using (SqlCommand cmd = new SqlCommand("eliminarAlumno", Connection.Singleton.SqlConnetionFactory))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", idAlumno);
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
        public DataTable BuscarAlumnoByTipoAndParametro(ETipoBusquedaAlumno tipoBusquedaAlumno,string parametro)
        {

            try
            {
                int tipo = -1;
                switch (tipoBusquedaAlumno) {
                    case ETipoBusquedaAlumno.Dni:tipo = 1;break;
                    case ETipoBusquedaAlumno.Nombres: tipo = 2; break;
                    case ETipoBusquedaAlumno.Apellidos: tipo = 3; break;
                }

                using (SqlCommand cmd = new SqlCommand("buscarAlumnoByTipoAndParametro", Connection.Singleton.SqlConnetionFactory))
                {
                    DataTable dtData = new DataTable();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tipo", tipo);
                    cmd.Parameters.AddWithValue("@Parametro", parametro);
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
