using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SenatiPractica.common.alumno;
using SenatiPractica.negocio;
using SenatiPractica.negocio.alumno;
using SenatiPractica.presentacion.alumno;
using WindowsFormsApp3.common.alumno;

namespace SenatiPractica.presentacion
{
    public partial class FrmMenuPrincipal : Form
    {
        private NegocioAlumno _negocioAlumno = new NegocioAlumno();

        private EntidadAlumno _alumnoSeleccionado = new EntidadAlumno();
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
            CargarTodosAlumnos();
            MessageBox.Show("Bienvenido al Sistema", "Acceso al Sistema",
            MessageBoxButtons.OK);
            
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            FrmIngresarAlumno frmIngresarAlumno = new FrmIngresarAlumno();
            frmIngresarAlumno.AlumnoGrillaLoaded += CargarTodosAlumnos;//Usamos eventos para refrescar la grilla
            frmIngresarAlumno.ShowDialog();
        }
        private void CargarTodosAlumnos()
        {
            //En caso el DataSource es null, no muestra nada en la grilla
            dgvAlumnos.DataSource = _negocioAlumno.ObtenerTodosAlumnosN();
            SeleccionarAlumnoLoad();
        }
        public void SeleccionarAlumnoLoad() {

            if (dgvAlumnos.Rows.Count == 0) {
                return;
            }

            string id = dgvAlumnos.CurrentRow.Cells[0].Value.ToString();
            string dni = dgvAlumnos.CurrentRow.Cells[1].Value.ToString();
            string nombres = dgvAlumnos.CurrentRow.Cells[2].Value.ToString();
            string apellidos = dgvAlumnos.CurrentRow.Cells[3].Value.ToString();

            _alumnoSeleccionado.Id = Convert.ToInt32(id);
            _alumnoSeleccionado.Dni = dni;
            _alumnoSeleccionado.Nombres = nombres;
            _alumnoSeleccionado.Apellidos = apellidos;

        }
        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarAlumnoLoad();   
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarAlumno frmBuscarAlumno= new FrmBuscarAlumno();
            DialogResult dialogResult=frmBuscarAlumno.ShowDialog();
            if (dialogResult == DialogResult.OK) {
                ETipoBusquedaAlumno tipo = frmBuscarAlumno.Tipo;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.CurrentRow == null) {

                MessageBox.Show("Seleccion un alumno!!!");
                return;
            }

            FrmEditarAlumno frmEditarAlumno = new FrmEditarAlumno(_alumnoSeleccionado);
            frmEditarAlumno.AlumnoGrillaLoaded += CargarTodosAlumnos;//Usamos eventos para refrescar la grilla
            frmEditarAlumno.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.CurrentRow == null)
            {

                MessageBox.Show("Seleccione un alumno!!!");
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Deseas eliminar el registro con dni: "+_alumnoSeleccionado.Dni+" ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (resultado == DialogResult.Yes)
            {
                int num = _negocioAlumno.EliminarAlumnoN(_alumnoSeleccionado.Id);
                if (num != 0)
                {

                    CargarTodosAlumnos();
                    MessageBox.Show("Operacion Satisfactoria");
                }
            }

            
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarTodosAlumnos();
        }
    }
}
