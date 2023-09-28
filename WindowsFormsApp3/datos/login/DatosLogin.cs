using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SenatiPractica.common.login
{
    internal class DatosLogin
    {
        //readonly SqlConnection cn = new SqlConnection("Data Source=DESKTOP-VLV57I9\\SQLEXPRESS;Initial Catalog=Senati;Integrated Security=True");

        public DataTable Login(EntidadLogin e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("Logeo", Connection.Singleton.SqlConnetionFactory))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", e.Usuario);
                    cmd.Parameters.AddWithValue("@Contrasenia", e.Contrasenia);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tbl = new DataTable();
                        da.Fill(tbl);
                        return tbl;
                    }
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
