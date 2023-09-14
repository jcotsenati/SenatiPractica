using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.negocio;
using WindowsFormsApp3.presentacion.alumno;

namespace WindowsFormsApp3.presentacion
{
    public partial class FrmMenuPrincipal : Form
    {
        NegocioAlumno negocioAlumno = new NegocioAlumno();

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }
        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMenuPrincipal_Shown(object sender, EventArgs e)
        {
            RefrescarTodosAlumnos();
            MessageBox.Show("Bienvenido al Sistema", "Acceso al Sistema",
            MessageBoxButtons.OK);
            //Ocultamos el formulario Login
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            FrmIngresarAlumno frmIngresarAlumno = new FrmIngresarAlumno();
            frmIngresarAlumno.ShowDialog();
            RefrescarTodosAlumnos();
        }
        private void RefrescarTodosAlumnos()
        {

            dgvAlumnos.DataSource = negocioAlumno.ObtenerTodosAlumnosN();
        }

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string valor = dgvAlumnos.Rows[e.RowIndex].Cells[0].Value.ToString();
            MessageBox.Show("clave id " + valor);
        }
    }
}
