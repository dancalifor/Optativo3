using Dapper;
using Npgsql;
using Optativo3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Optativo3.Repository.Data.PedidosCompra
{
    public class PedidoCompraRepository : IPedidoCompraRepository
    {
        private readonly string _connectionString;

        public PedidoCompraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Add(Pedido_Compra pedidoCompra)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "INSERT INTO Pedido_Compra (IdProveedor, IdSucursal, Fecha_Hora, Total) VALUES (@IdProveedor, @IdSucursal, @Fecha_Hora, @Total)";
                var result = connection.Execute(query, pedidoCompra);
                return result > 0;
            }
        }

        public bool Update(Pedido_Compra pedidoCompra)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "UPDATE Pedido_Compra SET IdProveedor = @IdProveedor, IdSucursal = @IdSucursal, Fecha_Hora = @Fecha_Hora, Total = @Total WHERE Id = @Id";
                var result = connection.Execute(query, pedidoCompra);
                return result > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "DELETE FROM Pedido_Compra WHERE Id = @Id";
                var result = connection.Execute(query, new { Id = id });
                return result > 0;
            }
        }

        public IEnumerable<Pedido_Compra> GetAll()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Pedido_Compra";
                return connection.Query<Pedido_Compra>(query).ToList();
            }
        }

        public Pedido_Compra GetById(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Pedido_Compra WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Pedido_Compra>(query, new { Id = id });
            }
        }
    }
}
