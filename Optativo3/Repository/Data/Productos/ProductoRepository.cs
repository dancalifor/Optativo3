using Dapper;
using Npgsql;
using Optativo3.Repository.Data.Productos;
using System;
using System.Collections.Generic;
using System.Data;
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
            ValidarProducto(producto);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "INSERT INTO Productos (Descripcion, CantidadMinima, CantidadStock, PrecioCompra, Categoria, Marca, Estado) " +
                            "VALUES (@Descripcion, @CantidadMinima, @CantidadStock, @PrecioCompra, @Categoria, @Marca, @Estado)";
                var result = connection.Execute(query, producto);
                return result > 0;
            }
        }

        public bool Update(ProductoModel producto)
        {
            ValidarProducto(producto);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "UPDATE Productos SET Descripcion = @Descripcion, CantidadMinima = @CantidadMinima, CantidadStock = @CantidadStock, " +
                            "PrecioCompra = @PrecioCompra, Categoria = @Categoria, Marca = @Marca, Estado = @Estado WHERE Id = @Id";
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

        private void ValidarProducto(ProductoModel producto)
        {
            if (string.IsNullOrEmpty(producto.Descripcion))
                throw new ArgumentException("La descripción del producto es obligatoria.");

            if (producto.CantidadMinima <= 0)
                throw new ArgumentException("La cantidad mínima debe ser mayor a cero.");

            if (producto.PrecioCompra <= 0 || !EsEnteroPositivo(producto.PrecioCompra))
                throw new ArgumentException("El precio de compra debe ser un número entero positivo.");

            
            if (string.IsNullOrEmpty(producto.Categoria))
                throw new ArgumentException("La categoría del producto es obligatoria.");

            if (string.IsNullOrEmpty(producto.Marca))
                throw new ArgumentException("La marca del producto es obligatoria.");

            if (string.IsNullOrEmpty(producto.Estado))
                throw new ArgumentException("El estado del producto es obligatorio.");
        }

        private bool EsEnteroPositivo(decimal numero)
        {
            return decimal.Floor(numero) == numero && numero > 0;
        }
    }
}
