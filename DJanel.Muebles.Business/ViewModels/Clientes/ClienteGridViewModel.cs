using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Contracts.Validations;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.ViewModels.Clientes
{
    public class ClienteGridViewModel : Validable, INotifyPropertyChanged
    {
        #region Propiedades privadas
        private IClienteRepository Repository { get; set; }
        #endregion

        #region Propiedades públicas
        public BindingList<Cliente> ListaClientes { get; set; }
        public Cliente Cliente { get; set; }
        #endregion

        #region Constructor
        public ClienteGridViewModel(IClienteRepository repository)
        {
            Repository = repository;
            ListaClientes = new BindingList<Cliente>();
            Cliente = new Cliente();
        }
        #endregion

        #region Metodos
        public async Task GetAllAsync()
        {
            try
            {
                var x = await Repository.GetAllAsync();
                ListaClientes.Clear();
                foreach (var item in x)
                {
                    ListaClientes.Add(item);
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
                ListaClientes.Clear();
                foreach (var item in x)
                {
                    ListaClientes.Add(item);
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