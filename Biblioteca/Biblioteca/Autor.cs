using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Autor
    { private int id_autor;
        private string nombre;
        private string apellido;
        private DateTime fecha_nac;

        internal Autor(int IDAutor,string Nombre, string Apellido,DateTime Fecha_Nac)
        {
            id_autor = IDAutor;
            nombre = Nombre;
            apellido = Apellido;
            fecha_nac = Fecha_Nac;


           }
    }
}
