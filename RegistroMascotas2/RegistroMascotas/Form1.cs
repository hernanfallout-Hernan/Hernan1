
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroMascotas
{
    public partial class Form1 : Form
    {
        private readonly Refugio _refugio = new Refugio();

        // Controles de interfaz
        private readonly TextBox txtId = new TextBox() { Width = 60 }, txtNombre = new TextBox() { Width = 120 }, txtEdad = new TextBox() { Width = 50 },
                                 txtDueño = new TextBox() { Width = 120 }, txtEspecifico = new TextBox() { Width = 120 };
        private readonly ComboBox cmbTipo = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 100 };
        private readonly CheckBox chkOpcion = new CheckBox() { Text = "Sí / Interior", Width = 100 };
        private readonly Label lblEspecifico = new Label() { AutoSize = true };

        // Acciones y Visor
       
        private readonly Button btnAlta = new Button() { Text = "Alta", Width = 75 },
                                 btnMod = new Button() { Text = "Modificar", Width = 75 },
                                 btnBaja = new Button() { Text = "Baja", Width = 75 };
        private readonly ListBox lstMascotas = new ListBox() { Location = new Point(310, 10), Width = 380, Height = 320, DisplayMember = "ObtenerInfo" };

       

        private void ConfigurarUI()
        {
            Text = "Gestión ABMC - Registro de Mascotas";
            Size = new Size(720, 380);
            StartPosition = FormStartPosition.CenterScreen;
            cmbTipo.Items.AddRange(new[] { "Perro", "Gato", "Iguana", "Loro" });

            var panel = new FlowLayoutPanel { Dock = DockStyle.Left, Width = 290, AutoScroll = true, Padding = new Padding(10) };
            panel.Controls.AddRange(new Control[] {
                new Label { Text = "ID:" }, txtId,
                new Label { Text = "Nombre:" }, txtNombre,
                new Label { Text = "Edad:" }, txtEdad,
                new Label { Text = "Tipo:" }, cmbTipo,
                new Label { Text = "Dueño / Permiso:" }, txtDueño,
                lblEspecifico, txtEspecifico, chkOpcion,
                btnAlta, btnMod, btnBaja
            });

            Controls.AddRange(new Control[] { panel, lstMascotas });

           
            cmbTipo.SelectedIndexChanged += (s, e) => ModificarCamposSegunTipo();
            btnAlta.Click += (s, e) => EjecutarAccion(() => _refugio.Agregar(CrearMascotaDesdeUI()));
            btnMod.Click += (s, e) => EjecutarAccion(() => _refugio.Modificar(CrearMascotaDesdeUI()));
            btnBaja.Click += (s, e) => EjecutarAccion(() => {
                if (!int.TryParse(txtId.Text, out int id) || !_refugio.Eliminar(id))
                    throw new Exception("Ingrese un ID existente válido.");
            });
            lstMascotas.SelectedIndexChanged += (s, e) => CargarDatosMascotaSeleccionada();
        }

       
        private void ModificarCamposSegunTipo()
        {
            string tipo = cmbTipo.SelectedItem?.ToString();

            switch (tipo)
            {
                case "Perro":
                    lblEspecifico.Text = "Raza:";
                    txtEspecifico.Visible = true;
                    chkOpcion.Visible = false;
                    break;
                case "Gato":
                    lblEspecifico.Text = "Es Interior:";
                    txtEspecifico.Visible = false;
                    chkOpcion.Visible = true;
                    break;
                case "Iguana":
                    lblEspecifico.Text = "Largo (cm):";
                    txtEspecifico.Visible = true;
                    chkOpcion.Visible = false;
                    break;
                case "Loro":
                    lblEspecifico.Text = "Habla:";
                    txtEspecifico.Visible = false;
                    chkOpcion.Visible = true;
                    break;
                default:
                    lblEspecifico.Text = "Dato Esp.:";
                    txtEspecifico.Visible = true;
                    chkOpcion.Visible = false;
                    break;
            }
        }

        private Mascota CrearMascotaDesdeUI()
  
        {
            // Validar ID y Edad
            if (!int.TryParse(txtId.Text, out int id) || !int.TryParse(txtEdad.Text, out int edad))
                throw new FormatException("ID y Edad deben ser enteros numéricos.");

            string tipo = cmbTipo.SelectedItem?.ToString();

            switch (tipo)
            {
                case "Perro":
                    return new Perro(id, txtNombre.Text, edad, txtDueño.Text, txtEspecifico.Text, 2);

                case "Gato":
                    return new Gato(id, txtNombre.Text, edad, txtDueño.Text, chkOpcion.Checked);

                case "Iguana":
                    double.TryParse(txtEspecifico.Text, out double largo);
                    return new Iguana(id, txtNombre.Text, edad, txtDueño.Text, largo);

                case "Loro":
                    return new Loro(id, txtNombre.Text, edad, txtDueño.Text, chkOpcion.Checked);

                default:
                    throw new InvalidOperationException("Seleccione un tipo de mascota.");
            }
        }

        private void EjecutarAccion(Action accion)
        {
            try
            {
                accion();
                lstMascotas.DataSource = null;
                lstMascotas.DataSource = _refugio.Listar();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
         private void CargarDatosMascotaSeleccionada()
        {
            if (!(lstMascotas.SelectedItem is Mascota m)) return;

            txtId.Text = m.Id.ToString();
            txtNombre.Text = m.Nombre;
            txtEdad.Text = m.Edad.ToString();

            
            txtDueño.Text = m switch
            {
                MascotaDomestica d => d.Dueño,
                MascotaExotica ex => ex.PermisoFauna,
                _  => string.Empty
            };

            switch (m)
            {
                case Perro p: cmbTipo.SelectedItem = "Perro"; txtEspecifico.Text = p.Raza; break;
                case Gato g: cmbTipo.SelectedItem = "Gato"; chkOpcion.Checked = g.EsInterior; break;
                case Iguana i: cmbTipo.SelectedItem = "Iguana"; txtEspecifico.Text = i.LargoCm.ToString(); break;
                case Loro l: cmbTipo.SelectedItem = "Loro"; chkOpcion.Checked = l.Habla; break;
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear(); txtNombre.Clear(); txtEdad.Clear();
            txtDueño.Clear(); txtEspecifico.Clear();
            chkOpcion.Checked = false;
            cmbTipo.SelectedIndex = -1;
        }
    }
}