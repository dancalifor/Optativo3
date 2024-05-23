using Optativo3.Repository.Data.Clientes;
using Repository.Data.Clientes;
using System;
using System.Collections.Generic;

namespace Services.Logica
{
    public class ClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(string connectionString)
        {
            clienteRepository = new ClienteRepository(connectionString);
        }

        public bool Add(ClienteModel cliente)
        {
            return ValidarDatos(cliente) ? clienteRepository.add(cliente) : throw new Exception("Error en la validación de datos, corroborar");
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            return clienteRepository.GetAll();
        }

        public bool Delete(int id)
        {
            return id > 0 ? clienteRepository.delete(id) : false;
        }

        public bool Update(ClienteModel clienteModel)
        {
            return ValidarDatos(clienteModel) ? clienteRepository.update(clienteModel) : throw new Exception("Error en la validación de datos, corroborar");
        }

        private bool ValidarDatos(ClienteModel cliente)
        {
            if (cliente == null)
                return false;
            if (string.IsNullOrEmpty(cliente.Nombre))
                return false;
            if (string.IsNullOrEmpty(cliente.Apellido) && cliente.Nombre.Length < 2)
                return false;
            if (string.IsNullOrEmpty(cliente.Documento))
                return false;

            return true;
        }
    }
}
