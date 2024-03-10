namespace WindowsFormsApp3.presentacion
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAlumno = new System.Windows.Forms.Button();
            this.btnInstructor = new System.Windows.Forms.Button();
            this.btnCurso = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAlumno
            // 
            this.btnAlumno.Location = new System.Drawing.Point(31, 34);
            this.btnAlumno.Name = "btnAlumno";
            this.btnAlumno.Size = new System.Drawing.Size(110, 49);
            this.btnAlumno.TabIndex = 0;
            this.btnAlumno.Text = "Alumno";
            this.btnAlumno.UseVisualStyleBackColor = true;
            this.btnAlumno.Click += new System.EventHandler(this.btnAlumno_Click);
            // 
            // btnInstructor
            // 
            this.btnInstructor.Location = new System.Drawing.Point(157, 34);
            this.btnInstructor.Name = "btnInstructor";
            this.btnInstructor.Size = new System.Drawing.Size(113, 49);
            this.btnInstructor.TabIndex = 1;
            this.btnInstructor.Text = "Instructor";
            this.btnInstructor.UseVisualStyleBackColor = true;
            this.btnInstructor.Click += new System.EventHandler(this.btnInstructor_Click);
            // 
            // btnCurso
            // 
            this.btnCurso.Location = new System.Drawing.Point(286, 34);
            this.btnCurso.Name = "btnCurso";
            this.btnCurso.Size = new System.Drawing.Size(101, 49);
            this.btnCurso.TabIndex = 2;
            this.btnCurso.Text = "Cursos";
            this.btnCurso.UseVisualStyleBackColor = true;
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCurso);
            this.Controls.Add(this.btnInstructor);
            this.Controls.Add(this.btnAlumno);
            this.Name = "FrmMenuPrincipal";
            this.Text = "Menu Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenuPrincipal_FormClosing);
            this.Shown += new System.EventHandler(this.FrmMenuPrincipal_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAlumno;
        private System.Windows.Forms.Button btnInstructor;
        private System.Windows.Forms.Button btnCurso;
    }
}