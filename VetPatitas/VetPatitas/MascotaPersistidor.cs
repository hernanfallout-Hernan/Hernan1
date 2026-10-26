using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vetpatitas;
using Microsoft.Data.SqlClient;
namespace VetPatitas;


public class MascotaPersistidor
{
    private readonly string connectionString = "Data Source=(localdb)\\servsql;Initial Catalog=VETERINARIA;Integrated Security=True";

    public int Insertar(Mascota m)
    {
        // Corregido: Se usa ClienteId en lugar de Id para asociar la clave foránea del dueño
        string query = @"INSERT INTO Mascota (Nombre, Especie, Edad,ClienteId) 
                         VALUES (@Nombre, @Especie, @Edad, @ClienteId);
                         SELECT SCOPE_IDENTITY();";

        using (var con = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
        using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Nombre", m.Nombre);
            cmd.Parameters.AddWithValue("@Especie", m.Especie);
            cmd.Parameters.AddWithValue("@Edad", m.Edad);
            cmd.Parameters.AddWithValue("@ClienteId", m.Duenio != null ? m.Duenio.Id : (object)DBNull.Value);

            con.Open();
            // Captura el ID autogenerado por la base de datos y se lo asigna a la mascota
            m.Id = Convert.ToInt32(cmd.ExecuteScalar());
            return m.Id;
        }
    }

    public List<Mascota> ObtenerPorCliente(int clienteId)
    {
        var lista = new List<Mascota>();
        // Corregido: Se usa connectionString y se filtra por ClienteId en vez de Id
        string query = "SELECT Id, Nombre, Especie, Edad FROM Mascota WHERE Id = @Id";

        using (var con = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
        using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Id", clienteId);
            con.Open();

            using (Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var mascota = new Mascota
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Especie = reader["Especie"].ToString(),
                        Edad = Convert.ToInt32(reader["Edad"])
                    };
                    lista.Add(mascota);
                }
            }
        }
        return lista;
    }

    public int ContarPorEspecie(string especie)
    {
        string query = "SELECT COUNT(*) FROM Mascota WHERE Especie = @Especie";

        // Corregido: Se usa connectionString
        using (var con = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
        using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con))// si dejo sqlCommand solo me salta un error que dice que es ambiguo
        {
            cmd.Parameters.AddWithValue("@Especie", especie);
            con.Open();

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    public DataTable ObtenerListado()
    {
        var dt = new DataTable();
        string query = @"SELECT m.Nombre AS [Nombre Mascota], m.Especie, c.Nombre AS [Nombre Dueño]
                         FROM Mascota m
                         INNER JOIN Cliente c ON m.ClienteId = c.Id";

        // Corregido: Se usa connectionString
        using (var con = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
        using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con))
        using (var da = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
        {
            da.Fill(dt);
        }
        return dt;
   
    }
}