using DJanel.Muebles.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.DTOs
{
    public class ProductoCompra
    {
        public ProductoCompra()
        {
            DatosProveedor = new Proveedor();
            DatosProducto = new Producto();
        }

        public int IdProductoCompra { get; set; }
        public Producto DatosProducto { get; set; }
        public Proveedor DatosProveedor { get; set; }
        public Decimal Costo { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public Decimal Total { get; set; }
        public int Resultado { get; set; }
    }
}
