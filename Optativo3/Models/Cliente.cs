using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optativo3.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public int Id_banco { get; set; }
        public required string Nombre {  get; set; }
        public required string Apellido {  get; set; }
        public required string Documento { get; set; }
        public required string Direccion {  get; set; }
        public required string Email { get; set; }
        public required string Celular { get; set; }
        public required string Estado { get; set; }


    }
}
