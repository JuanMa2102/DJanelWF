using DJanel.Muebles.DataAccess.Contracts.Entities;
using System;
using System.ComponentModel;

namespace DJanel.Muebles.DataAccess.Contracts.DTOs
{
    public class Venta
    {
        public Venta()
        {
            Usuario = new Usuario();
            Cliente = new Cliente();
            ListaVentaDetalle = new BindingList<VentaDetalle>();
        }
        public int IdVenta { get; set; }
        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public BindingList<VentaDetalle> ListaVentaDetalle { get; set; }
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int Resultado { get; set; }
    }
}
