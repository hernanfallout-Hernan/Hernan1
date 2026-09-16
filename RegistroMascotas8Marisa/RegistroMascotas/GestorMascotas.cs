

using RegistroMascotas;
using System;
using System.Collections.Generic;
using System.Linq;
namespace RegistroMascotas
{
    public class GestorMascotas
    {
        public List<Mascota> Lista { get; } = new List<Mascota>();

        public void Agregar(Mascota mascotax)
        {
        foreach (Mascota mascotita in Lista)
         {
         if (mascotita.Id == mascotax.Id)
        {
            throw new Exception("No se puede agregar");

          }
          }
         Lista.Add(mascotax);
        }
      

        public void Eliminar(Mascota m)
        {
            bool flag = false;
            foreach (Mascota iterador in Lista)
            {
                if (iterador == m)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                Lista.Remove(m);
            }
            else
            {
                throw new Exception("la mascota no existe en la lista");
            }
        }

        public void Modificar(Mascota m)
  
        {
            bool flag = false;
            Mascota existente = null;

            foreach (Mascota iterador in Lista)
            {
                if (iterador.Id == m.Id)
                {
                    flag = true;
                    existente = iterador;
                    break;
                }
            }

            if (flag)
            {
                existente.Nombre = m.Nombre;
                existente.Edad = m.Edad;
                existente.Tipo = m.Tipo;
                existente.Dueno = m.Dueno;
                existente.Raza = m.Raza;
            }
            else
            {
                throw new Exception("la mascota no existe en la lista");
            }
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
     
private int ObtenerSiguienteId()
{
    if (Lista.Count == 0)
    {
        return 1;
    }

    int max = Lista[Lista.Count - 1].Id;
    max = max + 1;
    return max;
}
    }
}