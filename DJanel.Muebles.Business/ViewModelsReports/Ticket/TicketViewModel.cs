using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.ViewModelsReports.Ticket
{
    public class TicketViewModel : INotifyPropertyChanged
    {
        #region Propiedades Privadas
        private IVentaRepository Repository { get; set; }
        #endregion

        #region Propiedades públicas
        public List<ReporteVenta> ListaReporte { get; private set; }
        public decimal TotalVentas { get; private set; }

        #endregion

        #region Constructor
        public TicketViewModel(IVentaRepository repository)
        {
            Repository = repository;
            ListaReporte = new List<ReporteVenta>();
        }
        #endregion

        #region Metodos

        public async Task GetAllAsync(int IdVenta)
        {
            try
            {
                TotalVentas = 0;
                var x = await Repository.GetVentaAsync(IdVenta);
                ListaReporte.Clear();
                foreach (var item in x)
                {
                    if (item.NombreCompleto == null) item.NombreCompleto = "Venta General";
                    TotalVentas += item.Total;
                    ListaReporte.Add(item);
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
