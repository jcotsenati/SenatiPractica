﻿using System.Data;
using SenatiPractica.common.login;

namespace SenatiPractica.negocio.login
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
