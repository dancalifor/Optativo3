using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Data.Facturas
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        private readonly string _connectionString;

        public DetalleFacturaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Add(DetalleFacturaModel detalleFactura)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "INSERT INTO DetalleFactura (IdFactura, IdProducto, CantidadProducto, Subtotal) VALUES (@IdFactura, @IdProducto, @CantidadProducto, @Subtotal)";
                var result = connection.Execute(query, detalleFactura);
                return result > 0;
            }
        }

        public bool Update(DetalleFacturaModel detalleFactura)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "UPDATE DetalleFactura SET IdFactura = @IdFactura, IdProducto = @IdProducto, CantidadProducto = @CantidadProducto, Subtotal = @Subtotal WHERE Id = @Id";
                var result = connection.Execute(query, detalleFactura);
                return result > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "DELETE FROM DetalleFactura WHERE Id = @Id";
                var result = connection.Execute(query, new { Id = id });
                return result > 0;
            }
        }

        public IEnumerable<DetalleFacturaModel> GetAll()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM DetalleFactura";
                return connection.Query<DetalleFacturaModel>(query).ToList();
            }
        }

        public DetalleFacturaModel GetById(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM DetalleFactura WHERE Id = @Id";
                return connection.QueryFirstOrDefault<DetalleFacturaModel>(query, new { Id = id });
            }
        }
    }
}
