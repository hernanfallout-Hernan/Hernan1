using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalOOP
{
    public abstract class ConectorBase
    {
        
        protected ConectorBase(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Unico ConnectionString a la base de datos para toda la aplicacion.
        /// </summary>
        protected string ConnectionString { get; }

        /// <summary>
        /// Verifica si la cadena de conexión actual permite establecer una conexión exitosa con la base de datos.
        /// </summary>
        /// <returns>
        /// <c>true</c> si la conexión se abrió correctamente; de lo contrario, <c>false</c>.
        /// </returns>
        public abstract bool VerificarConexionBaseDeDatos();
    }
}
