using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroMascotas
{
    public class Refugio
    {
        private readonly List<Mascota> _lista = new List<Mascota>();
        public IReadOnlyList<Mascota> Listar() => _lista.AsReadOnly();
        public void Agregar(Mascota m)
        {
            if (_lista.Any(x => x.Id == m.Id)) throw new InvalidOperationException($"El ID {m.Id} ya existe.");
            _lista.Add(m);
        }
        public void Modificar(Mascota m)
        {
int i=_lista.FindIndex(x=> x.Id== m.Id);
            if (i == -1) throw new KeyNotFoundException($"Mascota ID {m.Id} no encontrada.");
            _lista[i] = m;
        }
        public bool Eliminar(int id) => _lista.RemoveAll(x => x.Id == id) > 0;
    }
}
