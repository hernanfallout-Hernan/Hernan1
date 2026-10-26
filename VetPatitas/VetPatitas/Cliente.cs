using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Vetpatitas;

namespace VetPatitas;

public class Cliente
{
    // Propiedades
    public int Id { get; set; }
    public string Dni { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public List<Mascota> Mascotas { get; set; }

    // Constructor que recibe DNI, nombre y teléfono, e inicializa la lista vacía
    public Cliente(string dni, string nombre, string telefono)
    {
        Dni = dni;
        Nombre = nombre;
        Telefono = telefono;
        Mascotas = new List<Mascota>();
    }

    // Agrega la mascota a la lista si no estaba y le asigna este cliente como dueño
    public void AgregarMascota(Mascota m)
    {
        if (m != null && !Mascotas.Contains(m))
        {
            m.Duenio = this;
            Mascotas.Add(m);
        }
    }

    // Devuelve cuántas mascotas tiene
    public int CantidadMascotas()
    {
        return Mascotas.Count;
    }

    // Muestra los datos del cliente y debajo la lista de sus mascotas
    public override string ToString()
    {
        string infoCliente = $"Cliente ID: {Id} | DNI: {Dni} | Nombre: {Nombre} | Teléfono: {Telefono}\nMascotas:";

        if (Mascotas.Count == 0)
        {
            return $"{infoCliente} Sin mascotas";
        }

        foreach (var m in Mascotas)
        {
         
            infoCliente += $"\n\t- {m.Nombre} ({m.Especie})";
        }

        return infoCliente;
    }
}