using System;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DJanel.Muebles.WFApplication.Session;
using DJanel.Muebles.Business.ViewModelsReports.Ventas;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.Business.ViewModelsReports.Ticket;
using DJanel.Muebles.DataAccess.Contracts.DTOs;

namespace DJanel.Muebles.WFApplication.Reports.Ticket
{
    public partial class FrmTicket : Form
    {
        public TicketViewModel Model { get; set; }
        public FrmTicket(Venta Venta, decimal Cambio, decimal Pago)
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<TicketViewModel>();
            MostrarReporte(Venta, Cambio, Pago);
        }

        private void FrmTicket_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        private async void MostrarReporte(Venta venta, decimal cambio, decimal pago)
        {
            await Model.GetAllAsync(venta.IdVenta);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 75;
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.BackColor = Color.White;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DJanel.Muebles.WFApplication.Reports.Ticket.Ticket.rdlc";
            ReportParameter[] parameters = new ReportParameter[5];
            parameters[0] = new ReportParameter("NombreCompleto", CurrentSession.NombreCompleto);
            parameters[1] = new ReportParameter("FechaReporte", DateTime.Now.ToString());
            parameters[2] = new ReportParameter("TotalVentas", "$" + Model.TotalVentas.ToString());
            parameters[3] = new ReportParameter("Efectivo", "$" + pago.ToString());
            parameters[4] = new ReportParameter("Cambio", "$" + cambio.ToString());
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ReporteVenta", Model.ListaReporte));
            this.reportViewer1.RefreshReport();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
