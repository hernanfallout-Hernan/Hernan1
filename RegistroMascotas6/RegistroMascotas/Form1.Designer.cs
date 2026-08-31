

using System.Windows.Forms;

namespace RegistroMascotas
{
    partial class Form1 : Form

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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAlta = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnModificacion = new System.Windows.Forms.Button();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.txtDueno = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRaza = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cboxtipo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gboxperros = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.paseos = new System.Windows.Forms.TextBox();
            this.gbgato = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.gboxexoticas = new System.Windows.Forms.GroupBox();
            this.gboxloro = new System.Windows.Forms.GroupBox();
            this.gboxiguana = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gboxperros.SuspendLayout();
            this.gbgato.SuspendLayout();
            this.gboxexoticas.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(217, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(461, 231);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(75, 23);
            this.btnAlta.TabIndex = 2;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(272, 231);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(461, 280);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(75, 23);
            this.btnBaja.TabIndex = 4;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnModificacion
            // 
            this.btnModificacion.Location = new System.Drawing.Point(461, 329);
            this.btnModificacion.Name = "btnModificacion";
            this.btnModificacion.Size = new System.Drawing.Size(75, 23);
            this.btnModificacion.TabIndex = 5;
            this.btnModificacion.Text = "Modificación";
            this.btnModificacion.UseVisualStyleBackColor = true;
            this.btnModificacion.Click += new System.EventHandler(this.btnModificacion_Click);
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(272, 280);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(100, 20);
            this.txtEdad.TabIndex = 6;
            // 
            // txtDueno
            // 
            this.txtDueno.Location = new System.Drawing.Point(272, 361);
            this.txtDueno.Name = "txtDueno";
            this.txtDueno.Size = new System.Drawing.Size(100, 20);
            this.txtDueno.TabIndex = 7;
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(272, 322);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(100, 20);
            this.txtTipo.TabIndex = 8;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(272, 190);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(100, 20);
            this.txtText.TabIndex = 9;
            this.txtText.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Edad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tipo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Dueño/Permiso";
            // 
            // txtRaza
            // 
            this.txtRaza.Location = new System.Drawing.Point(272, 400);
            this.txtRaza.Name = "txtRaza";
            this.txtRaza.Size = new System.Drawing.Size(100, 20);
            this.txtRaza.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 407);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Raza";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(476, 400);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(246, 30);
            this.listBox1.TabIndex = 17;
            this.listBox1.Click += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(172, 172);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(232, 266);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // cboxtipo
            // 
            this.cboxtipo.FormattingEnabled = true;
            this.cboxtipo.Location = new System.Drawing.Point(42, 77);
            this.cboxtipo.Name = "cboxtipo";
            this.cboxtipo.Size = new System.Drawing.Size(121, 21);
            this.cboxtipo.TabIndex = 19;
            this.cboxtipo.SelectedIndexChanged += new System.EventHandler(this.cboxtipo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gboxperros);
            this.groupBox1.Controls.Add(this.gbgato);
            this.groupBox1.Location = new System.Drawing.Point(542, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 162);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mascotas domesticas";
            // 
            // gboxperros
            // 
            this.gboxperros.Controls.Add(this.label7);
            this.gboxperros.Controls.Add(this.paseos);
            this.gboxperros.Location = new System.Drawing.Point(0, 79);
            this.gboxperros.Name = "gboxperros";
            this.gboxperros.Size = new System.Drawing.Size(234, 77);
            this.gboxperros.TabIndex = 1;
            this.gboxperros.TabStop = false;
            this.gboxperros.Text = "Perros";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "cantidad de paseos";
            // 
            // paseos
            // 
            this.paseos.Enabled = false;
            this.paseos.Location = new System.Drawing.Point(100, 30);
            this.paseos.Name = "paseos";
            this.paseos.Size = new System.Drawing.Size(100, 20);
            this.paseos.TabIndex = 0;
            // 
            // gbgato
            // 
            this.gbgato.Controls.Add(this.checkBox1);
            this.gbgato.Location = new System.Drawing.Point(6, 19);
            this.gbgato.Name = "gbgato";
            this.gbgato.Size = new System.Drawing.Size(169, 54);
            this.gbgato.TabIndex = 0;
            this.gbgato.TabStop = false;
            this.gbgato.Text = "Gatos";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(76, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Es de interior";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // gboxexoticas
            // 
            this.gboxexoticas.Controls.Add(this.gboxloro);
            this.gboxexoticas.Controls.Add(this.gboxiguana);
            this.gboxexoticas.Location = new System.Drawing.Point(570, 193);
            this.gboxexoticas.Name = "gboxexoticas";
            this.gboxexoticas.Size = new System.Drawing.Size(200, 170);
            this.gboxexoticas.TabIndex = 21;
            this.gboxexoticas.TabStop = false;
            this.gboxexoticas.Text = "Mascotas exoticas";
            // 
            // gboxloro
            // 
            this.gboxloro.Enabled = false;
            this.gboxloro.Location = new System.Drawing.Point(12, 113);
            this.gboxloro.Name = "gboxloro";
            this.gboxloro.Size = new System.Drawing.Size(148, 57);
            this.gboxloro.TabIndex = 2;
            this.gboxloro.TabStop = false;
            this.gboxloro.Text = "Loros";
            // 
            // gboxiguana
            // 
            this.gboxiguana.Enabled = false;
            this.gboxiguana.Location = new System.Drawing.Point(6, 27);
            this.gboxiguana.Name = "gboxiguana";
            this.gboxiguana.Size = new System.Drawing.Size(200, 86);
            this.gboxiguana.TabIndex = 1;
            this.gboxiguana.TabStop = false;
            this.gboxiguana.Text = "Iguana";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 618);
            this.Controls.Add(this.gboxexoticas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboxtipo);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRaza);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.txtDueno);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.btnModificacion);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gboxperros.ResumeLayout(false);
            this.gboxperros.PerformLayout();
            this.gbgato.ResumeLayout(false);
            this.gbgato.PerformLayout();
            this.gboxexoticas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnModificacion;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtDueno;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRaza;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComboBox cboxtipo;
        private GroupBox groupBox1;
        private GroupBox gboxexoticas;
        private TextBox paseos;
        private GroupBox gboxperros;
        private Label label7;
        private GroupBox gbgato;
        private GroupBox gboxloro;
        private GroupBox gboxiguana;
        private CheckBox checkBox1;
    }
}

