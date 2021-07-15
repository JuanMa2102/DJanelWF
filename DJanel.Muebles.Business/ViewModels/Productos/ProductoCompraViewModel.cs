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

namespace DJanel.Muebles.Business.ViewModels.Productos
{
    public class ProductoCompraViewModel : Validable, INotifyPropertyChanged
    {
        #region Propiedades privadas
        private IProductoCompraRepository Repository { get; set; }
        #endregion

        #region Propiedades públicas
        public BindingList<ProductoCompra> ListaProductosCompra { get; set; }
        public EntityState State { get; set; }
        #endregion

        #region Constructor
        public ProductoCompraViewModel(IProductoCompraRepository repository)
        {
            Repository = repository;
            ListaProductosCompra = new BindingList<ProductoCompra>();
            Producto = new Producto();
            Proveedor = new Proveedor();
        }
        #endregion

        #region Metodos
        public async Task GetAllAsync()
        {
            try
            {
                var x = await Repository.GetAllAsync();
                ListaProductosCompra.Clear();
                foreach (var item in x)
                {
                    ListaProductosCompra.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoCompra> Guardar(int Id)
        {
            try
            {
                ProductoCompra model = new ProductoCompra
                {
                    IdProductoCompra = IdProductoCompra,
                    DatosProducto = Producto,
                    DatosProveedor = Proveedor,
                    Costo = Costo,
                    Fecha = Fecha,
                    Cantidad = Cantidad,
                    Total = Total
                };
                if (State == EntityState.Create)
                    return await Repository.AddAsync(model, Id);
                else
                if (State == EntityState.Update)
                    return await Repository.UpdateAsync(model, Id);

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Remove(int Id)
        {
            try
            {
                return await Repository.DeleteCompraAsync(IdProductoCompra, Producto.IdProducto , Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Binding(Variables)

        private int _IdProductoCompra;

        public int IdProductoCompra
        {
            get { return _IdProductoCompra; }
            set
            {
                _IdProductoCompra = value;
                OnPropertyChanged(nameof(IdProductoCompra));

            }
        }

        private Producto _Producto;

        public Producto Producto
        {
            get { return _Producto; }
            set
            {
                _Producto = value;
                OnPropertyChanged(nameof(Producto));

            }
        }



        private Proveedor _Proveedor;

        public Proveedor Proveedor
        {
            get { return _Proveedor; }
            set
            {
                _Proveedor = value;
                OnPropertyChanged(nameof(Proveedor));
            }
        }

        private decimal _Costo;

        public decimal Costo
        {
            get { return _Costo; }
            set
            {
                _Costo = value;
                Total = Costo * Cantidad;
                OnPropertyChanged(nameof(Costo));

            }
        }

        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set
            {
                _Fecha = value;
                OnPropertyChanged(nameof(Fecha));

            }
        }

        private int _Cantidad;

        public int Cantidad
        {
            get { return _Cantidad; }
            set
            {
                _Cantidad = value;
                Total = Costo * Cantidad;
                OnPropertyChanged(nameof(Cantidad));

            }
        }

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set
            {
                _Total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        private string _FechaString;

        public string FechaString
        {
            get { return _FechaString; }
            set
            {
                _FechaString = value;
                OnPropertyChanged(nameof(FechaString));
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
