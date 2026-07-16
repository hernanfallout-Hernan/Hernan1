using Dapper;
using FinalOOP;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal static class Helper
    {
        public static string ConnectionString { get; set; } = string.Empty;
        public static int DeleteAll()
        {
            int affected;
            string sql = "DELETE FROM Productos";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                affected = conn.Execute(sql);
            }
            return affected;
        }

        /// <summary>
        /// Insertar un producto.
        /// </summary>
        public static void InsertOne(Producto producto)
        {            
            const string sql = @"
                INSERT INTO Productos (Descripcion, Marca, PrecioBase) 
                OUTPUT INSERTED.Id
                VALUES (@Descripcion, @Marca, @PrecioBase);";

            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                int idGenerado = conn.QuerySingle<int>(sql, producto);
             
                producto.Id = idGenerado;
            }                       
        }

        /// <summary>
        /// Inserta productos en la base de datos en forma aleatoria.
        /// </summary>
        /// <returns>
        /// Lista de productos insertados.
        /// </returns>
        public static List<Producto> InsertProductos()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var producto = new Producto
                {
                    Id = null,
                    Descripcion = "Fideo" + Guid.NewGuid().ToString(),
                    Marca = "Marolio" + Guid.NewGuid().ToString(),
                    PrecioBase = rnd.Next(1, 3)
                };
                InsertOne(producto);
            }
            List<Producto> productos = SelectAll();
            return productos;
        }

        public static List<Producto> SelectAll()
        {
            const string sql = "SELECT Id, Descripcion, Marca, PrecioBase FROM Productos;";

            using var conn = new SqlConnection(ConnectionString);

            return conn.Query<Producto>(sql).ToList();
        }

    }
}
