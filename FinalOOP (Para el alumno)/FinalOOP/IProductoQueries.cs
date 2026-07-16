namespace FinalOOP
{
    /// <summary>
    /// Responsable de las consultas a la base de datos.
    /// </summary>
    internal interface IProductoQueries
    {
        /// <summary>
        /// Lee desde la base de datos todos los registros con el precioBase indicado.
        /// </summary>
        /// <param name="precioBase">
        /// Filtro a realizar por igual precioBase.
        /// </param>
        /// <returns>
        /// Lista de registros con el precioBase indicado.
        /// </returns>
        List<Producto> Traer(int precioBase);
    }
}
