using SenatiPractica.common.alumno;
using SenatiPractica.negocio.alumno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenatiPractica.presentacion.alumno
{
    public partial class FrmEditarAlumno : Form
    {
        private NegocioAlumno _negocioAlumno = new NegocioAlumno();
        private EntidadAlumno _entidadAlumno;

        public delegate void AlumnoGrillaLoadEventHandler();
        public event AlumnoGrillaLoadEventHandler AlumnoGrillaLoaded;

        public FrmEditarAlumno(EntidadAlumno entidadAlumno)
        {
            _entidadAlumno = entidadAlumno;
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _entidadAlumno.Dni = txtDni.Text;
            _entidadAlumno.Nombres = txtNombres.Text;
            _entidadAlumno.Apellidos = txtApellidos.Text;

            int num=_negocioAlumno.EditarAlumnoN(_entidadAlumno);

            if (num != 0)
            {

                if (AlumnoGrillaLoaded != null)
                {
                    AlumnoGrillaLoaded(); //Invoco al evento refrescar grilla
                }

                MessageBox.Show("Operacion Satisfactoria");

                Close();
            }
            
            

        }
        private void FrmEditarAlumno_Shown(object sender, EventArgs e)
        {
            txtDni.Text = _entidadAlumno.Dni;
            txtNombres.Text = _entidadAlumno.Nombres;
            txtApellidos.Text = _entidadAlumno.Apellidos;
        }
    }
}
