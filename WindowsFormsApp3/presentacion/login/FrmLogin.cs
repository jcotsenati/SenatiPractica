using System;
using System.Data;
using System.Windows.Forms;
using SenatiPractica.common.login;
using SenatiPractica.negocio.login;
using SenatiPractica.presentacion;

namespace SenatiPractica
{
    public partial class FrmLogin : Form
    {
        EntidadLogin _objEntidad;
        NegocioLogin _objNegocio;


        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            //"Data Source=localhost,64930;Initial Catalog=Senati;User ID=sa;Password=***********"
            //"Data Source=DESKTOP-VLV57I9\\SQLEXPRESS;Initial Catalog=Senati;Integrated Security=True";
            _objEntidad = new EntidadLogin();
            _objNegocio = new NegocioLogin();

        }
        void Login()//Creando un procedimiento.
        {
            Connection.Singleton.ConnetionString = txtConeccion.Text;
            _objEntidad.Usuario = txtUsuario.Text;
            _objEntidad.Contrasenia = txtContrasenia.Text;

            DataTable tbl = _objNegocio.LogonN(_objEntidad);
            if (tbl == null) return;

            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("No coinciden Usuario y Contraseña \n Intentelo nuevamente",

                "Acceso al Sistema", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtContrasenia.Text = "";
                txtUsuario.Focus();
            }
            else
            {
                //MessageBox.Show("Bienvenido al Sistema", "Acceso al Sistema",
                //MessageBoxButtons.OK);
                //Ocultamos el formulario Login
                this.Hide();
                //Mostramos el MenuPrincipal
                FrmMenuAlumno frmMenuAlumno = new FrmMenuAlumno();
                frmMenuAlumno.Show();
              
            }

        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}
