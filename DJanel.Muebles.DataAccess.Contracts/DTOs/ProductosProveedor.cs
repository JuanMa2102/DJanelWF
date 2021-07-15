using DJanel.Muebles.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ListaProducto = new BindingList<Producto>();
        }

        public BindingList<Producto> ListaProducto { get; set; }
        public Proveedor DatosProveedor { get; set; }
        public int Resultado { get; set; }
    }
}
