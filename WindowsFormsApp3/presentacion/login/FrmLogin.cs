using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp3.datos.login;
using WindowsFormsApp3.presentacion;
using WinFormsApp2;

namespace WindowsFormsApp3
{
    public partial class FrmLogin : Form
    {
        EntidadLogin objEntidad;
        NegocioLogin objNegocio;


        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            //"Data Source=localhost,64930;Initial Catalog=Senati;User ID=sa;Password=***********"
            //"Data Source=DESKTOP-VLV57I9\\SQLEXPRESS;Initial Catalog=Senati;Integrated Security=True";
            objEntidad = new EntidadLogin();
            objNegocio = new NegocioLogin();

        }
        void Login()//Creando un procedimiento.
        {
            Connection.Singleton.ConnetionString = txtConeccion.Text;
            objEntidad.Usuario = txtUsuario.Text;
            objEntidad.Contrasenia = txtContrasenia.Text;

            try
            {
                DataTable tbl = objNegocio.LogonN(objEntidad);
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
                    FrmMenuPrincipal frmMenuPrincipal = new FrmMenuPrincipal();
                    frmMenuPrincipal.Show();

                }
            }
            catch (ExceptionDatosLogin ex) {

                MessageBox.Show(ex.Message, "Error Capa de Datos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}
