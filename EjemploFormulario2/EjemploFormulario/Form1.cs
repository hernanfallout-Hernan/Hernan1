using EjemploFormulario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace EjemploFormulario
{
    public partial class Form1 : Form
    {
        public Consultorio c;
        private object lblResultado;
       

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

        private void btnbaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv1.SelectedRows.Count > 0)
                {
                    PERSONA personitax = (PERSONA)dgv1.SelectedRows[0].DataBoundItem;

                    if (c.Borrar(personitax.DNI))
                    {
                        MessageBox.Show("La persona fue eliminada");
                    }
                    else
                    {
                        MessageBox.Show("La persona no fue eliminada, no existía");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila antes de intentar eliminar.");
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




        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {

            if (e.RowIndex < 0) return;


            if (dgv1.Rows[e.RowIndex].DataBoundItem is PERSONA personitax)
            {
                txtnombre.Text = personitax.Nombre;
                txtape.Text = personitax.Apellido;
                txtdni.Text = personitax.DNI.ToString();
            }
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv1.CurrentRow?.DataBoundItem is PERSONA p)
            {
                txtnombre.Text = p.Nombre;
                txtape.Text = p.Apellido;
                txtdni.Text = p.DNI.ToString();
            }
        }

        


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtnombre.Enabled = true;
                txtape.Enabled = true;
                txtdni.Enabled = true;
                lblResultado.Text = "El checkbox está ACTIVADO";
            }
        }

        public void Modificar(PERSONA personaNueva)
        {
            PERSONA personaEncontrada = listaPersonas.FirstOrDefault(x => x.DNI == personaNueva.DNI);

            if (personaEncontrada != null)
            {
                personaEncontrada.Nombre = personaNueva.Nombre;
                personaEncontrada.Apellido = personaNueva.Apellido;
                MessageBox.Show("¡Datos modificados con éxito!");
            }
            else
            {
                MessageBox.Show("No se encontró ninguna persona registrada con ese DNI.");
            }
        }



        private void checkBox2_CheckedChanged(object sender, EventArgs e)

        {
            bool activo = checkBox2.Checked;

            txtnombre.Enabled = activo;
            txtape.Enabled = activo;
            txtdni.Enabled = activo;

            lblResultado.Text = activo ? "El checkbox está ACTIVADO" : "El checkbox está DESACTIVADO";
        }

        
        private bool Agregar(PERSONA p)
        {
            // Verifica si el DNI ya existe
            if (listaPersonas.Any(x => x.DNI == p.DNI))
            {
                return false;
            }

            listaPersonas.Add(p);
            return true;
        }
   


        private void button1_Click(object sender, EventArgs e)

        {

            if (checkBox1.Checked == checkBox2.Checked)
            {
                lblResultado.Text = "Selecciona solo una opción (Agregar o Modificar).";
                return;
            }

           
            if (string.IsNullOrWhiteSpace(txtnombre.Text) ||
                string.IsNullOrWhiteSpace(txtape.Text) ||
                !int.TryParse(txtdni.Text.Trim(), out int dni))
            {
                lblResultado.Text = "Completa todos los campos con datos válidos.";
                return;
            }


            PERSONA p = new PERSONA
            {
                Nombre = txtnombre.Text.Trim(),
                Apellido = txtape.Text.Trim(),
                DNI = dni
            };

            bool exito = false;


            if (checkBox1.Checked)
            {
                exito = Agregar(p);
                lblResultado.Text = exito
                    ? "Persona agregada correctamente."
                    : "Error: El DNI ya está registrado.";
            }
            else
            {
                exito = Modificar(p); 
                lblResultado.Text = exito
                    ? "Persona modificada correctamente."
                    : "Error: No se encontró ninguna persona con ese DNI.";
            }

            // 5. Si la operación fue exitosa, refrescar la lista y limpiar
            if (exito)
            {
                ActualizarDGV();
                Limpiar();
            }
        }
    }
}