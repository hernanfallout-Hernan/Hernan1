using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Vetpatitas;
using VetPatitas;
namespace VetPatitas;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== INICIANDO PRUEBAS DEL SISTEMA VETERINARIA ===");

        // Creamos la instancia de la clase gestora
        Veterinaria veterinaria = new Veterinaria();

        // --------------------------------------------------------------------
        // 1. Registrar dos clientes
        // --------------------------------------------------------------------
        Console.WriteLine("\n[1] Registrando dos clientes...");
        Cliente cliente1 = new Cliente("11111111", "Juan Pérez", "11223344");
        Cliente cliente2 = new Cliente("22222222", "María López", "55667788");

        Console.WriteLine("Cliente 1: " + veterinaria.RegistrarCliente(cliente1));
        Console.WriteLine("Cliente 2: " + veterinaria.RegistrarCliente(cliente2));

        // --------------------------------------------------------------------
        // 2. Intentar registrar un cliente con un DNI repetido (Debe mostrar error)
        // --------------------------------------------------------------------
        Console.WriteLine("\n[2] Intentando registrar cliente con DNI repetido...");
        Cliente clienteRepetido = new Cliente("11111111", "Carlos Gómez", "99999999");
        Console.WriteLine(veterinaria.RegistrarCliente(clienteRepetido));

        // --------------------------------------------------------------------
        // 3. Registrar tres mascotas: dos para el primer cliente y una para el segundo
        // (CORREGIDO: Se usa el constructor de la clase Mascota pasando los 6 parámetros)
        // --------------------------------------------------------------------
        Console.WriteLine("\n[3] Registrando tres mascotas...");
        Mascota mascota1 = new Mascota(0, "Firulais", "Perro", 3, 12.5m,null);
        Mascota mascota2 = new Mascota(0, "Michi", "Gato", 2, 4.2m, null);
        Mascota mascota3 = new Mascota(0, "Rex", "Perro", 5, 25.0m, null);

        Console.WriteLine("Mascota 1 (Juan): " + veterinaria.RegistrarMascota("11111111", mascota1));
        Console.WriteLine("Mascota 2 (Juan): " + veterinaria.RegistrarMascota("11111111", mascota2));
        Console.WriteLine("Mascota 3 (María): " + veterinaria.RegistrarMascota("22222222", mascota3));

        // --------------------------------------------------------------------
        // 4. Intentar registrar una mascota a un DNI que no existe (Debe mostrar error)
        // --------------------------------------------------------------------
        Console.WriteLine("\n[4] Intentando registrar mascota a dueño inexistente...");
        Mascota mascotaInvalidaDuenio = new Mascota(0, "Lassie", "Perro", 4, 18.0m, null);
        Console.WriteLine(veterinaria.RegistrarMascota("99999999", mascotaInvalidaDuenio));

        // --------------------------------------------------------------------
        // 5. Intentar registrar una mascota con peso 0 (Debe mostrar error)
        // --------------------------------------------------------------------
        Console.WriteLine("\n[5] Intentando registrar mascota con peso 0...");
        Mascota mascotaInvalidaPeso = new Mascota(0, "Chiquito", "Perro", 1, 0m,null);
        Console.WriteLine(veterinaria.RegistrarMascota("11111111", mascotaInvalidaPeso));

        // --------------------------------------------------------------------
        // 6. Mostrar el primer cliente con todas sus mascotas
        // --------------------------------------------------------------------
        Console.WriteLine("\n[6] Mostrando el primer cliente con sus mascotas...");
        Cliente juanCompleto = veterinaria.ObtenerClienteConMascotas("11111111");
        if (juanCompleto != null)
        {
            Console.WriteLine(juanCompleto.ToString());
        }
        else
        {
            Console.WriteLine("No se encontró al cliente.");
        }

        // --------------------------------------------------------------------
        // 7. Mostrar cuántos perros hay
        // --------------------------------------------------------------------
        Console.WriteLine("\n[7] Contando mascotas de la especie 'Perro'...");
        int cantidadPerros = veterinaria.CantidadDeMascotasPorEspecie("Perro");
        Console.WriteLine($"Cantidad total de perros en el sistema: {cantidadPerros}");

        // --------------------------------------------------------------------
        // 8. Mostrar el cliente con más mascotas
        // --------------------------------------------------------------------
        Console.WriteLine("\n[8] Buscando al cliente con más mascotas...");
        Console.WriteLine(veterinaria.MostrarClienteConMasMascotas());

        // --------------------------------------------------------------------
        // 9. Mostrar el listado completo de mascotas con su dueño
        // --------------------------------------------------------------------
        Console.WriteLine("\n[9] Mostrando listado completo (DataTable transformado)...");
        Console.WriteLine(veterinaria.ListarMascotasConDuenio());

        Console.WriteLine("\n=== FIN DE LAS PRUEBAS ===");
        Console.ReadLine();  
    }
}

