using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.DTOs
{
    public class ReporteVenta
    {
        public int IdVentaDetalle { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public string Folio { get; set; }
        public string NombreCompleto { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}
