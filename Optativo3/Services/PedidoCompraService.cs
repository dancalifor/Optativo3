using Optativo3.Models;
using Optativo3.Repository.Data.PedidosCompra;
using System;
using System.Collections.Generic;

namespace Optativo3.Services.Logica
{
    public class PedidoCompraService
    {
        private readonly IPedidoCompraRepository _pedidoCompraRepository;

        public PedidoCompraService(IPedidoCompraRepository pedidoCompraRepository)
        {
            _pedidoCompraRepository = pedidoCompraRepository;
        }

        public bool Add(Pedido_Compra pedidoCompra)
        {
            // Aquí podrías agregar validaciones específicas para pedidos de compra
            return _pedidoCompraRepository.Add(pedidoCompra);
        }

        public bool Update(Pedido_Compra pedidoCompra)
        {
            return _pedidoCompraRepository.Update(pedidoCompra);
        }

        public bool Delete(int id)
        {
            return _pedidoCompraRepository.Delete(id);
        }

        public IEnumerable<Pedido_Compra> GetAll()
        {
            return _pedidoCompraRepository.GetAll();
        }

        public Pedido_Compra GetById(int id)
        {
            return _pedidoCompraRepository.GetById(id);
        }
    }
}
