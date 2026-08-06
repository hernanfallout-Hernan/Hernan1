using EjemploFormulario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploFormulario
{
    public class Consultorio
    {
        private const int myLegajo = 1;
        private const string myNombre = "Maximiliano Paz Consultorio";
        private List<PERSONA> MyPacientes;

        private Consultorio()
        {
            MyPacientes = new List<PERSONA>();
            MyPacientes.Add(new PERSONA(1, "Lucia", "Marquez"));
        }

        public bool Agregar(PERSONA p)
        {
            if (MyPacientes.FirstOrDefault(paci => paci.DNI == p.DNI) == null)
            {
                MyPacientes.Add(p);
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<PERSONA> DevolverPacientes()
        {
            return MyPacientes;

        }


        public bool Modificar(PERSONA p)
        {
            var existente = MyPacientes.FirstOrDefault(paci => paci.DNI == p.DNI);
            if (existente != null)
            {
                existente.Nombre = p.Nombre;
                existente.Apellido = p.Apellido;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Borrar(int dni)
        {
            var existente = MyPacientes.FirstOrDefault(paci => paci.DNI == dni);
            if (existente != null)
            {
                MyPacientes.Remove(existente);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<PERSONA> DevolverPacientes()
        {
            return MyPacientes;
        }
    }
}