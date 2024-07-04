using Dapper;
using Npgsql;
using Optativo3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Optativo3.Repository.Data.Clientes
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly string _connectionString;

        public ProveedorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Add(ProveedorModel proveedor)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "INSERT INTO Proveedor (RazonSocial, TipoDocumento, NumeroDocumento, Direccion, Email, Celular, Estado) " +
                            "VALUES (@RazonSocial, @TipoDocumento, @NumeroDocumento, @Direccion, @Email, @Celular, @Estado)";
                var result = connection.Execute(query, proveedor);
                return result > 0;
            }
        }

        public bool Update(ProveedorModel proveedor)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "UPDATE Proveedor SET RazonSocial = @RazonSocial, TipoDocumento = @TipoDocumento, " +
                            "NumeroDocumento = @NumeroDocumento, Direccion = @Direccion, Email = @Email, " +
                            "Celular = @Celular, Estado = @Estado WHERE Id = @Id";
                var result = connection.Execute(query, proveedor);
                return result > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "DELETE FROM Proveedor WHERE Id = @Id";
                var result = connection.Execute(query, new { Id = id });
                return result > 0;
            }
        }

        public IEnumerable<ProveedorModel> GetAll()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Proveedor";
                return connection.Query<ProveedorModel>(query).ToList();
            }
        }

        public ProveedorModel GetById(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Proveedor WHERE Id = @Id";
                return connection.QueryFirstOrDefault<ProveedorModel>(query, new { Id = id });
            }
        }
    }
}
