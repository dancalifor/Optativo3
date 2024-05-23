using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Facturas
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public int Id_cliente { get; set; }
        public required string Nro_factura { get; set; }
        public DateTime Fecha_hora { get; set; }
        public Decimal Total { get; set; }
        public Decimal Total_iva5 { get; set; }
        public Decimal Total_iva10 { get; set; }
        public Decimal Total_iva { get; set; }
        public required string Total_letras { get; set; }
        public required string Sucursal { get; set; }
    }
}

