using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroMascotas
{
    public abstract class MascotaExotica : Mascota
    {
        public string PermisoFauna { get; set; }
        public abstract string Prevencion { get; }
        protected MascotaExotica(int id, string nombre, int edad,string tipo,string dueno,string raza, string permiso) : base(id, nombre, edad,tipo,dueno,raza)
        {
            if (string.IsNullOrWhiteSpace(permiso)) throw new ArgumentException("Permiso de fauna obligatorio.");
            PermisoFauna = permiso.Trim();
        }
    }
    public class Iguana : MascotaExotica
    {
        public double LargoCm { get; set; }
        public override string Prevencion => " Mantener uñas cortas y hocico limpio ";
        public Iguana(int id, string nombre, int edad,string tipo,string dueno,string raza, string permiso, double largo) : base(id, nombre, edad,"Iguana", dueno,raza, permiso) => LargoCm = largo > 0 ? largo : throw new ArgumentException("Largo inválido.");
        public  string ObtenerInfo() =>
                $"[Iguana] ID: {Id} | {Nombre} ({Edad}a) | Permiso: {PermisoFauna} | Largo: {LargoCm}cm | Prevención: {Prevencion}";
    }
    public class Loro : MascotaExotica
    {
        public bool Habla { get; set; }
        public override string Prevencion => "Mantener jaula limpia y pico humectado";
        public Loro(int id, string nombre, int edad,string tipo, string dueno,string raza, string permiso, bool habla) : base(id, nombre, edad,"Loro",dueno,raza, permiso) => Habla = habla;
        public  string ObtenerInfo() => $"[Loro] ID: {Id} | {Nombre} ({Edad}a) | Permiso: {PermisoFauna} | Habla: {(Habla ? "Sí" : "No")} | Prevención: {Prevencion}";
    }
}

 