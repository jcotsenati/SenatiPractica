using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SenatiPractica.negocio;
using SenatiPractica.negocio.alumno;
using SenatiPractica.presentacion.alumno;
using SenatiPractica.presentacion.alumno;

namespace SenatiPractica.presentacion
{
    public partial class FrmMenuPrincipal : Form
    {
        private NegocioAlumno _negocioAlumno = new NegocioAlumno();

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
            Close();
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
            CenterToScreen();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            FrmIngresarAlumno frmIngresarAlumno = new FrmIngresarAlumno();
            frmIngresarAlumno.ShowDialog();
            RefrescarTodosAlumnos();
        }
        private void RefrescarTodosAlumnos()
        {
            //En caso el DataSource es null, no muestra nada en la grilla
            dgvAlumnos.DataSource = _negocioAlumno.ObtenerTodosAlumnosN();
        }

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string valor = dgvAlumnos.Rows[e.RowIndex].Cells[0].Value.ToString();
            MessageBox.Show("clave id " + valor);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarAlumno frmBuscarAlumno= new FrmBuscarAlumno();
            DialogResult dialogResult=frmBuscarAlumno.ShowDialog();
            if (dialogResult == DialogResult.OK) {
                int tipo = frmBuscarAlumno.Tipo;
                string parametro = frmBuscarAlumno.Parametro;

                DataTable result = _negocioAlumno.BuscarAlumnoByTipoAndParametroN(tipo, parametro);
                if (result != null) {

                    dgvAlumnos.DataSource = result;
                    if (result.Rows.Count > 0)
                    {
                        MessageBox.Show("Se encontraron " + result.Rows.Count + " registro(s)");
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros");
                    }
                }
                
            }
            
        }
    }
}
