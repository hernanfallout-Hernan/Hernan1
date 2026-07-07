using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ProductosABMC.Persistidores
{
    internal class DapperPersister : IPersistible
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

                productos = connection.Query<Producto>(sql, new { Parte = partOfDescription })
                            .ToList();

            }
            return productos;
        }

        public Producto Load(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT *
                                FROM producto 
                                WHERE Id = @Id;";

                Producto producto = connection.QuerySingleOrDefault<Producto>(sql, new { Id = id });

                return producto;
            }
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @"DELETE 
                                FROM producto 
                                WHERE Id = @Id;";

                connection.Execute(sql, new { Id = id });                
            }
        }

        public void Remove(Producto producto)
        {
            this.Remove(producto.Id.Value);
        }

        public void Save(Producto producto)
        {
            if (producto.Id == null)
                Insert(producto);
            else
                Update(producto);
        }

        public void Insert(Producto producto)
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
                                ,@Precio);

                                Select @@identity";

                int id = connection.QuerySingle<int>(sql, producto);

                producto.Id = id;
            }
        }
        public void Update(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @"UPDATE [Producto]
                               SET [Descripcion] = @Descripcion 
                                  ,[Marca]       = @Marca
                                  ,[Precio]      = @Precio
                               WHERE id = @id";

                int affected = connection.Execute(sql, producto);

                if (affected != 1) throw new Exception("Error en UPDATE");
            }
        }

    }
}
