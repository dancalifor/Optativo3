using System.Collections.Generic;

namespace Repository.Data.Facturas
{
    public interface IDetalleFacturaRepository
    {
        bool Add(DetalleFacturaModel detalleFactura);
        bool Update(DetalleFacturaModel detalleFactura);
        bool Delete(int id);
        IEnumerable<DetalleFacturaModel> GetAll();
        DetalleFacturaModel GetById(int id);
    }
}
