using System.Data;

namespace WinFormsApp2
{
    internal class NegocioLogin
    {
        DatosLogin objDatos = new DatosLogin();
        public DataTable LogonN(EntidadLogin e)
        {
            return objDatos.Login(e);
        }
    }
}
