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
using System.Data;

namespace DJanel.Muebles.Business.ViewModels.Ventas
{
    public class VentaViewModel : Validable, INotifyPropertyChanged
    {
        #region Propiedades Privadas
        private IVentaRepository Repository { get; set; }
        private IProductoRepository ProductoRepository { get; set; }
        #endregion

        #region Propiedades públicas
        public BindingList<VentaDetalle> Lista { get; set; }
        public Cliente Cliente { get; set; }
        public EntityState State { get; set; }
        #endregion

        #region Constructor
        public VentaViewModel(IVentaRepository repository, IProductoRepository productoRepository)
        {
            Repository = repository;
            ProductoRepository = productoRepository;
            Lista = new BindingList<VentaDetalle>();
            Cliente = new Cliente();
        }
        #endregion

        #region Metodos
        public async Task<Venta> Guardar(int Id)
        {
            try
            {
                Venta model = new Venta
                {
                    ListaVentaDetalle = Lista,
                    Usuario = { IdUsuario = Id},
                    Cliente = Cliente,
                    Total = Total
                };
                if (State == EntityState.Create)
                    return await Repository.AddAsync(model, Id);

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task GetFolio()
        {
            try
            {
                Folio = await Repository.GetFolioAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetClienteDefault()
        {
            try
            {
                Cliente.IdCliente = 0;
                Cliente.NombreCompleto = "Venta General";
                NombreCliente = Cliente.NombreCompleto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Producto> GetProductoAsync()
        {
            try
            {
                var x = await Repository.GetProductoAsync(ClaveBusqueda);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddProductoAsync(Producto producto)
        {
            try
            {
                var stockActual = await ProductoRepository.GetStockAsync(producto.IdProducto);
                var x = Lista.Where(p => p.Producto.IdProducto == producto.IdProducto).Select(u => u).ToList();

                if(x.Count < 1)
                {
                    //Es articulo nuevo
                    if (stockActual >= Cantidad)
                    { 
                        AddNew(producto);
                        GetTotales();
                        return true;
                    }

                }
                else
                {
                    var cantidadIngresado = Lista.Where(p => p.Producto.IdProducto == producto.IdProducto).FirstOrDefault();
                    if (stockActual >= (cantidadIngresado.Cantidad + Cantidad))
                    {
                        AddExist(producto);
                        GetTotales();
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetTotales()
        {
            try
            {
                Total = Lista.Sum(p => p.Total);
                Articulo = Lista.Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddNew(Producto producto)
        {
            try
            {
                VentaDetalle prod = new VentaDetalle();
                prod.Producto = producto;
                prod.Precio = producto.Precio;
                prod.Cantidad = Cantidad;
                prod.Total = Cantidad * producto.Precio;
                Lista.Add(prod);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddExist(Producto producto)
        {
            try
            {
                Lista.Where(p => p.Producto.IdProducto == producto.IdProducto).Select(u =>
                {
                    u.Cantidad = u.Cantidad + Cantidad;
                    u.Total = u.Cantidad * u.Precio;
                    return u;
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SubExist(Producto producto)
        {
            try
            {
                Lista.Where(p => p.Producto.IdProducto == producto.IdProducto).Select(u =>
                {
                    if (u.Cantidad == 1)
                    {
                        return u;
                    }
                    else
                        u.Cantidad = u.Cantidad - 1;
                    u.Total = u.Cantidad * u.Precio;
                    return u;
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveProducto(VentaDetalle VentaProducto)
        {
            try
            {
                Lista.Remove(VentaProducto);
                GetTotales();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> AddCantidadProducto(VentaDetalle VentaProducto)
        {
            try
            {
                var result = await AddProductoAsync(VentaProducto.Producto);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SubCantidadProducto(VentaDetalle VentaProducto)
        {
            try
            {
                SubExist(VentaProducto.Producto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void LimpiarPropiedades()
        {
            Cliente = new Cliente();
            Lista.Clear();
            Total = 0;
            Articulo = 0;
            NombreCliente = "";
            ClaveBusqueda = "";
            Fecha = DateTime.Now;
            Cantidad = 1;
            Pago = 0;
            await GetFolio();
            GetClienteDefault();
        }
        #endregion

        #region Binding(Variables)


        private string _Folio;

        public string Folio
        {
            get { return _Folio; }
            set
            {
                _Folio = value;
                OnPropertyChanged(nameof(Folio));

            }
        }

        private string _ClaveBusqueda;

        public string ClaveBusqueda
        {
            get { return _ClaveBusqueda; }
            set
            {
                _ClaveBusqueda = value;
                OnPropertyChanged(nameof(ClaveBusqueda));

            }
        }

        private string _NombreCliente;

        public string NombreCliente
        {
            get { return _NombreCliente; }
            set
            {
                _NombreCliente = value;
                OnPropertyChanged(nameof(NombreCliente));

            }
        }

        private int _Cantidad;

        public int Cantidad
        {
            get { return _Cantidad; }
            set
            {
                _Cantidad = value;
                OnPropertyChanged(nameof(Cantidad));

            }
        }

        private int _Articulo;

        public int Articulo
        {
            get { return _Articulo; }
            set
            {
                _Articulo = value;
                OnPropertyChanged(nameof(Articulo));

            }
        }

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set
            {
                _Total = value;
                Cambio = Pago - Total;
                OnPropertyChanged(nameof(Total));

            }
        }

        private decimal _Pago;

        public decimal Pago
        {
            get { return _Pago; }
            set
            {
                _Pago = value;
                Cambio = Pago - Total;
                OnPropertyChanged(nameof(Pago));

            }
        }

        private decimal _Cambio;

        public decimal Cambio
        {
            get { return _Cambio; }
            set
            {
                _Cambio = value;
                if (Cambio < 0)
                    Cambio = 0;
                OnPropertyChanged(nameof(Cambio));

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
