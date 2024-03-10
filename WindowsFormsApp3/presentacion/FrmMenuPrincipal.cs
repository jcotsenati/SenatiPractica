using SenatiPractica.presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.presentacion.instructor;

namespace WindowsFormsApp3.presentacion
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
            FrmMenuAlumno frmMenuAlumno = new FrmMenuAlumno();
            frmMenuAlumno.Show();
        }

        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMenuPrincipal_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido al Sistema", "Acceso al Sistema",
            MessageBoxButtons.OK);
        }

        private void btnInstructor_Click(object sender, EventArgs e)
        {
            FrmMenuInstructor frmMenuInstructor = new FrmMenuInstructor();
            frmMenuInstructor.Show();
            
        }
    }
}
