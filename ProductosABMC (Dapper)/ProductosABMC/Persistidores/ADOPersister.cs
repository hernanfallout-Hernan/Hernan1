using ProductosABMC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ProductosABMC.Persistidores
{
    public class ADOPersister : IPersistible
    {
        public static string ConnectionString;

        public List<Producto> Find(string partOfDescription)
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @" SELECT * 
                                FROM producto 
                                WHERE Descripcion LIKE '%' + @parte + '%'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@parte", partOfDescription);
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);

                    productos = CovertTableToList(table);
                }
            }
            return productos;
        }

        private List<Producto> CovertTableToList(DataTable table)
        {
            List<Producto> productos = new List<Producto>();
            foreach (DataRow row in table.Rows)
            {
                Producto producto = new Producto()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Marca = Convert.ToString(row["Marca"]),
                    Precio = Convert.ToDouble(row["Precio"])
                };

                productos.Add(producto);
            }
            return productos;
        }

        public Producto Load(int id)
        {
            Producto producto = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @" SELECT * 
                                FROM producto
                                WHERE id = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);

                    if (table.Rows.Count != 1)
                        throw new Exception("Error por id erroneo");

                    List<Producto> productos = CovertTableToList(table);

                    producto = productos[0];
                }
            }
            return producto;
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = @" DELETE 
                                FROM producto
                                WHERE id = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    int recordsAffected = command.ExecuteNonQuery();

                    if (recordsAffected != 1)
                        throw new Exception("Error en la cantidad de registros eliminado");
                }
            }
        }

        public void Remove(Producto producto)
        {
            this.Remove(producto.Id.Value);
        }

        public void Save(Producto producto)
        {
            if (producto.Id != null)
                Update(producto);
            else
                Insert(producto);
        }

        private void Insert(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO [Producto]
                                ([Descripcion]
                                ,[Marca]
                                ,[Precio])
                               VALUES
                                (@Descripcion
                                ,@Marca
                                ,@Precio)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Marca", producto.Marca);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);

                    int recordsAffected = command.ExecuteNonQuery();

                    if (recordsAffected != 1)
                        throw new Exception("Error en la cantidad de registros insertados");

                    producto.Id = GetId(command);
                }
            }
        }

        private int GetId(SqlCommand command)
        {
            int id;
            string sql = "select @@identity";
            command.CommandText = sql;
            command.Parameters.Clear();
            object objId = command.ExecuteScalar();
            id = Convert.ToInt32(objId);
            return id;
        }

        private void Update(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = @"UPDATE [Producto]
                               SET [Descripcion] = @Descripcion 
                                  ,[Marca]       = @Marca
                                  ,[Precio]      = @Precio
                               WHERE id = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Marca", producto.Marca);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.Parameters.AddWithValue("@id", producto.Id.Value);

                    int recordsAffected = command.ExecuteNonQuery();

                    if (recordsAffected != 1)
                        throw new Exception("Error en la cantidad de registros modificados");
                }
            }
        }
    }
}
