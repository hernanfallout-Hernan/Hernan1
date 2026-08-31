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
       
        public string InstruccionesCuidado {  get; set; } 

        protected MascotaDomestica(int id,string nombre,int edad, string tipo,string dueno, string raza): base(id, nombre,edad,"domestica",dueno,raza)
        {
            if (string.IsNullOrWhiteSpace(dueno)) throw new ArgumentException("El dueño es obligatorio.");
            
        }
    }
    public class Perro: MascotaDomestica
    {
       
        public int PaseosDiarios {  get; set; }
        public Perro( int id,string nombre, int edad,string tipo,string dueño,string raza,int paseos): base( id, nombre, edad,"Perro", dueño,raza)
        {
if (string.IsNullOrWhiteSpace(raza) || paseos < 0) throw new ArgumentException("Raza y paseos válidos requeridos.");
            Raza = raza.Trim();
            PaseosDiarios= paseos;
            Legajo = $"PE-{Id:D4}";
        }
public  string ObtenerInfo()=>
            $"[Perro] Legajo: {Legajo} | {Nombre} ({Edad}a) | Dueño: {Dueno} | Raza: {Raza} | Paseos: {PaseosDiarios}/día | Cuidado: {InstruccionesCuidado}"; }
}
public class Gato : MascotaDomestica
{
    public bool EsInterior { get; set; }

    public Gato(int id, string nombre, int edad,string tipo, string dueño,string raza, bool esInterior)
        : base(id, nombre, edad,"Gato", dueño,raza)
    {
        EsInterior = esInterior;
        Legajo = $"GA-{Id:D4}";
    }

public  string ObtenerInfo() =>
            $"[Gato] Legajo: {Legajo} | {Nombre} ({Edad}a) | Dueño: {Dueno} | Hábitat: {(EsInterior ? "Interior" : "Exterior")} | Cuidado: {InstruccionesCuidado}";
}
