using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Contracts.Validations;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.ViewModels.Productos
{
    public class ProductoGridViewModel : Validable, INotifyPropertyChanged
    {
        #region Propiedades privadas
        private IProductoRepository Repository { get; set; }
        #endregion

        #region Propiedades públicas
        public BindingList<Producto> ListaProductos { get; set; }
        public BindingList<Producto> ListaSeleccionados { get; set; }
        public Producto Producto { get; set; }
        #endregion

        #region Constructor
        public ProductoGridViewModel(IProductoRepository repository)
        {
            Repository = repository;
            ListaProductos = new BindingList<Producto>();
            ListaSeleccionados = new BindingList<Producto>();
            Producto = new Producto();
        }
        #endregion

        #region Metodos
        public async Task GetAllAsync()
        {
            try
            {
                var x = await Repository.GetAllAsync();
                ListaProductos.Clear();
                foreach (var item in x)
                {
                    item.Seleccionar = true;
                    ListaProductos.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task BusquedaProducto()
        {
            try
            {
                var x = await Repository.Busqueda(Busqueda);
                ListaProductos.Clear();
                foreach (var item in x)
                {
                    ListaProductos.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Binding(Variables)
        private string _Busqueda;

        public string Busqueda
        {
            get { return _Busqueda; }
            set
            {
                _Busqueda = value;
                OnPropertyChanged(nameof(Busqueda));

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
