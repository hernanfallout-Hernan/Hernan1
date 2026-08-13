namespace EjemploFormulario
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblnombre = new System.Windows.Forms.Label();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtdni = new System.Windows.Forms.TextBox();
            this.txtape = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.lbldni = new System.Windows.Forms.Label();
            this.lblape = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.btnbaja = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(9, 39);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(64, 18);
            this.lblnombre.TabIndex = 0;
            this.lblnombre.Text = "Nombre";
            // 
            // gb1
            // 
            this.gb1.BackColor = System.Drawing.Color.Thistle;
            this.gb1.Controls.Add(this.checkBox2);
            this.gb1.Controls.Add(this.checkBox1);
            this.gb1.Controls.Add(this.txtdni);
            this.gb1.Controls.Add(this.txtape);
            this.gb1.Controls.Add(this.txtnombre);
            this.gb1.Controls.Add(this.lbldni);
            this.gb1.Controls.Add(this.lblape);
            this.gb1.Controls.Add(this.lblnombre);
            this.gb1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb1.Location = new System.Drawing.Point(100, 274);
            this.gb1.Margin = new System.Windows.Forms.Padding(4);
            this.gb1.Name = "gb1";
            this.gb1.Padding = new System.Windows.Forms.Padding(4);
            this.gb1.Size = new System.Drawing.Size(520, 235);
            this.gb1.TabIndex = 1;
            this.gb1.TabStop = false;
            this.gb1.Text = "Formulario";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(357, 67);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(94, 22);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "ModoAlta";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(357, 39);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(156, 22);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "ModoModificacion";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtdni
            // 
            this.txtdni.Location = new System.Drawing.Point(122, 133);
            this.txtdni.Margin = new System.Windows.Forms.Padding(4);
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(148, 26);
            this.txtdni.TabIndex = 5;
            // 
            // txtape
            // 
            this.txtape.Location = new System.Drawing.Point(122, 80);
            this.txtape.Margin = new System.Windows.Forms.Padding(4);
            this.txtape.Name = "txtape";
            this.txtape.Size = new System.Drawing.Size(148, 26);
            this.txtape.TabIndex = 4;
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(122, 35);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(148, 26);
            this.txtnombre.TabIndex = 3;
            // 
            // lbldni
            // 
            this.lbldni.AutoSize = true;
            this.lbldni.Location = new System.Drawing.Point(9, 144);
            this.lbldni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldni.Name = "lbldni";
            this.lbldni.Size = new System.Drawing.Size(34, 18);
            this.lbldni.TabIndex = 2;
            this.lbldni.Text = "DNI";
            // 
            // lblape
            // 
            this.lblape.AutoSize = true;
            this.lblape.Location = new System.Drawing.Point(9, 91);
            this.lblape.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblape.Name = "lblape";
            this.lblape.Size = new System.Drawing.Size(65, 18);
            this.lblape.TabIndex = 1;
            this.lblape.Text = "Apellido";
            // 
            // dgv1
            // 
            this.dgv1.BackgroundColor = System.Drawing.Color.Thistle;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(100, 13);
            this.dgv1.Margin = new System.Windows.Forms.Padding(4);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.Size = new System.Drawing.Size(704, 235);
            this.dgv1.TabIndex = 2;
            // 
            // btnbaja
            // 
            this.btnbaja.Location = new System.Drawing.Point(662, 450);
            this.btnbaja.Margin = new System.Windows.Forms.Padding(4);
            this.btnbaja.Name = "btnbaja";
            this.btnbaja.Size = new System.Drawing.Size(112, 32);
            this.btnbaja.TabIndex = 4;
            this.btnbaja.Text = "Baja";
            this.btnbaja.UseVisualStyleBackColor = true;
            this.btnbaja.Click += new System.EventHandler(this.btnbaja_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(662, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(918, 546);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnbaja);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.gb1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Clinica";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.TextBox txtape;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label lbldni;
        private System.Windows.Forms.Label lblape;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnbaja;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
    }
}

