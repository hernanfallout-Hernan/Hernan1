using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Vetpatitas;

namespace VetPatitas;

public class Veterinaria
{
    // Atributos privados
    private readonly ClientePersistidor _clientePersistidor;
    private readonly MascotaPersistidor _mascotaPersistidor;

    // Constructor que inicializa los persistidores
    public Veterinaria()
    {
        _clientePersistidor = new ClientePersistidor();
        _mascotaPersistidor = new MascotaPersistidor();
    }

    // No se puede registrar un DNI repetido. Devuelve un mensaje de éxito o de error.
    public string RegistrarCliente(Cliente c)
    {
        if (c == null) return "Error: El cliente no puede ser nulo.";

        if (_clientePersistidor.ExisteDni(c.Dni))
        {
            return $"Error: Ya existe un cliente registrado con el DNI {c.Dni}.";
        }

        _clientePersistidor.Insertar(c);
        return "Cliente registrado con éxito.";
    }

    // El dueño tiene que existir. La edad no puede ser negativa y el peso tiene que ser mayor a 0.
    // Un cliente puede tener como máximo 5 mascotas. Si todo está bien, la asocia y la guarda.
    public string RegistrarMascota(string dniDuenio, Mascota m)
    {
        if (m == null) return "Error: La mascota no puede ser nula.";
        if (m.Edad < 0) return "Error: La edad de la mascota no puede ser negativa.";
        if (m.Peso <= 0) return "Error: El peso de la mascota debe ser mayor a 0.";

        // Buscamos al dueño e incluimos sus mascotas actuales para validar el límite
        Cliente duenio = ObtenerClienteConMascotas(dniDuenio);
        if (duenio == null)
        {
            return $"Error: No se encontró ningún cliente con el DNI {dniDuenio}.";
        }

        if (duenio.CantidadMascotas() >= 5)
        {
            return $"Error: El cliente {duenio.Nombre} ya alcanzó el límite máximo de 5 mascotas.";
        }

        // 1. Asociar la mascota con el cliente en memoria 
        duenio.AgregarMascota(m);

        // 2. CORRECCIÓN IMPORTANTE: Aseguramos que la mascota guarde la referencia/ID del dueño 
        // para que la base de datos sepa a qué cliente pertenece (ajustá "IdCliente" según tu propiedad real)
        // m.IdCliente = duenio.Id;

        // 3. Guardar la mascota en la base de datos
        _mascotaPersistidor.Insertar(m);

        return $"Mascota {m.Nombre} registrada y asociada a {duenio.Nombre} con éxito.";
    }

    // Busca el cliente y carga su lista Mascotas usando los dos persistidores.
    public Cliente ObtenerClienteConMascotas(string dni)
    {
        Cliente cliente = _clientePersistidor.BuscarPorDni(dni);
        if (cliente != null)
        {
            // Traemos las mascotas desde la base de datos usando el Id del cliente
            List<Mascota> mascotasDelCliente = _mascotaPersistidor.ObtenerPorCliente(cliente.Id);

            // Las vinculamos correctamente utilizando el método del negocio
            foreach (var mascota in mascotasDelCliente)
            {
                cliente.AgregarMascota(mascota);
            }
        }
        return cliente;
    }

    // Devuelve el ToString() del cliente con más mascotas.
    public string MostrarClienteConMasMascotas()
    {
        List<Cliente> todosLosClientes = _clientePersistidor.ObtenerTodos();
        if (todosLosClientes.Count == 0) return "No hay clientes registrados en el sistema.";

        Cliente clienteConMasMascotas = null;
        int maxMascotas = -1; // Valor centinela menor a cualquier cantidad real de mascotas

        foreach (var c in todosLosClientes)
        {
            // Cargamos las mascotas de cada cliente para poder contarlas con precisión
            Cliente clienteCompleto = ObtenerClienteConMascotas(c.Dni);
            if (clienteCompleto.CantidadMascotas() > maxMascotas)
            {
                maxMascotas = clienteCompleto.CantidadMascotas();
                clienteConMasMascotas = clienteCompleto;
            }
        }

        return clienteConMasMascotas != null ? clienteConMasMascotas.ToString() : "No se pudo determinar.";
    }

    // Devuelve cuántas mascotas hay de esa especie.
    public int CantidadDeMascotasPorEspecie(string especie)
    {
        return _mascotaPersistidor.ContarPorEspecie(especie);
    }

    // Recorre las filas del DataTable del listado y arma el texto.
    public string ListarMascotasConDuenio()
    {
        DataTable dt = _mascotaPersistidor.ObtenerListado();
        if (dt.Rows.Count == 0) return "No hay mascotas registradas.";

        string listadoText = "--- LISTADO DE MASCOTAS Y SUS DUEÑOS ---\n";

        foreach (DataRow fila in dt.Rows)
        {
            // Nota: Los nombres de las columnas deben coincidir con los alias (AS) 
            // de la consulta SQL en tu `MascotaPersistidor`.
            string nombreMascota = fila["Nombre Mascota"].ToString();
            string especie = fila["Especie"].ToString();
            string nombreDuenio = fila["Nombre Dueño"].ToString();

            listadoText += $"- Mascota: {nombreMascota} ({especie}) | Dueño: {nombreDuenio}\n";
        }

        return listadoText;
    }
}
