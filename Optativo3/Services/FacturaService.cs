using Repository.Data.Facturas;
using System;
using System.Collections.Generic;

namespace Services.Logica
{
    public class FacturaService
    {
        private readonly IFacturaRepository facturaRepository;

        public FacturaService(string connectionString)
        {
            facturaRepository = new FacturaRepository(connectionString);
        }

        public bool Add(FacturaModel factura)
        {
            return ValidarDatos(factura) ? facturaRepository.add(factura) : throw new Exception("Error en la validación de datos, corroborar");
        }

        public IEnumerable<FacturaModel> GetAll()
        {
            return facturaRepository.GetAll();
        }

        public bool Delete(int id)
        {
            return id > 0 ? facturaRepository.delete(id) : false;
        }

        public bool Update(FacturaModel facturaModel)
        {
            return ValidarDatos(facturaModel) ? facturaRepository.update(facturaModel) : throw new Exception("Error en la validación de datos, corroborar");
        }

        private bool ValidarDatos(FacturaModel factura)
        {
            if (factura == null)
                return false;
            if (factura.Id_cliente <= 0)
                return false;
            if (factura.Total <= 0)
                return false;
            if (factura.Fecha_hora == DateTime.MinValue)
                return false;

            return true;
        }
    }
}
