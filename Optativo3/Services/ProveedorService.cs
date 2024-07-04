using Optativo3.Models;
using Optativo3.Repository.Data.Clientes;
using System;
using System.Collections.Generic;

namespace Optativo3.Services.Logica
{
    public class ProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public bool Add(ProveedorModel proveedor)
        {
            
            if (string.IsNullOrWhiteSpace(proveedor.RazonSocial) || proveedor.RazonSocial.Length < 3)
                throw new ArgumentException("La razón social es obligatoria y debe tener al menos 3 caracteres.");

            if (string.IsNullOrWhiteSpace(proveedor.TipoDocumento) || proveedor.TipoDocumento.Length < 3)
                throw new ArgumentException("El tipo de documento es obligatorio y debe tener al menos 3 caracteres.");

            if (string.IsNullOrWhiteSpace(proveedor.NumeroDocumento) || proveedor.NumeroDocumento.Length < 3)
                throw new ArgumentException("El número de documento es obligatorio y debe tener al menos 3 caracteres.");

            
            if (!EsNumero(proveedor.Celular) || proveedor.Celular.Length != 10)
                throw new ArgumentException("El número de celular debe ser numérico y tener una longitud de 10 caracteres.");

            return _proveedorRepository.Add(proveedor);
        }

        public bool Update(ProveedorModel proveedor)
        {
            
            if (string.IsNullOrWhiteSpace(proveedor.RazonSocial) || proveedor.RazonSocial.Length < 3)
                throw new ArgumentException("La razón social es obligatoria y debe tener al menos 3 caracteres.");

            if (string.IsNullOrWhiteSpace(proveedor.TipoDocumento) || proveedor.TipoDocumento.Length < 3)
                throw new ArgumentException("El tipo de documento es obligatorio y debe tener al menos 3 caracteres.");

            if (string.IsNullOrWhiteSpace(proveedor.NumeroDocumento) || proveedor.NumeroDocumento.Length < 3)
                throw new ArgumentException("El número de documento es obligatorio y debe tener al menos 3 caracteres.");

            
            if (!EsNumero(proveedor.Celular) || proveedor.Celular.Length != 10)
                throw new ArgumentException("El número de celular debe ser numérico y tener una longitud de 10 caracteres.");

            return _proveedorRepository.Update(proveedor);
        }

        public bool Delete(int id)
        {
            return _proveedorRepository.Delete(id);
        }

        public IEnumerable<ProveedorModel> GetAll()
        {
            return _proveedorRepository.GetAll();
        }

        public ProveedorModel GetById(int id)
        {
            return _proveedorRepository.GetById(id);
        }

        
        private bool EsNumero(string str)
        {
            return int.TryParse(str, out _);
        }
    }
}
