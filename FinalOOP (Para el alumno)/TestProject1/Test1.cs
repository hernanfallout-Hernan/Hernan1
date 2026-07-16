using Dapper;
using FinalOOP;
using Microsoft.Data.SqlClient;
using System.Data;

namespace TestProject1
{
    [TestClass]
    [DoNotParallelize]
    public sealed class Test1
    {
        private Persistidor _persistidor = default!;

        // Se ejecuta antes de cada test para garantizar un entorno limpio
        [TestInitialize]
        public void Setup()
        {
            string connectionString = @"Data Source = .\SQLEXPRESS; Initial Catalog = ProductosDB; Integrated Security = True; TrustServerCertificate=True;";
            //string connectionString = @"Data Source = (localdb)\DatabaseLocalDB_X; Initial Catalog = ProductosDB; Integrated Security = True; TrustServerCertificate=True;";
            Helper.ConnectionString = connectionString;
            Helper.DeleteAll();
            _persistidor = new Persistidor(connectionString);
        }

        [TestMethod]
        public void Guardar_DeberiaRetornarId_CuandoElProductoSeGuardaCorrectamente()
        {
            // Arrange (Preparar)
            var producto = new Producto
            {
                Descripcion = "Fideos Tallarines",
                Marca = "Marolio",
                PrecioBase = 1200
            };

            // Act (Ejecutar)
            int id = _persistidor.Guardar(producto);

            // Assert (Verificar)
            Producto productoPersistido = Helper.SelectAll().First();
            Assert.AreEqual(productoPersistido.Id, id, "El método Guardar debería retornar el Id del producto insertado.");
        }

        [TestMethod]
        public void Guardar_DeberiaPersistirSusPropiedades()
        {
            // Arrange (Preparar)
            var producto = new Producto
            {
                Descripcion = "Fideo" + Guid.NewGuid().ToString(),
                Marca = "Marolio" + Guid.NewGuid().ToString(),
                PrecioBase = new Random().Next(1, 1000)
            };

            // Act (Ejecutar)
            int id = _persistidor.Guardar(producto);

            // Assert (Verificar)
            Producto productoPersistido = Helper.SelectAll().First();
            Assert.AreEqual(productoPersistido.Id, producto.Id, "El método Guardar debería setear o establecer el Id del producto insertado.");
            Assert.AreEqual(productoPersistido.Descripcion, producto.Descripcion, "El método Guardar no persistio la Descripcion.");
            Assert.AreEqual(productoPersistido.Marca, producto.Marca, "El método Guardar no persistio la Marca.");
            Assert.AreEqual(productoPersistido.PrecioBase, producto.PrecioBase, "El método Guardar no persistio el PrecioBase.");
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void Guardar_DeberiaLanzarExcepcion_SiFaltanCamposRequeridos()
        {
            // Arrange (Preparar)
            // 'Descripcion' es NOT NULL en nuestra base de datos. Si pasamos null, SQL Server debe fallar.
            var productoInvalido = new Producto
            {
                Descripcion = null,
                Marca = "Sin Descripcion",
                PrecioBase = 500
            };

            // Act & Assert (Se espera que lance SqlException debido al constraint NOT NULL)
            _persistidor.Guardar(productoInvalido);
        }

        [TestMethod]
        public void VerificarConexionBaseDeDatosOk()
        {
            // Arrange (Preparar)
            
            // Act (Ejecutar)
            bool exito = _persistidor.VerificarConexionBaseDeDatos();

            // Assert (Verificar)
            Assert.IsTrue(exito);
        }

        [TestMethod]
        public void ModificaUnProducto()
        {
            // Arrange (Preparar)
            var producto = new Producto
            {
                Id = null,
                Descripcion = "Fideo" + Guid.NewGuid().ToString(),
                Marca = "Marolio" + Guid.NewGuid().ToString(),
                PrecioBase = new Random().Next(1, 1000)
            };
            Helper.InsertOne(producto);

            // Modifica las propiedades
            producto.Descripcion = "Papa" + Guid.NewGuid().ToString();
            producto.Marca = "SuperPapa" + Guid.NewGuid().ToString();
            producto.PrecioBase = DateTime.Now.Second;

            // Act (Ejecutar)
            _persistidor.Guardar(producto); //Modifica o UPDATE en la base de datos

            // Assert (Verificar)
            var productos = Helper.SelectAll();
            Producto productoPersistido = productos.First();
            Assert.AreEqual(1, productos.Count);
            Assert.AreEqual(productoPersistido.Id, producto.Id, "El método Guardar debería setear o establecer el Id del producto insertado.");
            Assert.AreEqual(productoPersistido.Descripcion, producto.Descripcion, "El método Guardar no persistio la Descripcion.");
            Assert.AreEqual(productoPersistido.Marca, producto.Marca, "El método Guardar no persistio la Marca.");
            Assert.AreEqual(productoPersistido.PrecioBase, producto.PrecioBase, "El método Guardar no persistio el PrecioBase.");
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void ModificaUnProductoConNulos()
        {
            // Arrange (Preparar)
            var producto = new Producto
            {
                Id = null,
                Descripcion = "Fideo" + Guid.NewGuid().ToString(),
                Marca = "Marolio" + Guid.NewGuid().ToString(),
                PrecioBase = new Random().Next(1, 1000)
            };

            Helper.InsertOne(producto);

            // Modifica las propiedades
            Producto productoIncorrecto = producto;
            productoIncorrecto.Descripcion = null; //La base de datos no admite nulos para este campo.
            
            // Act (Ejecutar)
            _persistidor.Guardar(productoIncorrecto); //Intenta modificar o UPDATE en la base de datos

            // Assert (Verificar)            
        }

        [TestMethod]
        public void TraerPorPrecioBase_ConRegistros()
        {
            // Arrange (Preparar)
            List<Producto> productos = Helper.InsertProductos();

            int precioBase = productos[0].PrecioBase;

            // Act (Ejecutar)
            var productosFiltrados = _persistidor.Traer(precioBase);

            // Assert (Verificar)
            int count = productos.Where(p => p.PrecioBase == precioBase).ToList().Count;
            Assert.AreEqual(productosFiltrados.Count, count);
        }

        [TestMethod]
        public void TraerPorPrecioBase_SinRegistros()
        {
            // Arrange (Preparar)
            Helper.DeleteAll();

            // Act (Ejecutar)
            var productosFiltrados = _persistidor.Traer(0);

            // Assert (Verificar)
            Assert.AreEqual(0, productosFiltrados.Count,"La lista deberia tener cero items");
        }

        [TestMethod]
        public void InsertarProductos_ConError()
        {
            // Arrange (Preparar)
            List<Producto> productos = Helper.InsertProductos();
            foreach (Producto producto in productos) { producto.Marca = null; }

            // Act (Ejecutar)
            var errores = _persistidor.Insertar(productos); //Inserta productos

            // Assert (Verificar)            
            Assert.AreEqual(productos.Count, errores.Count);
        }

        [TestMethod]
        public void InsertarProductos_ConError_1()
        {
            // Arrange (Preparar)
            List<Producto> productos = Helper.InsertProductos();
            foreach (Producto producto in productos) { producto.Marca = null; }

            // Act (Ejecutar)
            var errores = _persistidor.Insertar(productos); //Inserta productos que ya existen en la base de datos.

            // Assert (Verificar)
            foreach (Exception error in errores)
            {                
               Assert.IsInstanceOfType(error, typeof(SqlException));
            }
        }

        [TestMethod]
        public void InsertarProductos_ConExito()
        {
            // Arrange (Preparar)
            List<Producto> productos = Helper.InsertProductos();
            foreach (Producto producto in productos) { producto.Id = null; }
            
            // Act (Ejecutar)
            var errores = _persistidor.Insertar(productos); //Inserta productos que ya existen en la base de datos.

            // Assert (Verificar)
            foreach (Exception error in errores)
            {
                Assert.IsNull(error, "El producto debió persistirse con existo.");
            }
        }

        [TestMethod]
        public void InsertarProductos_ConYSinError()
        {
            // Arrange (Preparar)
            Producto productoOk = new Producto()
            {
                Descripcion = "Fideos",
                Marca = "La Nona",
                PrecioBase = 10
            };

            Producto productoConError = new Producto()
            {
                Descripcion = null,
                Marca = null,
                PrecioBase = 0
            };

            var productos = new List<Producto>();
            productos.Add(productoOk);
            productos.Add(productoConError);

            // Act (Ejecutar)
            var errores = _persistidor.Insertar(productos);

            // Assert (Verificar)
            Assert.IsNull(errores[0], "El producto debió persistirse con existo.");
            Assert.IsNotNull(errores[1], "El producto no debió persistirse con existo.");
        }

        [TestMethod]
        public void DeleteMarcaRepetida_1()
        {
            // Arrange (Preparar)
            for(int i=0;  i < 4; i++)
            {
                Producto producto = new Producto()
                {
                    Descripcion = Guid.NewGuid().ToString(),
                    Marca = "La Nona",
                    PrecioBase = i
                };
                Helper.InsertOne(producto);
            }
            int idPrimerProducto = Helper.SelectAll()[0].Id!.Value;

            // Act (Ejecutar)
            _persistidor.DeleteMarcaRepetida();

            // Assert (Verificar)
            var productosInDB = Helper.SelectAll();
            Assert.AreEqual(1, productosInDB.Count);
            Assert.AreEqual(idPrimerProducto, productosInDB[0].Id!.Value);
            Assert.AreEqual("La Nona", productosInDB[0].Marca);
        }

        [TestMethod]
        public void DeleteMarcaRepetida_2()
        {
            // Arrange (Preparar)
            for (int i = 0; i < 4; i++)
            {
                Producto producto = new Producto()
                {
                    Descripcion = Guid.NewGuid().ToString(),
                    Marca = Guid.NewGuid().ToString(),
                    PrecioBase = i
                };
                Helper.InsertOne(producto);
            }

            // Act (Ejecutar)
            _persistidor.DeleteMarcaRepetida();

            // Assert (Verificar)
            var productosInDB = Helper.SelectAll();
            Assert.AreEqual(4, productosInDB.Count);
        }

        [TestMethod]
        public void DeleteMarcaRepetida_3()
        {
            // Arrange (Preparar)
            for (int i = 0; i < 4; i++)
            {
                Producto producto = new Producto()
                {
                    Descripcion = Guid.NewGuid().ToString(),
                    Marca = Guid.NewGuid().ToString(),
                    PrecioBase = i
                };
                Helper.InsertOne(producto);
                Helper.InsertOne(producto);
            }
            int countAntes = Helper.SelectAll().Count;    

            // Act (Ejecutar)
            _persistidor.DeleteMarcaRepetida();

            // Assert (Verificar)
            var productosInDB = Helper.SelectAll();
            Assert.AreEqual(4, productosInDB.Count);
            Assert.AreEqual(8, countAntes);
        }
    }
}
