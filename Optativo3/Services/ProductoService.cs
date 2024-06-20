using Optativo3.Repository.Data.Productos;
using Repository.Data.Productos;
using System;
using System.Collections.Generic;

namespace Services.Logica
{
    public class ProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public bool Add(ProductoModel producto)
        {
            if (!ValidateProducto(producto))
            {
                throw new ArgumentException("El producto no cumple con las validaciones.");
            }
            return _productoRepository.Add(producto);
        }

        public bool Update(ProductoModel producto)
        {
            if (!ValidateProducto(producto))
            {
                throw new ArgumentException("El producto no cumple con las validaciones.");
            }
            return _productoRepository.Update(producto);
        }

        public bool Delete(int id)
        {
            return _productoRepository.Delete(id);
        }

        public IEnumerable<ProductoModel> GetAll()
        {
            return _productoRepository.GetAll();
        }

        public ProductoModel GetById(int id)
        {
            return _productoRepository.GetById(id);
        }

        private bool ValidateProducto(ProductoModel producto)
        {
            if (producto == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(producto.Descripcion) ||
                string.IsNullOrWhiteSpace(producto.Categoria) ||
                string.IsNullOrWhiteSpace(producto.Marca) ||
                string.IsNullOrWhiteSpace(producto.Estado))
            {
                return false;
            }

            if (producto.CantidadMinima < 1)
            {
                return false;
            }

            if (producto.PrecioCompra <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
