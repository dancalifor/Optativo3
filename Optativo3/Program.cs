using Optativo3.Repository.Data.Clientes;
using Optativo3.Repository.Data.Productos;
using Repository.Data.Clientes;
using Repository.Data.Facturas;
using Repository.Data.Productos;
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
            
            IClienteRepository clienteRepository = new ClienteRepository(connectionString);
            ClienteService clienteService = new ClienteService(clienteRepository);
            
            IProductoRepository productoRepository = new ProductoRepository(connectionString);
            ProductoService productoService = new ProductoService(productoRepository);
            
            IDetalleFacturaRepository detalleFacturaRepository = new DetalleFacturaRepository(connectionString);
            DetalleFacturaService detalleFacturaService = new DetalleFacturaService(detalleFacturaRepository);

            Console.WriteLine("Seleccione una opción: \n 1 - Clientes \n 2 - Productos \n 3 - Detalles de Factura");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                ManejarClientes(clienteService);
            }
            else if (opcion == "2")
            {
                ManejarProductos(productoService);
            }
            else if (opcion == "3")
            {
                ManejarDetallesFactura(detalleFacturaService);
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }

        static void ManejarClientes(ClienteService clienteService)
        {
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

        static void ManejarProductos(ProductoService productoService)
        {
            Console.WriteLine("Ingrese: \n a - para insertar producto \n b - para listar productos");
            string opcion = Console.ReadLine();

            if (opcion == "a")
            {
                InsertarProducto(productoService);
            }
            else if (opcion == "b")
            {
                ListarProductos(productoService);
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }

        static void InsertarProducto(ProductoService productoService)
        {
            try
            {
                productoService.Add(new ProductoModel
                {
                    Descripcion = "Laptop Dell XPS 13",
                    CantidadMinima = 5,
                    CantidadStock = 20,
                    PrecioCompra = 1200,
                    Categoria = "Electrónica",
                    Marca = "Dell",
                    Estado = "Activo"
                });
                Console.WriteLine("Producto insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar producto: {ex.Message}");
            }
        }

        static void ListarProductos(ProductoService productoService)
        {
            try
            {
                var productos = productoService.GetAll().ToList();
                if (productos.Any())
                {
                    productos.ForEach(producto =>
                    Console.WriteLine(
                        $"Descripción: {producto.Descripcion} \n " +
                        $"Cantidad Mínima: {producto.CantidadMinima} \n " +
                        $"Cantidad Stock: {producto.CantidadStock} \n " +
                        $"Precio Compra: {producto.PrecioCompra} \n " +
                        $"Categoría: {producto.Categoria} \n " +
                        $"Marca: {producto.Marca} \n " +
                        $"Estado: {producto.Estado} \n "
                        )
                    );
                }
                else
                {
                    Console.WriteLine("No hay productos registrados.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos: {ex.Message}");
            }
        }

        static void ManejarDetallesFactura(DetalleFacturaService detalleFacturaService)
        {
            Console.WriteLine("Ingrese: \n a - para insertar detalle de factura \n b - para listar detalles de factura");
            string opcion = Console.ReadLine();

            if (opcion == "a")
            {
                InsertarDetalleFactura(detalleFacturaService);
            }
            else if (opcion == "b")
            {
                ListarDetallesFactura(detalleFacturaService);
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }

        static void InsertarDetalleFactura(DetalleFacturaService detalleFacturaService)
        {
            try
            {
                detalleFacturaService.Add(new DetalleFacturaModel
                {
                    IdFactura = 1,
                    IdProducto = 2,
                    CantidadProducto = 3,
                    Subtotal = 3600
                });
                Console.WriteLine("Detalle de factura insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar detalle de factura: {ex.Message}");
            }
        }

        static void ListarDetallesFactura(DetalleFacturaService detalleFacturaService)
        {
            try
            {
                var detallesFactura = detalleFacturaService.GetAll().ToList();
                if (detallesFactura.Any())
                {
                    detallesFactura.ForEach(detalle =>
                    Console.WriteLine(
                        $"Id Factura: {detalle.IdFactura} \n " +
                        $"Id Producto: {detalle.IdProducto} \n " +
                        $"Cantidad Producto: {detalle.CantidadProducto} \n " +
                        $"Subtotal: {detalle.Subtotal} \n "
                        )
                    );
                }
                else
                {
                    Console.WriteLine("No hay detalles de factura registrados.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener detalles de factura: {ex.Message}");
            }
        }
    }
}
