using RegistroMascotas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroMascotas
{
    public abstract class MascotaDomestica: Mascota
    {
        public string Legajo {  get; set; }
            public string Dueño {  get; set; }
        public string InstruccionesCuidado {  get; set; } 
        protected MascotaDomestica(int id,string nombre,int edad,string dueño): base(id, nombre,edad)
        {
            if (string.IsNullOrWhiteSpace(dueño)) throw new ArgumentException("El dueño es obligatorio.");
            Dueño = dueño.Trim();
        }
    }
    public class Perro: MascotaDomestica
    {
        public string Raza { get; set; }
        public int PaseosDiarios {  get; set; }
        public Perro( int id,string nombre, int edad, string dueño,string raza,int paseos): base( id, nombre, edad, dueño)
        {
if (string.IsNullOrWhiteSpace(raza) || paseos < 0) throw new ArgumentException("Raza y paseos válidos requeridos.");
            Raza = raza.Trim();
            PaseosDiarios= paseos;
            Legajo = $"PE-{Id:D4}";
        }
public override string ObtenerInfo()=>
            $"[Perro] Legajo: {Legajo} | {Nombre} ({Edad}a) | Dueño: {Dueño} | Raza: {Raza} | Paseos: {PaseosDiarios}/día | Cuidado: {InstruccionesCuidado}"; }
}
public class Gato : MascotaDomestica
{
    public bool EsInterior { get; set; }

    public Gato(int id, string nombre, int edad, string dueño, bool esInterior)
        : base(id, nombre, edad, dueño)
    {
        EsInterior = esInterior;
        Legajo = $"GA-{Id:D4}";
    }

public override string ObtenerInfo() =>
            $"[Gato] Legajo: {Legajo} | {Nombre} ({Edad}a) | Dueño: {Dueño} | Hábitat: {(EsInterior ? "Interior" : "Exterior")} | Cuidado: {InstruccionesCuidado}";
}
