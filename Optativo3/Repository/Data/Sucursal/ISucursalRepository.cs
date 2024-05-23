using Optativo3.Modelos;
using System;
using System.Collections.Generic;

namespace Repository.Data.Sucursales
{
    public interface ISucursalRepository
    {
        void InsertarSucursal(SucursalModel sucursal);
        void ActualizarSucursal(SucursalModel sucursal);
        void EliminarSucursal(int id);
        SucursalModel ObtenerSucursalPorId(int id);
        IEnumerable<SucursalModel> ObtenerTodasLasSucursales();
    }
}
