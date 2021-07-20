using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.ViewModelsReports.Compra
{
    public class CompraReporteViewModel : INotifyPropertyChanged
    {
        #region Propiedades Privadas
        private IProductoCompraRepository Repository { get; set; }
        #endregion

        #region Propiedades públicas
        public List<ReporteCompra> ListaReporte { get; private set; }
        public List<ReporteVentaByPeriodo> ListaVentasByPeriodo { get; private set; }
        public decimal TotalVentas { get; private set; }

        #endregion

        #region Constructor
        public CompraReporteViewModel(IProductoCompraRepository repository)
        {
            Repository = repository;
            ListaReporte = new List<ReporteCompra>();
            ListaVentasByPeriodo = new List<ReporteVentaByPeriodo>();
        }
        #endregion

        #region Metodos

        public async Task GetAllAsync()
        {
            try
            {
                TotalVentas = 0;
                var x = await Repository.GetReporteComprasAsync(startDate, endDate);
                ListaReporte.Clear();
                foreach (var item in x)
                {
                    TotalVentas += item.Total;
                    ListaReporte.Add(item);
                }

                var listVentasByDate = (from venta in x
                                        group venta by venta.Created_at
                                       into listVentas
                                        select new
                                        {
                                            fecha = listVentas.Key,
                                            total = listVentas.Sum(item => item.Total)
                                        }).AsEnumerable();

                int totalDays = Convert.ToInt32((startDate - endDate).Days);

                if (totalDays == 0)
                {
                    ListaVentasByPeriodo = (from venta in listVentasByDate
                                            group venta by venta.fecha.ToString("hh tt")
                                        into listVentas
                                            select new ReporteVentaByPeriodo
                                            {
                                                Periodo = listVentas.Key,
                                                Total = listVentas.Sum(item => item.total)
                                            }).ToList();
                }

                ////group period by days
                else if (totalDays <= 7)
                {
                    ListaVentasByPeriodo = (from venta in listVentasByDate
                                            group venta by venta.fecha.ToString("dd-MMM-yyyy")
                                        into listVentas
                                            select new ReporteVentaByPeriodo
                                            {
                                                Periodo = listVentas.Key,
                                                Total = listVentas.Sum(item => item.total)
                                            }).ToList();
                }
                ////group period by weeks
                else if (totalDays <= 30)
                {
                    ListaVentasByPeriodo = (from venta in listVentasByDate
                                            group venta by
                                                System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                    venta.fecha, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                        into listVentas
                                            select new ReporteVentaByPeriodo
                                            {
                                                Periodo = "Semana " + listVentas.Key.ToString(),
                                                Total = listVentas.Sum(item => item.total)
                                            }).ToList();
                }
                ////group period by months
                else if (totalDays <= 365)
                {
                    ListaVentasByPeriodo = (from venta in listVentasByDate
                                            group venta by venta.fecha.ToString("MMM-yyyy")
                                        into listVentas
                                            select new ReporteVentaByPeriodo
                                            {
                                                Periodo = listVentas.Key,
                                                Total = listVentas.Sum(item => item.total)
                                            }).ToList();
                }
                ////group period by years
                else
                {
                    ListaVentasByPeriodo = (from venta in listVentasByDate
                                            group venta by venta.fecha.ToString("yyyy")
                                        into listVentas
                                            select new ReporteVentaByPeriodo
                                            {
                                                Periodo = listVentas.Key,
                                                Total = listVentas.Sum(item => item.total)
                                            }).ToList();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Binding(Variables)
        private DateTime _startDate;

        public DateTime startDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(startDate));

            }
        }

        private DateTime _endDate;

        public DateTime endDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(endDate));

            }
        }
        #endregion

        #region InotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
