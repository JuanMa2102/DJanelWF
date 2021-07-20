using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.WFApplication.Reports.Ticket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DJanel.Muebles.WFApplication.Forms.Ventas
{
    public partial class FrmVentaResult : Form
    {
        public Venta Venta { get; set; }
        public decimal CambioVenta { get; set; }
        public decimal PagoVenta { get; set; }
        public string FolioVenta { get; set; }
        public FrmVentaResult(Venta venta,string folio, decimal pag, decimal cambio)
        {
            InitializeComponent();
            this.Venta = venta;
            this.CambioVenta = cambio;
            this.PagoVenta = pag;
            this.FolioVenta = folio;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVentaResult_Shown(object sender, EventArgs e)
        {
            try
            {
                Folio.Text = FolioVenta;
                Fecha.Text = DateTime.Now.ToShortDateString();
                Total.Text = "$" + Venta.Total;
                Pago.Text = "$"+ PagoVenta;
                Cambio.Text = "$" + CambioVenta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmTicket(Venta, CambioVenta, PagoVenta);
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
