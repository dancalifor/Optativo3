using Optativo3.Models;
using System.Collections.Generic;

namespace Optativo3.Repository.Data.PedidosCompra
{
    public interface IPedidoCompraRepository
    {
        bool Add(Pedido_Compra pedidoCompra);
        bool Update(Pedido_Compra pedidoCompra);
        bool Delete(int id);
        IEnumerable<Pedido_Compra> GetAll();
        Pedido_Compra GetById(int id);
    }
}
