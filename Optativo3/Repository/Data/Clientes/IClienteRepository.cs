﻿using Optativo3.Repository.Data.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Clientes
{
    public interface IClienteRepository
    {
        bool add(ClienteModel clienteModel);
        bool update(ClienteModel clienteModel);
        bool delete(int id);
        IEnumerable<ClienteModel> GetAll();
    }
}
