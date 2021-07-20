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
using DJanel.Muebles.Business.ViewModelsReports.Compra;
using DJanel.Muebles.Business.ViewModelsReports.Productos;

namespace DJanel.Muebles.WFApplication.Reports.Productos
{
    public partial class FrmProductosReporte : Form
    {
        public ProductoReporteViewModel Model { get; set; }
        public FrmProductosReporte()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<ProductoReporteViewModel>();
        }

        private void FrmVentasReporte_Load(object sender, EventArgs e)
        {
            IniciarBinding();
        }

        private void IniciarBinding()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private async void MostrarReporte()
        {
            await Model.GetAllAsync();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DJanel.Muebles.WFApplication.Reports.Productos.ProductosReporte.rdlc";
            ReportParameter[] parameters = new ReportParameter[5];
            parameters[0] = new ReportParameter("NombreCompleto", CurrentSession.NombreCompleto);
            parameters[1] = new ReportParameter("NombreRol", CurrentSession.NombreRol);
            parameters[2] = new ReportParameter("FechaReporte", DateTime.Now.ToString());
            parameters[3] = new ReportParameter("TotalProductos", Model.TotalProductos.ToString());
            parameters[4] = new ReportParameter("Total", "$"+Model.Total.ToString());
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Producto", Model.ListaReporte));
            this.reportViewer1.RefreshReport();
        }

        private void Today_MouseEnter(object sender, EventArgs e)
        {
            this.Today.ForeColor = Color.White;
        }

        private void Today_MouseLeave(object sender, EventArgs e)
        {
            this.Today.ForeColor = Color.Black;
        }

        private void Today_Click(object sender, EventArgs e)
        {
            MostrarReporte();
        }

    }
}
