using Optativo3.Repository.Data.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Productos
{
    public interface IProductoRepository
    {
        bool Add(ProductoModel productoModel);
        bool Update(ProductoModel productoModel);
        bool Delete(int id);
        IEnumerable<ProductoModel> GetAll();
        ProductoModel GetById(int id);
    }
}
