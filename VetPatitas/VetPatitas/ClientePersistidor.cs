using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;



namespace VetPatitas;

public class ClientePersistidor
{
    private readonly string connectionString = "Data Source=(localdb)\\servsql;Initial Catalog=VETERINARIA;Integrated Security=True";

    public int Insertar(Cliente c)
    {
        string query = @"INSERT INTO Cliente (Dni, Nombre, Telefono) 
                         VALUES (@Dni, @Nombre, @Telefono);
                         SELECT SCOPE_IDENTITY();";

        using (var con = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
        using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Dni", c.Dni);
            cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
            // Si el teléfono es opcional (null), enviamos DBNull.Value de forma segura
            cmd.Parameters.AddWithValue("@Telefono", (object)c.Telefono ?? DBNull.Value);

            con.Open();
            c.Id = Convert.ToInt32(cmd.ExecuteScalar());
            return c.Id;
        }
    }

    public Cliente BuscarPorDni(string dni)
    {
        string query = "SELECT Id, Dni, Nombre, Telefono FROM Cliente WHERE Dni = @Dni";

        using (var con = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
        using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Dni", dni);
            con.Open();

            using (Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Cliente(
                        reader["Dni"].ToString(),
                        reader["Nombre"].ToString(),
                        reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : null
                    )
                    {
                        Id = Convert.ToInt32(reader["Id"])
                    };
                }
            }
        }
        return null;
    }

    public bool ExisteDni(string dni)
    {
        string query = "SELECT COUNT(*) FROM Cliente WHERE Dni = @Dni";

        // CORREGIDO: Se usa connectionString en lugar de _cadenaConexion
        using (var con = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
        using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Dni", dni);
            con.Open();

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }
    }

    public List<Cliente> ObtenerTodos()
    {
        var lista = new List<Cliente>();
        string query = "SELECT Id, Dni, Nombre, Telefono FROM Cliente";

        // CORREGIDO: Se usa connectionString en lugar de _cadenaConexion
        using (var con = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
        using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con))
        {
            con.Open();
            using (Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var cliente = new Cliente(
                        reader["Dni"].ToString(),
                        reader["Nombre"].ToString(),
                        reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : null
                    )
                    {
                        Id = Convert.ToInt32(reader["Id"])
                    };
                    lista.Add(cliente);
                }
            }
        }
        return lista;
    }
}