using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Contracts.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.ViewModels.Proveedores
{
    public class ProveedorGridViewModel : Validable, INotifyPropertyChanged
    {
        #region Propiedades privadas
        private IProveedorRepository Repository { get; set; }
        #endregion

        #region Propiedades públicas
        public BindingList<Proveedor> ListaProveedores { get; set; }
        public Proveedor Proveedor { get; set; }
        public Producto Producto { get; set; }
        #endregion

        #region Constructor
        public ProveedorGridViewModel(IProveedorRepository repository)
        {
            Repository = repository;
            ListaProveedores = new BindingList<Proveedor>();
            Proveedor = new Proveedor();
            Producto = new Producto();
        }
        #endregion

        #region Metodos
        public async Task GetAllAsync()
        {
            try
            {
                var x = await Repository.GetProveedorAsync(Producto.IdProducto);
                ListaProveedores.Clear();
                foreach (var item in x)
                {
                    ListaProveedores.Add(item);
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
                var x = await Repository.Busqueda(Busqueda, Producto.IdProducto);
                ListaProveedores.Clear();
                foreach (var item in x)
                {
                    ListaProveedores.Add(item);
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