 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RegistroMascotas
{
    public  class Mascota
    {


        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Tipo { get; set; }
        public string Dueno { get; set; }
        public string Raza { get; set; }

        public Mascota(int id, string nombre, int edad, string tipo, string dueno, string raza)
        {
            Id = id;
            Nombre = nombre;
            Edad = edad;
            Tipo = tipo;
            Dueno = dueno;
            Raza = raza;
        }
public Mascota()
            { }
        public override string ToString()
        {
          return $"{Nombre}({Edad}años)";
        }


    }
}
