using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
