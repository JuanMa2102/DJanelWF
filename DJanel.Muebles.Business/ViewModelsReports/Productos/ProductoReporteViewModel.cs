using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.ViewModelsReports.Productos
{
    public class ProductoReporteViewModel
    {
        #region Propiedades Privadas
        private IProductoRepository Repository { get; set; }
        #endregion

        #region Propiedades públicas
        public List<Producto> ListaReporte { get; private set; }
        public decimal Total { get; private set; }
        public int TotalProductos { get; private set; }

        #endregion

        #region Constructor
        public ProductoReporteViewModel(IProductoRepository repository)
        {
            Repository = repository;
            ListaReporte = new List<Producto>();
        }
        #endregion

        #region Metodos

        public async Task GetAllAsync()
        {
            try
            {
                TotalProductos = 0;
                Total = 0;
                var x = await Repository.GetProductoReporte();
                ListaReporte.Clear();
                foreach (var item in x)
                {
                    TotalProductos += item.Stock;
                    Total = Total + (item.Stock * item.Precio);
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
