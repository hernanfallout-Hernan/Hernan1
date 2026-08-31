using RegistroMascotas;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
namespace RegistroMascotas
{
    public partial class Form1 : Form
    {
        private readonly GestorMascotas _gestor = new GestorMascotas();


        public Form1()

        {
            InitializeComponent();
            ActualizarLista();
        }

        private void ActualizarLista()
        {

            listBox1.DataSource = null;
            dataGridView1.DataSource = null;


            listBox1.DataSource = _gestor.Lista;
            dataGridView1.DataSource = _gestor.Lista;


            LimpiarCampos();
        }
        private Mascota LeerFormulario() => new Mascota
        {
            Id = int.TryParse(txtText.Text, out var id) ? id : 0,
            Nombre = txtNombre.Text.Trim(),
            Edad = int.TryParse(txtEdad.Text, out var e) ? e : 0,
            Tipo = txtTipo.Text.Trim(),
            Dueno = txtDueno.Text.Trim(),
            Raza = txtRaza.Text.Trim()
        };

        private void btnAlta_Click(object sender, EventArgs e)

        {
            try
            {
                Mascota m = new Mascota();
                {


                    switch (cboxtipo.Text)
                    {
                        case "Perro":
                            m = new Perro(1, txtNombre.Text, int.Parse(txtEdad.Text), cboxtipo.Text, txtDueno.Text, txtRaza.Text, int.Parse(paseos.Text));

                            break;
                        case "Gato":
                            MessageBox.Show("Gatito");
                            break;
                    }
                    //Mascota m = new Mascota();
                    // switch(cboxtipo.Text)

                    // case "Perro":
                    //  m=new Perro(txt)
                    //     Perro= perros new Perro()

                    _gestor.Agregar(m);
                    ActualizarLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos:" + ex.Message);
            }
            }
        



        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Mascota seleccionada)
            {
                try {
                    _gestor.Eliminar(seleccionada);
                    ActualizarLista();
                }
                catch
                {
                    MessageBox.Show("Ingrese un ID válido para eliminar.");
                }
            } }


        private void btnModificacion_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Mascota seleccionada)
            {
                try
                {
                    var datosEditados = LeerFormulario();
                    datosEditados.Id = seleccionada.Id; // Preserva el ID de la mascota a modificar
                    _gestor.Modificar(datosEditados);
                    ActualizarLista();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se encontró ninguna mascota con ese ID.");
            } }
             
           
        
            
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Mascota m)
            {
                txtText.Text = m.Id.ToString();
                txtNombre.Text = m.Nombre;
                txtEdad.Text = m.Edad.ToString();
                txtTipo.Text = m.Tipo;
                txtDueno.Text = m.Dueno;
                txtRaza.Text = m.Raza;
            }
        }

        private void LimpiarCampos()
        {
            txtText.Clear();
            txtNombre.Clear();
            txtEdad.Clear();
            txtTipo.Clear();
            txtDueno.Clear();
            txtRaza.Clear();
            listBox1.ClearSelected();
            paseos.Clear();
            gbgato.Enabled=false;
            gboxiguana.Enabled=false;
            gboxloro.Enabled = false;
            gboxperros.Enabled = false;
           
            cboxtipo.SelectedIndex = -1;
        }

        private void cboxtipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboxtipo.Text)
            {
                case "Perro":
                    HabilitarCampos("domestico", "Perro");

                    break;
                case "Gato":
                    HabilitarCampos("domestico", "Gato");

                    break;
                case "Loro":
                    HabilitarCampos("exotico", "Loro");
                    break;
                case "Iguana":
                    HabilitarCampos("exotico", "Iguana");
                    break;
            } }
            private void HabilitarCampos(string tipomascota,string mascota)
        {
            switch (tipomascota)
            {
                case "domestico":
                    if (mascota=="Perro")
                     {


                            gboxperros.Enabled = true;
                            gbgato.Enabled = false;
                            gboxloro.Enabled = false;
                            gboxiguana.Enabled = false;
                        }
                        else
                        {
                            gboxperros.Enabled = false;
                            gbgato.Enabled = true;
                            gboxloro.Enabled = false;
                            gboxiguana.Enabled = false;
                        }
                    break;
                case "exotico":
                            if (mascota=="Loro")
                                    {
                                    gboxloro.Enabled=true;
                                    gboxiguana.Enabled = false;
                                    gboxperros.Enabled = false;
                                    gbgato.Enabled = false;
                                }
                                else
                                {
                                    gboxloro.Enabled = false;
                                    gboxiguana.Enabled = true;
                                    gboxperros.Enabled = false;
                                    gbgato.Enabled = false;
                                }
                                break;
                            }
                    gboxperros.Enabled = false;
                    gbgato.Enabled = false;
                    
            }
        }
    }
