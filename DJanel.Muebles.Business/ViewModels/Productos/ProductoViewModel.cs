using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Contracts.Validations;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.ViewModels.Productos
{
    public class ProductoViewModel : Validable, INotifyPropertyChanged
    {
        #region Propiedades privadas
        private IProductoRepository Repository { get; set; }
        #endregion

        #region Propiedades públicas
        public BindingList<Producto> ListaProductos { get; set; }
        public EntityState State { get; set; }
        #endregion

        #region Constructor
        public ProductoViewModel(IProductoRepository repository)
        {
            Repository = repository;
            ListaProductos = new BindingList<Producto>();
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
                    ListaProductos.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Producto> Guardar(int Id)
        {
            try
            {
                Producto model = new Producto
                {
                    IdProducto = IdProducto,
                    Nombre = Nombre,
                    Descripcion = Descripcion,
                    Stock = Stock,
                    Precio = Precio,
                    Marca = Marca,
                    Modelo = Modelo,
                    ClaveBusqueda = ClaveBusqueda
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
                return await Repository.DeleteAsync(IdProducto, Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Binding(Variables)

        private int _IdProducto;

        public int IdProducto
        {
            get { return _IdProducto; }
            set
            {
                _IdProducto = value;
                OnPropertyChanged(nameof(IdProducto));

            }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                _Nombre = value;
                OnPropertyChanged(nameof(Nombre));

            }
        }



        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set
            {
                _Descripcion = value;
                OnPropertyChanged(nameof(Descripcion));
            }
        }

        private int _Stock;

        public int Stock
        {
            get { return _Stock; }
            set
            {
                _Stock = value;
                OnPropertyChanged(nameof(Stock));

            }
        }

        private decimal _Precio;

        public decimal Precio
        {
            get { return _Precio; }
            set
            {
                _Precio = value;
                OnPropertyChanged(nameof(Precio));

            }
        }

        private string _Marca;

        public string Marca
        {
            get { return _Marca; }
            set
            {
                _Marca = value;
                OnPropertyChanged(nameof(Marca));
            }
        }

        private string _Modelo;

        public string Modelo
        {
            get { return _Modelo; }
            set
            {
                _Modelo = value;
                OnPropertyChanged(nameof(Modelo));
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
