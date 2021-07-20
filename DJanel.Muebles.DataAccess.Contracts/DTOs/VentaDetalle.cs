using DJanel.Muebles.DataAccess.Contracts.Entities;

namespace DJanel.Muebles.DataAccess.Contracts.DTOs
{
    public class VentaDetalle
    {
        public VentaDetalle()
        {
            Producto = new Producto();
        }
        public int IdVentaDetalle { get; set; }
        public Producto Producto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal  Total { get; set; }
    }
}
