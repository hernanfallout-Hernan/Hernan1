using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploFormulario
{
    public partial class Form1
    {
        public Consultorio c;
        public Form1()
        {
            InitializeComponent();
            c = new Consultorio();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ActualizarDGV();
        }

        private void btnalta_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarControlesBase())
                {
                    PERSONA p = new PERSONA(int.Parse(txtdni.Text), txtnombre.Text, txtape.Text);
                    if (c.Agregar(p))
                    {
                        MessageBox.Show("La persona fue agregada", "Operacion ok");
                    }
                    else
                    {
                        MessageBox.Show("La persona no fue agregada, ya existia", "Operacion fail");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Limpiar();
                ActualizarDGV();
            }

        }

        private bool ValidarControlesBase()
        {

            if (!string.IsNullOrEmpty(txtape.Text) && !string.IsNullOrEmpty(txtnombre.Text) && !string.IsNullOrEmpty(txtdni.Text))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void ActualizarDGV()
        {
            dgv1.DataSource = null;
            dgv1.DataSource = c.DevolverPacientes();
        }
        private void Limpiar()
        {
            txtape.Text = string.Empty;
            txtnombre.Text = string.Empty;
            txtdni.Text = string.Empty;


        }
    }
}
