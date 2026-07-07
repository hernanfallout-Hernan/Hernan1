using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosABMC
{
    public class Producto
    {
        public int? Id { get; set; } //Nullable<int>

        public string Descripcion { get; set; }
        public string Marca { get; set; }

        public double Precio { get; set; }
    }
}
