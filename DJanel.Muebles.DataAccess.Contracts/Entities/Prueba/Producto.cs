using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.Entities.Prueba
{
    public class Producto
    {
        public Producto()
        {
            Nombre = string.Empty;

        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
