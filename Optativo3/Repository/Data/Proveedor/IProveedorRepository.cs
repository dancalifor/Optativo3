using Optativo3.Models;
using System.Collections.Generic;

namespace Optativo3.Repository.Data.Clientes
{
    public interface IProveedorRepository
    {
        bool Add(ProveedorModel proveedor);
        bool Update(ProveedorModel proveedor);
        bool Delete(int id);
        IEnumerable<ProveedorModel> GetAll();
        ProveedorModel GetById(int id);
    }
}
