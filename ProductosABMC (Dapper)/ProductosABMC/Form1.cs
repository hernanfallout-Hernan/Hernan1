using ProductosABMC.Persistidores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProductosABMC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DapperPersister.ConnectionString = @"Data Source = .\SQLEXPRESS; Initial Catalog = ProductoDB; Integrated Security = True;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefrescarGrilla();
        }

        /// <summary>
        /// La aplicación recarga la lista de productos
        /// </summary>
        private void RefrescarGrilla()
        {            
            DapperPersister persister = new DapperPersister();
            List<Producto> productos = persister.Find("");

            dataGridViewProductos.DataSource = productos;
        }

        private void dataGridViewProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool haySeleccion = (e.RowIndex != -1);

            if (haySeleccion)
            {
                //Selecciono un producto real
                DataGridViewRow row = dataGridViewProductos.Rows[e.RowIndex];

                int id = Convert.ToInt32( row.Cells[0].Value);

                DapperPersister persister = new DapperPersister();
                Producto productoSelecionado = persister.Load(id);

                //Carga el formulario con los datos del producto seleccionado
                textBoxId.Text = productoSelecionado.Id.ToString();
                textBoxDescripcion.Text = productoSelecionado.Descripcion;
                textBoxMarca.Text = productoSelecionado.Marca;
                textBoxPrecio.Text = productoSelecionado.Precio.ToString();

            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            bool esNuevo = string.IsNullOrWhiteSpace(textBoxId.Text);

            if (!esNuevo)
                producto.Id = Convert.ToInt32(textBoxId.Text); //Existente
            else
                producto.Id = null; //Nuevo producto

            producto.Descripcion = textBoxDescripcion.Text;
            producto.Marca = textBoxMarca.Text;
            producto.Precio = Convert.ToDouble(textBoxPrecio.Text);

            DapperPersister persister = new DapperPersister();
            persister.Save(producto);

            if(esNuevo)
            {
                textBoxId.Text = producto.Id.ToString(); //Que lo vea el usuario
                await Task.Delay(5000); //Demora para ver el valor del ID
            }

            LimpiarFormulario();
            RefrescarGrilla();
        }

        private void LimpiarFormulario()
        {
            textBoxId.Text = ""; //Solo lectura
            textBoxDescripcion.Text = "";
            textBoxMarca.Text = "";
            textBoxPrecio.Text = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                            $"¿Está seguro de que desea eliminar el producto '{textBoxDescripcion.Text}'?",
                            "Confirmar Eliminación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2
                        );

            if (resultado == DialogResult.Yes)
            {
                int id = Convert.ToInt32(textBoxId.Text);

                DapperPersister persister = new DapperPersister();
                persister.Remove(id);

                LimpiarFormulario();
                RefrescarGrilla();
            }            
        }
    }
}
