using System;
using System.ComponentModel;
using System.Threading.Tasks;
using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.DataAccess.Contracts.Validations;
using DJanel.Muebles.DataAccess.Contracts.Entities.Prueba;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General.Prueba;

namespace DJanel.Muebles.Business.ViewModels.Prueba
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
        public ProductoViewModel(IProductoRepository productoRepository)
        {
            Repository = productoRepository;
            ListaProductos = new BindingList<Producto>();
            GetAllAsync();
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

        public async Task<Producto> GuardarCambios()
        {
            try
            {
                Producto model = new Producto
                {
                    Nombre = Nombre,
                    Precio = Precio
                };
                if (State == EntityState.Create)
                {
                    return await Repository.AddAsync(model, 1);
                }
                
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Binding(Variables)
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged(nameof(Id));
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



        #region InotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        #endregion
    }
}