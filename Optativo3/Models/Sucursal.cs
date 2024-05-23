using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optativo3.Modelos
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Whatsapp { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        public Sucursal() { }

        public Sucursal(string descripcion, string direccion, string telefono, string whatsapp, string mail, string estado)
        {
            Descripcion = descripcion;
            Direccion = direccion;
            Telefono = telefono;
            Whatsapp = whatsapp;
            Mail = mail;
            Estado = estado;
        }
    }
}