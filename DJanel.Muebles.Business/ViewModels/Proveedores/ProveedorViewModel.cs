using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Contracts.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.ViewModels.Proveedores
{
    public class ProveedorViewModel : Validable, INotifyPropertyChanged
    {
        #region Propiedades privadas
        private IProveedorRepository proveedorRepository { get; set; }
        private IProductosProveedorRepository productosProveedorRepository { get; set; }
        #endregion

        #region Propiedades públicas
        public BindingList<Proveedor> ListaProveedores { get; set; }
        public BindingList<Producto> ListaProductos { get; set; }
        public EntityState State { get; set; }
        #endregion

        #region Constructor
        public ProveedorViewModel(IProveedorRepository ProveedorRepository, IProductosProveedorRepository ProductosProveedorRepository)
        {
            proveedorRepository = ProveedorRepository;
            productosProveedorRepository = ProductosProveedorRepository;
            ListaProveedores = new BindingList<Proveedor>();
            ListaProductos = new BindingList<Producto>();
        }
        #endregion

        #region Metodos
        public async Task GetAllAsync()
        {
            try
            {
                var x = await proveedorRepository.GetAllAsync();
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

        public async Task LlenarListaProductosAsync()
        {
            try
            {
                var x = await productosProveedorRepository.GetProductosAsync(IdProveedor);
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

        public void GetListaProductos(BindingList<Producto> x)
        {
            try
            {
                List<Producto> dic = new List<Producto>();
                foreach (var item in x)
                {
                    var c = ListaProductos.Where( Producto => Producto.IdProducto == item.IdProducto).Count();
                    if(c == 0)
                        ListaProductos.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveListaProductos(Producto x)
        {
            try
            {
                ListaProductos.Remove(x);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ProductosProveedor> Guardar(int Id)
        {
            try
            {
                ProductosProveedor model = new ProductosProveedor
                {
                    DatosProveedor = {
                        IdProveedor = IdProveedor,
                        Nombre_Empresa = Nombre_Empresa,
                        Nombre_Propietario = _Nombre_Propietario,
                        Domicilio = Domicilio,
                        Telefono = Telefono },
                    ListaProducto = ListaProductos
                };
                if (State == EntityState.Create)
                    return await productosProveedorRepository.AddAsync(model, Id);
                else
                if (State == EntityState.Update)
                    return await productosProveedorRepository.UpdateAsync(model, Id);

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
                return await proveedorRepository.DeleteAsync(IdProveedor, Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Binding(Variables)

        private int _IdProveedor;

        public int IdProveedor
        {
            get { return _IdProveedor; }
            set
            {
                _IdProveedor = value;
                OnPropertyChanged(nameof(IdProveedor));

            }
        }

        private string _Nombre_Empresa;

        public string Nombre_Empresa
        {
            get { return _Nombre_Empresa; }
            set
            {
                _Nombre_Empresa = value;
                OnPropertyChanged(nameof(Nombre_Empresa));

            }
        }



        private string _Nombre_Propietario;

        public string Nombre_Propietario
        {
            get { return _Nombre_Propietario; }
            set
            {
                _Nombre_Propietario = value;
                OnPropertyChanged(nameof(Nombre_Propietario));
            }
        }

        private string _Domicilio;

        public string Domicilio
        {
            get { return _Domicilio; }
            set
            {
                _Domicilio = value;
                OnPropertyChanged(nameof(Domicilio));

            }
        }

        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set
            {
                _Telefono = value;
                OnPropertyChanged(nameof(Telefono));

            }
        }
        public bool Modificar { get; set; }

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
