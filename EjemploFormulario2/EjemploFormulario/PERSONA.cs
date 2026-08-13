using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploFormulario
{
    public class PERSONA
    {
		private int myDNI;
		private string myNombre;
		private string myApellido;

		public int DNI
		{
			get { return myDNI; }
			set { myDNI = value; }
		}
		public string Nombre
		{
			get { return myNombre; }
			set { myNombre = value; }
		}

        public string Apellido
        {
            get { return myApellido; }
            set { myApellido = value; }
        }

        public PERSONA()
        {
            
        }
        public PERSONA(int dni, string nombre, string apellido)
        {
            DNI= dni;
            Nombre= nombre;
            Apellido= apellido;
        }
    }
}
