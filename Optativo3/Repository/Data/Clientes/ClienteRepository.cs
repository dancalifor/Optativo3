using Dapper;
using Npgsql;
using Optativo3.Repository.Data.Clientes;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Data.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Add(ClienteModel cliente)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "INSERT INTO Clientes (Nombre, Apellido, Documento, Email, Direccion, Celular, Estado) VALUES (@Nombre, @Apellido, @Documento, @Email, @Direccion, @Celular, @Estado)";
                var result = connection.Execute(query, cliente);
                return result > 0;
            }
        }

        public bool Update(ClienteModel cliente)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Documento = @Documento, Email = @Email, Direccion = @Direccion, Celular = @Celular, Estado = @Estado WHERE Id = @Id";
                var result = connection.Execute(query, cliente);
                return result > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "DELETE FROM Clientes WHERE Id = @Id";
                var result = connection.Execute(query, new { Id = id });
                return result > 0;
            }
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Clientes";
                return connection.Query<ClienteModel>(query).ToList();
            }
        }

        public ClienteModel GetById(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Clientes WHERE Id = @Id";
                return connection.QueryFirstOrDefault<ClienteModel>(query, new { Id = id });
            }
        }
    }
}
