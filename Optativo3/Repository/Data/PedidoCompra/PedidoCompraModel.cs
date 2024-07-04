using System;

namespace Optativo3.Models
{
    public class Pedido_Compra
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public int IdSucursal { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public int Total { get; set; }
    }
}
