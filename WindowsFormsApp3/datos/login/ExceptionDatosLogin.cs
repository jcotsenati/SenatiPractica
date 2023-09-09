using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.datos.login
{
    internal class ExceptionDatosLogin:Exception
    {
        public ExceptionDatosLogin(String mensaje):base(mensaje) { }
    }
}
