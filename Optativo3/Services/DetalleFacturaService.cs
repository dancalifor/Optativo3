using Repository.Data.Facturas;
using System;
using System.Collections.Generic;

namespace Services.Logica
{
    public class DetalleFacturaService
    {
        private readonly IDetalleFacturaRepository _detalleFacturaRepository;

        public DetalleFacturaService(IDetalleFacturaRepository detalleFacturaRepository)
        {
            _detalleFacturaRepository = detalleFacturaRepository;
        }

        public bool Add(DetalleFacturaModel detalleFactura)
        {
            ValidateDetalleFactura(detalleFactura);
            return _detalleFacturaRepository.Add(detalleFactura);
        }

        public bool Update(DetalleFacturaModel detalleFactura)
        {
            ValidateDetalleFactura(detalleFactura);
            return _detalleFacturaRepository.Update(detalleFactura);
        }

        public bool Delete(int id)
        {
            return _detalleFacturaRepository.Delete(id);
        }

        public IEnumerable<DetalleFacturaModel> GetAll()
        {
            return _detalleFacturaRepository.GetAll();
        }

        public DetalleFacturaModel GetById(int id)
        {
            return _detalleFacturaRepository.GetById(id);
        }

        private void ValidateDetalleFactura(DetalleFacturaModel detalleFactura)
        {
            if (detalleFactura.IdFactura <= 0)
                throw new ArgumentException("El IdFactura es obligatorio y debe ser mayor a cero.");

            if (detalleFactura.IdProducto <= 0)
                throw new ArgumentException("El IdProducto es obligatorio y debe ser mayor a cero.");

            if (detalleFactura.CantidadProducto <= 0)
                throw new ArgumentException("La CantidadProducto es obligatoria y debe ser mayor a cero.");

            if (detalleFactura.Subtotal < 0)
                throw new ArgumentException("El Subtotal debe ser mayor o igual a cero.");
        }
    }
}
