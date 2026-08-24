

using RegistroMascotas;
using System;
using System.Collections.Generic;
using System.Linq;
namespace RegistroMascotas
{
    public class GestorMascotas
    {
        public List<Mascota> Lista { get; } = new List<Mascota>();

        public void Agregar(Mascota m) => Lista.Add(m);

        public void Eliminar(Mascota m) => Lista.Remove(m);

        public void Modificar(Mascota m)
        {
            var existente = Lista.FirstOrDefault(x => x.Id == m.Id);
            if (existente == null) return;

            existente.Nombre = m.Nombre;
            existente.Edad = m.Edad;
            existente.Tipo = m.Tipo;
            existente.Dueno = m.Dueno;
            existente.Raza = m.Raza;
        }

        public Mascota BuscarPorId(int id)
        {

            return Lista.FirstOrDefault(m => m.Id == id);
        }


    public List<Mascota> BuscarPorTipo(string tipo)
        => Lista.Where(m => m.Tipo.ToLower() == tipo?.ToLower()).ToList();

        public double CalcularPromedioEdad()
            => Lista.Any() ? Lista.Average(m => m.Edad) : 0;

        public int ContarPorTipo(string tipo)
            => Lista.Count(m => m.Tipo.ToLower() == tipo?.ToLower());
    } }
 