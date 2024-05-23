using Optativo3.Repository.Data.Clientes;
using Repository.Data.Clientes;
using Repository.Data.Facturas;
using Services.Logica;
using System;
using System.Linq;

namespace Optativo3
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;port=5432;Database=optativo;Username=postgres;Password=0000;";
            ClienteService clienteService = new ClienteService(connectionString);

            Console.WriteLine("Ingrese: \n a - para insertar cliente \n b - para listar clientes");
            string opcion = Console.ReadLine();

            if (opcion == "a")
            {
                InsertarCliente(clienteService);
            }
            else if (opcion == "b")
            {
                ListarClientes(clienteService);
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }

        static void InsertarCliente(ClienteService clienteService)
        {
            try
            {
                clienteService.Add(new ClienteModel
                {
                    Nombre = "Juan",
                    Apellido = "Perez Sarela",
                    Documento = "456783",
                    Email = "",
                    Direccion = "",
                    Celular = "",
                    Estado = "Activo"
                });
                Console.WriteLine("Cliente insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar cliente: {ex.Message}");
            }
        }

        static void ListarClientes(ClienteService clienteService)
        {
            try
            {
                var clientes = clienteService.GetAll().ToList();
                if (clientes.Any())
                {
                    clientes.ForEach(cliente =>
                    Console.WriteLine(
                        $"Nombre: {cliente.Nombre} \n " +
                        $"Apellido: {cliente.Apellido} \n " +
                        $"Documento: {cliente.Documento} \n " +
                        $"Correo: {cliente.Email} \n " +
                        $"Estado: {cliente.Estado} \n "
                        )
                    );
                }
                else
                {
                    Console.WriteLine("No hay clientes registrados.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener clientes: {ex.Message}");
            }
        }
    }
}
