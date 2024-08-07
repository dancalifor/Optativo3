﻿using Optativo3.Models;
using Optativo3.Repository.Data.Clientes;
using Optativo3.Repository.Data.PedidosCompra;
using Optativo3.Repository.Data.Productos;
using Optativo3.Services.Logica;
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

            IProveedorRepository proveedorRepository = new ProveedorRepository(connectionString);
            ProveedorService proveedorService = new ProveedorService(proveedorRepository);

            IPedidoCompraRepository pedidoCompraRepository = new PedidoCompraRepository(connectionString);
            PedidoCompraService pedidoCompraService = new PedidoCompraService(pedidoCompraRepository);

            Console.WriteLine("Seleccione una opción: \n 1 - Clientes \n 2 - Productos \n 3 - Detalles de Factura \n 4 - Proveedores \n 5 - Pedidos de Compra");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ManejarClientes(clienteService);
                    break;
                case "2":
                    ManejarProductos(productoService);
                    break;
                case "3":
                    ManejarDetallesFactura(detalleFacturaService);
                    break;
                case "4":
                    ManejarProveedores(proveedorService);
                    break;
                case "5":
                    ManejarPedidosCompra(pedidoCompraService);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        static void ManejarClientes(ClienteService clienteService)
        {
            Console.WriteLine("Ingrese: \n a - para insertar cliente \n b - para listar clientes");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "a":
                    InsertarCliente(clienteService);
                    break;
                case "b":
                    ListarClientes(clienteService);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
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

            switch (opcion)
            {
                case "a":
                    InsertarProducto(productoService);
                    break;
                case "b":
                    ListarProductos(productoService);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
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

            switch (opcion)
            {
                case "a":
                    InsertarDetalleFactura(detalleFacturaService);
                    break;
                case "b":
                    ListarDetallesFactura(detalleFacturaService);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
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

        static void ManejarProveedores(ProveedorService proveedorService)
        {
            Console.WriteLine("Ingrese: \n a - para insertar proveedor \n b - para listar proveedores");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "a":
                    InsertarProveedor(proveedorService);
                    break;
                case "b":
                    ListarProveedores(proveedorService);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        static void InsertarProveedor(ProveedorService proveedorService)
        {
            try
            {
                proveedorService.Add(new ProveedorModel
                {
                    RazonSocial = "Proveedor ABC",
                    TipoDocumento = "RUC",
                    NumeroDocumento = "1234567890",
                    Direccion = "Av. Principal 456",
                    Mail = "proveedor@proveedor.com",
                    Celular = "987654321",
                    Estado = "Activo"
                });
                Console.WriteLine("Proveedor insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar proveedor: {ex.Message}");
            }
        }

        static void ListarProveedores(ProveedorService proveedorService)
        {
            try
            {
                var proveedores = proveedorService.GetAll().ToList();
                if (proveedores.Any())
                {
                    proveedores.ForEach(proveedor =>
                    Console.WriteLine(
                        $"Razón Social: {proveedor.RazonSocial} \n " +
                        $"Tipo de Documento: {proveedor.TipoDocumento} \n " +
                        $"Número de Documento: {proveedor.NumeroDocumento} \n " +
                        $"Dirección: {proveedor.Direccion} \n " +
                        $"Correo: {proveedor.Mail} \n " +
                        $"Estado: {proveedor.Estado} \n "
                        )
                    );
                }
                else
                {
                    Console.WriteLine("No hay proveedores registrados.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener proveedores: {ex.Message}");
            }
        }

        static void ManejarPedidosCompra(PedidoCompraService pedidoCompraService)
        {
            Console.WriteLine("Ingrese: \n a - para insertar pedido de compra \n b - para listar pedidos de compra");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "a":
                    InsertarPedidoCompra(pedidoCompraService);
                    break;
                case "b":
                    ListarPedidosCompra(pedidoCompraService);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        static void InsertarPedidoCompra(PedidoCompraService pedidoCompraService)
        {
            try
            {
                pedidoCompraService.Add(new PedidoCompraModel
                {
                    IdProveedor = 1,
                    FechaHora = DateTime.Now,
                    Total = 5000
                });
                Console.WriteLine("Pedido de compra insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar pedido de compra: {ex.Message}");
            }
        }

        static void ListarPedidosCompra(PedidoCompraService pedidoCompraService)
        {
            try
            {
                var pedidosCompra = pedidoCompraService.GetAll().ToList();
                if (pedidosCompra.Any())
                {
                    pedidosCompra.ForEach(pedido =>
                    Console.WriteLine(
                        $"ID Proveedor: {pedido.IdProveedor} \n " +
                        $"Fecha y Hora: {pedido.Fecha_Hora} \n " +
                        $"Total: {pedido.Total} \n "
                        )
                    );
                }
                else
                {
                    Console.WriteLine("No hay pedidos de compra registrados.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener pedidos de compra: {ex.Message}");
            }
        }
    }
}
