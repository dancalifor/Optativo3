using Optativo3.Repository.Data.Clientes;
using Repository.Data.Clientes;
using System.Collections.Generic;

namespace Services.Logica
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool Add(ClienteModel cliente)
        {
            // Aquí podrías agregar validaciones específicas para clientes
            return _clienteRepository.Add(cliente);
        }

        public bool Update(ClienteModel cliente)
        {
            return _clienteRepository.Update(cliente);
        }

        public bool Delete(int id)
        {
            return _clienteRepository.Delete(id);
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public ClienteModel GetById(int id)
        {
            return _clienteRepository.GetById(id);
        }
    }
}
