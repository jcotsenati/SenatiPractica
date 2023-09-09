using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.datos;
using WindowsFormsApp3.datos.alumno;
using WindowsFormsApp3.negocio;
using WindowsFormsApp3.negocio.alumno;

namespace WindowsFormsApp3.presentacion.alumno
{
    public partial class FrmIngresarAlumno : Form
    {
        public FrmIngresarAlumno()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            NegocioAlumno negocioAlumno = new NegocioAlumno();
            EntidadAlumno alumno = new EntidadAlumno();

            alumno.Dni = txtDni.Text;
            alumno.Nombres = txtNombres.Text;
            alumno.Apellidos = txtApellidos.Text;

            try { 
                int num = negocioAlumno.InsertarAlumnoN(alumno);

                if (num != 0)
                {
                    MessageBox.Show("Operacion Satisfactoria");
                    txtDni.Text = "";
                    txtNombres.Text = "";
                    txtApellidos.Text = "";
                }
            }
            catch (ExceptionDatosAlumno ex)
            {

                MessageBox.Show(ex.Message,"Error Capa de Datos");
            }
            catch (ExceptionNegocioAlumno ex)
            {

                MessageBox.Show(ex.Message, "Error Capa de Negocio");
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message,"Error");
            }
        }

        private void FrmIngresarAlumno_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
