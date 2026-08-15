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
        protected MascotaExotica(int id, string nombre, int edad, string permiso) : base(id, nombre, edad)
        {
            if (string.IsNullOrWhiteSpace(permiso)) throw new ArgumentException("Permiso de fauna obligatorio.");
            PermisoFauna = permiso.Trim();
        }
    }
    public class Iguana : MascotaExotica
    {
        public double LargoCm { get; set; }
        public override string Prevencion => " Mantener uñas cortas y hocico limpio ";
        public Iguana(int id, string nombre, int edad, string permiso, double largo) : base(id, nombre, edad, permiso) => LargoCm = largo > 0 ? largo : throw new ArgumentException("Largo inválido.");
        public override string ObtenerInfo() =>
                $"[Iguana] ID: {Id} | {Nombre} ({Edad}a) | Permiso: {PermisoFauna} | Largo: {LargoCm}cm | Prevención: {Prevencion}";
    }
    public class Loro : MascotaExotica
    {
        public bool Habla { get; set; }
        public override string Prevencion => "Mantener jaula limpia y pico humectado";
        public Loro(int id, string nombre, int edad, string permiso, bool habla) : base(id, nombre, edad, permiso) => Habla = habla;
        public override string ObtenerInfo() => $"[Loro] ID: {Id} | {Nombre} ({Edad}a) | Permiso: {PermisoFauna} | Habla: {(Habla ? "Sí" : "No")} | Prevención: {Prevencion}";
    }
}

 