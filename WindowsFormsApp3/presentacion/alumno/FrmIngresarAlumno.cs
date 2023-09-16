using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SenatiPractica.datos;
using SenatiPractica.datos.alumno;
using SenatiPractica.negocio;
using SenatiPractica.negocio.alumno;

namespace SenatiPractica.presentacion.alumno
{
    public partial class FrmIngresarAlumno : Form
    {
        private NegocioAlumno _negocioAlumno = new NegocioAlumno();

        public delegate void AlumnoGrillaLoadEventHandler();
        public event AlumnoGrillaLoadEventHandler AlumnoGrillaLoaded;

        public FrmIngresarAlumno()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            EntidadAlumno alumno = new EntidadAlumno(txtDni.Text, txtNombres.Text, txtApellidos.Text);
            //alumno.Dni = txtDni.Text;
            //alumno.Nombres = txtNombres.Text;
            //alumno.Apellidos = txtApellidos.Text;
            int num = _negocioAlumno.InsertarAlumnoN(alumno);

            if (num != 0)
            {
                MessageBox.Show("Operacion Satisfactoria");
                txtDni.Text = "";
                txtNombres.Text = "";
                txtApellidos.Text = "";
                if (AlumnoGrillaLoaded != null) {
                    AlumnoGrillaLoaded(); //Invoco al evento refrescar grilla
                }
            }
        }

        private void FrmIngresarAlumno_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
