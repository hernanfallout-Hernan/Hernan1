using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroMascotas
{
    public abstract class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        protected Mascota(int id, string nombre, int edad)
        {
            if (Id <= 0 || string.IsNullOrWhiteSpace(Nombre) || Edad < 0)
                throw new ArgumentException("Datos básicos inválidos (ID > 0, Nombre requerido, Edad >= 0).");
            Id = id;
            Nombre = nombre.Trim();
            Edad = edad;
        }
        public abstract string ObtenerInfo();
    }
}
