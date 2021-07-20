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

namespace DJanel.Muebles.WFApplication.Reports.Compras
{
    public partial class FrmCompraReporte : Form
    {//public Color colorBoton { get; set; }
        public Color colorBotonHover { get; set; }
        public CompraReporteViewModel Model { get; set; }
        public FrmCompraReporte()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<CompraReporteViewModel>();

            colorBotonHover = Color.FromArgb(46, 204, 113);
        }

        private void FrmVentasReporte_Load(object sender, EventArgs e)
        {
            IniciarBinding();
        }

        private void IniciarBinding()
        {
            try
            {
                startDateControl.DataBindings.Add("Text", Model, "startDate", true, DataSourceUpdateMode.OnPropertyChanged);
                endDateControl.DataBindings.Add("Text", Model, "endDate", true, DataSourceUpdateMode.OnPropertyChanged);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private async void MostrarReporte()
        {
            //SalesReport reportModel = new SalesReport();
            await Model.GetAllAsync();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DJanel.Muebles.WFApplication.Reports.Compras.ComprasReporte.rdlc";
            ReportParameter[] parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("NombreCompleto", CurrentSession.NombreCompleto);
            parameters[1] = new ReportParameter("NombreRol", CurrentSession.NombreRol);
            parameters[2] = new ReportParameter("FechaReporte", DateTime.Now.ToString());
            parameters[3] = new ReportParameter("FechaFin", Model.endDate.ToShortDateString());
            parameters[4] = new ReportParameter("FechaInicio", Model.startDate.ToShortDateString());
            parameters[5] = new ReportParameter("TotalVentas", Model.TotalVentas.ToString());
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ReporteCompra", Model.ListaReporte));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ReporteVentaByPeriodo", Model.ListaVentasByPeriodo));
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarReporte();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.LastWeek.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.LastWeek.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Model.startDate = DateTime.Today.AddDays(-7);
            Model.endDate = DateTime.Now;
            MostrarReporte();
        }

        private void Today_MouseEnter(object sender, EventArgs e)
        {
            this.Today.ForeColor = Color.White;
        }

        private void Today_MouseLeave(object sender, EventArgs e)
        {
            this.Today.ForeColor = Color.Black;
        }

        private void ThisMonth_MouseEnter(object sender, EventArgs e)
        {
            this.ThisMonth.ForeColor = Color.White;
        }

        private void ThisMonth_MouseLeave(object sender, EventArgs e)
        {
            this.ThisMonth.ForeColor = Color.Black;
        }

        private void LastMonth_MouseEnter(object sender, EventArgs e)
        {
            this.LastMonth.ForeColor = Color.White;
        }

        private void LastMonth_MouseLeave(object sender, EventArgs e)
        {
            this.LastMonth.ForeColor = Color.Black;
        }

        private void ThisYear_MouseEnter(object sender, EventArgs e)
        {
            this.ThisYear.ForeColor = Color.White;
        }

        private void ThisYear_MouseLeave(object sender, EventArgs e)
        {
            this.ThisYear.ForeColor = Color.Black;
        }

        private void Custom_MouseEnter(object sender, EventArgs e)
        {
            this.Custom.ForeColor = Color.White;
        }

        private void Custom_MouseLeave(object sender, EventArgs e)
        {
            this.Custom.ForeColor = Color.Black;
        }

        private void Today_Click(object sender, EventArgs e)
        {
            Model.startDate = DateTime.Today;
            Model.endDate = DateTime.Now;
            MostrarReporte();
        }

        private void ThisMonth_Click(object sender, EventArgs e)
        {
            Model.startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Model.endDate = DateTime.Now;
            MostrarReporte();
        }

        private void LastMonth_Click(object sender, EventArgs e)
        {
            Model.startDate = DateTime.Today.AddDays(-30);
            Model.endDate = DateTime.Now;
            MostrarReporte();
        }

        private void ThisYear_Click(object sender, EventArgs e)
        {
            Model.startDate = new DateTime(DateTime.Now.Year, 1, 1);
            Model.endDate = DateTime.Now;
            MostrarReporte();
        }

        private void Generar_Click(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(23, 59, 0);
            Model.endDate = Model.endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            MostrarReporte();
            PanelPersonalizado.Visible = false;
        }

        private void Custom_Click(object sender, EventArgs e)
        {
            Model.startDate = DateTime.Today;
            Model.endDate = DateTime.Now;
            if (PanelPersonalizado.Visible)
                PanelPersonalizado.Visible = false;
            else
                PanelPersonalizado.Visible = true;
        }

        private void Generar_MouseEnter(object sender, EventArgs e)
        {
            this.Generar.ForeColor = Color.White;
        }

        private void Generar_MouseLeave(object sender, EventArgs e)
        {
            this.Generar.ForeColor = Color.Black;
        }
    }
}
