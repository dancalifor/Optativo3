using Dapper;
using Npgsql;
using Optativo3.Repository.Data.Productos;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Data.Productos
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Add(ProductoModel producto)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "INSERT INTO Productos (Descripcion, CantidadMinima, CantidadStock, PrecioCompra, Categoria, Marca, Estado) VALUES (@Descripcion, @CantidadMinima, @CantidadStock, @PrecioCompra, @Categoria, @Marca, @Estado)";
                var result = connection.Execute(query, producto);
                return result > 0;
            }
        }

        public bool Update(ProductoModel producto)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "UPDATE Productos SET Descripcion = @Descripcion, CantidadMinima = @CantidadMinima, CantidadStock = @CantidadStock, PrecioCompra = @PrecioCompra, Categoria = @Categoria, Marca = @Marca, Estado = @Estado WHERE Id = @Id";
                var result = connection.Execute(query, producto);
                return result > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "DELETE FROM Productos WHERE Id = @Id";
                var result = connection.Execute(query, new { Id = id });
                return result > 0;
            }
        }

        public IEnumerable<ProductoModel> GetAll()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Productos";
                return connection.Query<ProductoModel>(query).ToList();
            }
        }

        public ProductoModel GetById(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Productos WHERE Id = @Id";
                return connection.QueryFirstOrDefault<ProductoModel>(query, new { Id = id });
            }
        }
    }
}
