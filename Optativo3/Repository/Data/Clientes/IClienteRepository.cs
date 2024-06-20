using Optativo3.Repository.Data.Clientes;
using System.Collections.Generic;

namespace Repository.Data.Clientes
{
    public interface IClienteRepository
    {
        bool Add(ClienteModel cliente);
        bool Update(ClienteModel cliente);
        bool Delete(int id);
        IEnumerable<ClienteModel> GetAll();
        ClienteModel GetById(int id);  // Añadir el método GetById
    }
}
