using System;

namespace DJanel.Muebles.DataAccess.Contracts.DTOs
{
    public class ReporteCompra
    {
        public string Nombre_Empresa { get; set; }
        public string Nombre_Propietario { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Created_at { get; set; }
    }
}
