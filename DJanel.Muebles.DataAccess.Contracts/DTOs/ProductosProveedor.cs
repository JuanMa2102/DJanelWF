using DJanel.Muebles.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.DTOs
{
    public class ProductosProveedor
    {
        public ProductosProveedor()
        {
            DatosProveedor = new Proveedor();
            ListaProducto = new List<Producto>();
        }

        public List<Producto> ListaProducto { get; set; }
        public Proveedor DatosProveedor { get; set; }
    }
}
