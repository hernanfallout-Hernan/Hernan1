// ============================================================================
// NOMBRE DEL ALUMNO: Hernán Agüero
// ============================================================================
using Microsoft.Data.SqlClient;
using System.Data;
namespace FinalOOP
{
    public class Persistidor : ConectorBase, IProductoRepository, IProductoQueries
    {
        public Persistidor(string connectionString) : base(connectionString)
        {
        }

        public Producto Guardar(Producto producto)
        {
            using (var connection = ObtenerConexion())
            {
                object value = GetValue(connection);


                if (producto.Id == null)
                {
                    const string query = @"
                    INSERT INTO Productos (Descripcion, Marca, PrecioBase) 
                    VALUES (@Descripcion, @Marca, @PrecioBase);
                    SELECT CAST(scope_identity() AS int);";

                    using (var command = new SqlCommand(query,
                                                        (SqlConnection)connection))
                    {

                        command.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = producto.Descripcion;
                        command.Parameters.Add("@Marca", SqlDbType.NVarChar).Value = producto.Marca;
                        command.Parameters.Add("@PrecioBase", SqlDbType.Int).Value = producto.PrecioBase;

                        producto.Id = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                else
                {
                    const string query = @"
                    UPDATE Productos 
                    SET Descripcion = @Descripcion, Marca = @Marca, PrecioBase = @PrecioBase 
                    WHERE Id = @Id;";

                    using (var command = new SqlCommand(query, (SqlConnection)connection))
                    {
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = producto.Id;
                        command.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = producto.Descripcion;
                        command.Parameters.Add("@Marca", SqlDbType.NVarChar).Value = producto.Marca;
                        command.Parameters.Add("@PrecioBase", SqlDbType.Int).Value = producto.PrecioBase;

                        command.ExecuteNonQuery();
                    }
                }
            }
            return producto;
        }

     
 
        {
            return private object GetValue(IDisposable connection)
        {
            throw new NotImplementedException();
        }

        private void connection.Open();
        }

        private IDisposable ObtenerConexion()
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            using (var connection = ObtenerConexion())
            {
                connection.Open();
                const string query = "DELETE FROM Productos WHERE Id = @Id;";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public Producto? ObtenerPorId(int id)
        {
            using (var connection = ObtenerConexion())
            {
                connection.Open();
                const string query = "SELECT Id, Descripcion, Marca, PrecioBase FROM Productos WHERE Id = @Id;";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Mapeo seguro utilizando nombres de columnas
                            return new Producto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Marca = reader.GetString(reader.GetOrdinal("Marca")),
                                PrecioBase = reader.GetInt32(reader.GetOrdinal("PrecioBase"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            var productos = new List<Producto>();

            using (var connection = ObtenerConexion())
            {
                connection.Open();
                const string query = "SELECT Id, Descripcion, Marca, PrecioBase FROM Productos;";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    // Obtenemos los índices una sola vez antes de iterar (optimiza CPU)
                    int idOrdinal = reader.GetOrdinal("Id");
                    int descripcionOrdinal = reader.GetOrdinal("Descripcion");
                    int marcaOrdinal = reader.GetOrdinal("Marca");
                    int precioOrdinal = reader.GetOrdinal("PrecioBase");

                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            Id = reader.GetInt32(idOrdinal),
                            Descripcion = reader.GetString(descripcionOrdinal),
                            Marca = reader.GetString(marcaOrdinal),
                            PrecioBase = reader.GetInt32(precioOrdinal)
                        });
                    }
                }
            }
            return productos;
        }

        public override bool VerificarConexionBaseDeDatos()
        {
            throw new NotImplementedException();
        }

        int IProductoRepository.Guardar(Producto producto)
        {
            throw new NotImplementedException();
        }

        public List<Exception?> Insertar(List<Producto> productos)
        {
            throw new NotImplementedException();
        }

        public void DeleteMarcaRepetida()
        {
            throw new NotImplementedException();
        }

        public List<Producto> Traer(int precioBase)
        {
            throw new NotImplementedException();
        }
    }
}