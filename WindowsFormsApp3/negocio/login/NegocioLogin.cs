using System.Data;
using System.Windows.Forms;
using SenatiPractica.common.login;

namespace SenatiPractica.negocio.login
{
    internal class NegocioLogin
    {
        DatosLogin objDatos = new DatosLogin();
        public DataTable LogonN(EntidadLogin usuario)
        {
            if (usuario.Usuario.Trim() == "") {
                MessageBox.Show("Usuario esta vacio");
                return null;
            }
            if (usuario.Contrasenia.Trim() == "")
            {
                MessageBox.Show("Contraseña esta vacio");
                return null;
            }

            return objDatos.Login(usuario);
        }
    }
}
