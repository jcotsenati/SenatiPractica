using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    internal class DatosLogin
    {
        readonly SqlConnection cn = new SqlConnection("Data Source=DESKTOP-VLV57I9\\SQLEXPRESS;Initial Catalog=Senati;Integrated Security=True");
        public DataTable Login(EntidadLogin e)
        {
            using (SqlCommand cmd = new SqlCommand("Login", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", "jorge");
                cmd.Parameters.AddWithValue("@Contrasenia", "jorge1");
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable tbl = new DataTable();
                    da.Fill(tbl);
                    return tbl;
                }
            }
        }
    }
}
