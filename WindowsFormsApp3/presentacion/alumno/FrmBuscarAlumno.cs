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
    public partial class FrmBuscarAlumno : Form
    {
        public int Tipo { get; set; }
        public string  Parametro { get; set; }

        public FrmBuscarAlumno()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //0 DNI 
            //1 NOMBRES
            //2 APELLIDOS
            Tipo = cbTipo.SelectedIndex + 1;
            Parametro=txtBusqueda.Text;
            this.DialogResult = DialogResult.OK; // Establecer el resultado del diálogo.
            this.Close();
        }

        private void FrmBuscarAlumno_Shown(object sender, EventArgs e)
        {
            CenterToScreen();
            cbTipo.SelectedIndex = 0;//Seleccionamos DNI por defecto
            txtBusqueda.Focus();
        }
    }
}
