using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        EntidadLogin objEntidad = new EntidadLogin();
        NegocioLogin objNegocio = new NegocioLogin();
        void Login()//Creando un procedimiento.
        {
            objEntidad.Usuario = txtUsuario.Text;
            objEntidad.Contrasenia = txtContrasenia.Text;
            DataTable tbl = objNegocio.LogonN(objEntidad);
            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("No cohensiden Usuario y Contraseña \n Intentelo nuevamente",

                "Acceso al Sistema", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtContrasenia.Text = "";
                txtUsuario.Focus();
            }
            else
            {
                MessageBox.Show("Bienvenido al Sistema", "Acceso al Sistema",
               MessageBoxButtons.OK);
                //FrmMenuPrincilpal Frm = new FrmMenuPrincilpal();
                //Frm.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}
