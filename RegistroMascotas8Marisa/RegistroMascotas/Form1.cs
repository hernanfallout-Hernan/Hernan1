using RegistroMascotas;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace RegistroMascotas
{
    public partial class Form1 : Form
    {
        private readonly GestorMascotas _gestor = new GestorMascotas();


        public Form1()

        {
            InitializeComponent();
            ActualizarLista();

            cboxtipo.Items.AddRange(new string[] { "Perro", "Gato", "Loro", "Iguana" });
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
                            m = new Perro(int.Parse(txtText.Text), txtNombre.Text, int.Parse(txtEdad.Text), cboxtipo.Text, txtDueno.Text, txtRaza.Text, int.Parse(paseos.Text));

                            break;
                        case "Gato":
                            m = new Gato(0, txtNombre.Text, int.Parse(txtEdad.Text), cboxtipo.Text, txtDueno.Text, txtRaza.Text, checkBox1.Checked);
                            break;
                        case "Loro":
                            m = new Loro(0, txtNombre.Text, int.Parse(txtEdad.Text), cboxtipo.Text, txtDueno.Text, txtRaza.Text, int.Parse(txtPermiso.Text), checkBox2.Checked);
                            break;
                        case "Iguana":
                            m = new Iguana(0, txtNombre.Text, int.Parse(txtEdad.Text), cboxtipo.Text, txtDueno.Text, txtRaza.Text, int.Parse(txtPermiso.Text), int.Parse(txtLargo.Text));
                            break;
                    }
                    

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
            if (listBox1.SelectedItem is Mascota m)
            {
                if (m is Loro || m is Iguana)
            {
                m.Nombre = txtNombre.Text;
                m.Edad = Convert.ToInt32(txtEdad.Text);
                m.Tipo = txtTipo.Text;
                m.Dueno = txtDueno.Text;
                m.Raza = txtRaza.Text;
                    switch (m.GetType().Name)
                    {
                        case "Loro":
                            if (m is Loro unLoro)
                            {
                                unLoro.PermisoFauna =int.Parse (txtPermiso.Text);
                            }
                            break;

                        case "Iguana":
                            if (m is Iguana unaIguana)
                            {
                                unaIguana.PermisoFauna = int.Parse(txtPermiso.Text);
                            }
                            break;
                    }
                    MessageBox.Show("Mascota exótica modificada con éxito.", "Éxito");
                  ActualizarLista();
                    
                }
                else
                {
                    MessageBox.Show("Solo se permite modificar animales exóticos (Loro o Iguana).", "Acceso denegado");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una mascota de la lista.", "Atención");
            }
        }

             //   if (listBox1.SelectedItem is Mascota seleccionada)
        //  {
              // try
             //   {
                //    var datosEditados = LeerFormulario();
                 //   datosEditados.Id = seleccionada.Id; // Preserva el ID de la mascota a modificar
                 //   _gestor.Modificar(datosEditados);
                 //   ActualizarLista();
              //  }
              //  catch (Exception ex)
               // {
                 //   MessageBox.Show("Error al modificar: " + ex.Message);
              //  }
          //  }
          //  else
          //  {
            //    MessageBox.Show("No se encontró ninguna mascota con ese ID.");
           // } } 
             
           
        
            
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarCampos();
            if (listBox1.SelectedItem is Mascota m)
            {
                txtText.Text = m.Id.ToString();
                txtNombre.Text = m.Nombre;
                txtEdad.Text = m.Edad.ToString();
                txtTipo.Text = m.Tipo;
                txtDueno.Text = m.Dueno;
                txtRaza.Text = m.Raza;
                ElegirOpcionCombo(m.GetType().Name);
                switch (m.GetType().Name)
                {
                    case "Perro":
                        if (m is Perro p)
                        {
                           paseos.Text = p.PaseosDiarios.ToString();
                            
                        }

                        break;
                    case "Gato":
                        if (m is Gato ungato)
                        {
                            checkBox1.Checked = ungato.EsInterior;
                        }
                        break;
                    case "Loro":
                        if (m is Loro unLoro)
                        {
                            txtPermiso.Text = unLoro.PermisoFauna.ToString();
                        }
                        break;
                    case "Iguana":
                        if (m is Iguana unaIguana)
                        {
                            txtPermiso.Text = unaIguana.PermisoFauna.ToString();
                        }
                        break;
                }
            }
        }
        private void ElegirOpcionCombo(string tipo)
        {
            switch (tipo)
            {
                case "Perro":
                    cboxtipo.SelectedIndex = 0;
                    break;
                case "Gato":
                    cboxtipo.SelectedIndex = 1;
                    break;
                case "Loro":
                    cboxtipo.SelectedIndex = 2;
                    break;
                case "Iguana":
                    cboxtipo.SelectedIndex = 3;
                    break;
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
            txtPermiso.Clear();
            paseos.Text = "";         
            checkBox1.Checked = false; 
            txtPermiso.Text = "";

          

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
                    
            }

     
    }
    }
