using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Persistidor2
    {
        private void Insert(Libro libro)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    @"INSERT INTO Libro 
                                (id_libro, titulo, año ) 
                      VALUES 
                                (@id_libro, @titulo, @año)";
                using (SqlConnection cmd = new SqlConnection(sqlQuery, cnx))
                {
                    object idLector = libro.IdLector == null ? (object)DBNull.Value : libro.IdLector;

                    cmd.Parameters.AddWithValue("@id_libro", libro.CodigoIdentificacionUnico);
                    cmd.Parameters.AddWithValue("@titulo", libro.Titulo);
                    cmd.Parameters.AddWithValue("@año", libro.ISBN);


                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(libro);
        }
}
     private void Update(Libro libro)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                const string sqlQuery =
                   @"  UPDATE Libro 
                        SET  
                            codigo_identificacion_unico = @codigo_identificacion_unico,
                            titulo = @titulo, 
                            isbn = @isbn,
                            id_lector = @id_lector                        
                        WHERE id_libro = @id_libro";
                using (SqlConnection cmd = new SqlConnection(sqlQuery, cnx))
                {
                    object idLector = libro.IdLector == null ? (object)DBNull.Value : libro.IdLector;

                    cmd.Parameters.AddWithValue("@id_libro", libro.idlibro);
                    cmd.Parameters.AddWithValue("@titulo", libro.Titulo);
                    cmd.Parameters.AddWithValue("@año", libro.año);


                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }
        public List<Libro> GetAll()
        {
            List<Libro> libros = new List<Libro>();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM Libro ORDER BY id_libro ASC";
                using (SqlConnection cmd = new SqlConnection(sqlQuery, cnx))
                {
                    DataTable table = new DataTable();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Libro libro = new Libro
                        {
                            Id = Convert.ToInt32(row["id_libro"]),
                           
                            Titulo = Convert.ToString(row["titulo"]),
                            ISBN = Convert.ToString(row["año"]),
                            IdLector = (row["id_lector"]) == DBNull.Value ? null : (int?)(row["id_lector"]) // de donde sale id_lector?
                        };
                        libros.Add(libro);
                    }
                }
            }
            return libros;
        }
        public Libro GetByid(int idLibro)
        {
            Libro libro = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                const string sqlQuery = "SELECT * FROM Libro WHERE id_libro = @id_libro";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id_libro", idLibro);
                    DataTable table = new DataTable();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        libro = new Libro
                        {
                            Id = Convert.ToInt32(row["id_libro"]),
                          
                            Titulo = Convert.ToString(row["titulo"]),
                            ISBN = Convert.ToString(row["año"]),
                            IdLector = (row["id_lector"]) == DBNull.Value ? null : (int?)(row["id_lector"])
                        };
                    }
                }
            }
            return libro;
        }
      