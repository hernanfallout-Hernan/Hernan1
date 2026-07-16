namespace FinalOOP
{
    /// <summary>
    /// Maneja las acciones Altas, Bajas y Modificaciones, (NO consultas) de persistencia sobre la base de datos.    
    /// </summary>
    public interface IProductoRepository
    {
        /// <summary>
        /// Inserta (INSERT) o Modifica (UPDATE) un producto en la base de datos.
        /// Dependiendo del valor nulo o numérico de la propiedad Id del producto.
        /// </summary>
        /// <remarks>
        /// El método debe setear o establecer el valor del Id del producto dado por la base de datos.
        /// </remarks>
        /// <param name="producto">
        /// Producto a persistir.
        /// </param>
        /// <returns>
        /// El Id dado por la base de datos del producto insertado.
        /// </returns>
        int Guardar(Producto producto);

        /// <summary>
        /// Inserta de forma masiva una lista de productos, controlando las excepciones de manera individual por cada ítem.
        /// </summary>
        /// <param name="productos">Colección de productos que se desean persistir.</param>
        /// <returns>
        /// Una lista paralela de excepciones con la misma cantidad de elementos que el parámetro de entrada. 
        /// Contiene <c>null</c> en las posiciones donde la inserción fue exitosa y el objeto <see cref="Exception"/> donde falló.
        /// </returns>
        List<Exception?> Insertar(List<Producto> productos);

        /// <summary>
        /// Identifica y elimina de la base de datos los productos que tengan marcas repetidas,
        /// conservando únicamente el primer producto encontrado, dejando después del proceso 
        /// solo productos con marcas distintas.
        /// </summary>
        void DeleteMarcaRepetida();
    }
}
