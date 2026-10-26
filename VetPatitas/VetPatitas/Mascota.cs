using System;
using System.Collections.Generic;
using System.Text;
namespace Vetpatitas;

using System.Data.SqlClient;
using VetPatitas;

public class Mascota
{
    // Propiedades
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Especie { get; set; }
    public int Edad { get; set; }
    public decimal Peso { get; set; }
    public Cliente? Duenio { get; set; }

    public Mascota(int id, string nombre, string especie, int edad, decimal peso, Cliente? duenio)
    {
        Id = id;
        Nombre = nombre;
        Especie = especie;
        Edad = edad;
        Peso = peso;
        Duenio = duenio; 
    }
    public Mascota() { }

    // Muestra nombre, especie, edad, peso y el nombre del dueño
    public override string ToString()
    {
        // CORREGIDO: Se descomenta la variable para que pueda ser leída por el string interpolado
        string nombreDuenio = Duenio != null ? Duenio.Nombre : "Sin dueño asignado";
        return $"Mascota: {Nombre} | Especie: {Especie} | Edad: {Edad} años | Peso: {Peso}kg | Dueño: {nombreDuenio}";
    }
}