using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{

    public class Persistidor
    {
        /// <summary>
        /// ConnectionString a utilizar por la aplicación.
        /// </summary>
        private string _ConnectionString;

        public Persistidor(string connString)
        {
            _ConnectionString = connString;
        }

        /// <summary>
        /// Método para insertar un nuevo alumno.
        /// </summary>
        /// <param name="alumno"></param>
        public void InsertarLibro(Libro libro)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = @"INSERT INTO libros
                                      [id_libro]
                                      [titulo] 
	                                  [año] 
                                 VALUES
                                       (@idlibros
                                       ,@titulolibro
                                       ,@añolibro)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idlibro", libro.idlibro);
                    command.Parameters.AddWithValue("@titulo", SerializarIds(libro.titulolibro));
                    command.Parameters.AddWithValue("@año", SerializarNombres(libro.añolibro));

                    connection.Open();
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    command.CommandText = "SELECT @@IDENTITY"; // no entiendo que vendria aca
                    object idObj = command.ExecuteScalar();

                    libro.Id = Convert.ToInt32(idObj);
                }
            }
        }
        public void ModificarLibro(Libro libro)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query =
                                      @"UPDATE libros
                                 SET    
                                        id_libro = @idlibros
                                       ,titulo = @titulolibros
                                       ,año = @añolibro
                                 WHERE 
                                        Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idlibros", libro.id_libro);
                    command.Parameters.AddWithValue("@titulolibros", libro.titulo);
                    command.Parameters.AddWithValue("@añolibro", libro.añolibro);
                    command.Parameters.AddWithValue("@Id", libro.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Libro> ObtenerTodosLosLibros()
        {
            List<Libro> libros = new List<Libro>();
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SELECT * FROM libros";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable table = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        string Titulolibro = row["titulolibro"].ToString();
                        string Añolibro = row["añolibro"].ToString();

                        Libro libro = new Libro();
                        libro.Id = Convert.ToInt32(row["Id"]);
                        libro.titulo = row["titulo"].ToString();
                        libro.Materias = DesSerializar(titulo, año);
                        libros.Add(libro);
                    }
                }
            }
            return libros; }
         public Libro ObtenerLibroPorId(int id)
        {
            Libro libros = null;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SELECT * FROM libros WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    DataTable table = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        string IdLibro = row["idlibro"].ToString();
                        string Titulo = row["titulo"].ToString();

                        libros = new Libro();
                        libros.Id = Convert.ToInt32(row["Id"]);
                        libros.titulo = row["titulo"].ToString();

                        libros.idaño = DesSerializar(id_libro, año);
                    }
                }
            }
            return libros;

            public List<Libro> ObtenerLibrosConMasTitulos()
        {
            List<Libro> LibrosMax = new List<Libro>();
            List<Libro> todos = ObtenerTodosLosLibros();
            int maximo = todos.Max(t => titulos.Count);
            alumnosMax = todos.Where(a => a.titulos.Count == maximo).ToList();
            return LibrosMax;
        }
        public List<Libro> ObtenerLibrosConTitulos(int n)
        {
            List<Libro> LibrosConNTitulos = new List<Libro>();
            List<Libro> todos = ObtenerTodosLosLibros();
            LibrosConTitulos = todos.Where(a => a.titulos.Count == n).ToList();
            return LibrosConTitulos;
        }
        public List<Libro> ObtenerLibrosConTitulos(string nombreTitulo)
        {
            List<Libro> LibrosConTitulos = new List<Libro>();
            List<Libro> todos = ObtenerTodosLosLibros();
            foreach (Libro libro in todos)
            {
                foreach (Titulo titulo in Libro.Titulos)
                {
                    if (Titulos.Nombre == nombreTitulo)
                    {
                        if (!LibrosConTitulo.Contains(libros))
                        {
                            LibrosConTitulo.Add(libros);
                        }
                    }
                }
            }
            return LibrosConTitulo;
        }

        public List<int> ObtenerLibrosCorruptos()
        {
            List<int> LibrosCorruptos = new List<int>();
            DataTable dataTable = SelectAll();
            foreach (DataRow registro in dataTable.Rows)
            {
                string ids = registro["id_libro"].ToString();
                string nombres = registro["titulo"].ToString();

                int numeroDeIds = ids.Split(',').Length;
                int numeroDeNombres = nombres.Split(',').Length;

                if (numeroDeIds != numeroDeNombres)
                {
                    //Existe una corrupción en los datos ya que el 
                    //número de ids debe ser igual al número de nombres.
                    int LibroId = Convert.ToInt32(registro["Id"]);
                   LibrosCorruptos.Add(LibroId);
                }
            }
            return LibrosCorruptos;
        }
        public void EliminarTitulo(int TituloId)
        {
            List<Libro> libros = ObtenerTodosLosLibros();
            foreach (Libros libros in Libros)
            {
                Libros.Titulo.RemoveAll(match => match.Id == materiaId);
                ModificarAlumno(libros);
            }
        }
        private DataTable SelectAll()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SELECT * FROM libros";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(table);
                }
            }
            return table;
        }
        private string SerializarIds(List<Titulo> titulos)
        {
            string serializado = string.Empty;
            string separador = "";
            foreach (var titulo in titulos)
            {
                serializado += separador + titulos.Id.ToString();
                separador = ",";
            }
            return serializado;
        }
        private string SerializarNombres(List<Titulo> titulos)
        {
            string serializado = string.Empty;
            string separador = "";
            foreach (var titulo in titulos)
            {
                serializado += separador + titulos.Nombre.ToString();
                separador = ",";
            }
            return serializado;
        }
        private static List<Titulos> DesSerializar(string titulosIds, string titulosNombres)
        {
            List<Titulo> titulos = new List<Titulo>();
            bool existenTitulos = tituloIds.Length != 0 && tituloNombres.Length != 0;
            if (existenMaterias)
            {
                //DesSerializa
                string[] ids = tituloIds.Split(',');
                string[] nombres = tituloNombres.Split(',');
                for (int i = 0; i < nombres.Length; i++)
                {
                    Titulo titulo = new Titulo();
                    titulo.Id = Convert.ToInt32(ids[i]);
                    titulo.Nombre = nombres[i];

                   titulos.Add(titulo);
                }
            }
            return titulos;