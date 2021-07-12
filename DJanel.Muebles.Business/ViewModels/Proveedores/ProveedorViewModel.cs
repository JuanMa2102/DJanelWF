using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Contracts.Validations;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.ViewModels.Proveedores
{
    public class ProveedorViewModel : Validable, INotifyPropertyChanged
    {
        #region Propiedades privadas
        private IProveedorRepository proveedorRepository { get; set; }
        #endregion

        #region Propiedades públicas
        public BindingList<Proveedor> ListaProveedores { get; set; }
        public EntityState State { get; set; }
        #endregion

        #region Constructor
        public ProveedorViewModel(IProveedorRepository ProveedorRepository)
        {
            proveedorRepository = ProveedorRepository;
            ListaProveedores = new BindingList<Proveedor>();
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

        public async Task<Proveedor> Guardar(int Id)
        {
            try
            {
                Proveedor model = new Proveedor
                {
                    IdProveedor = IdProveedor,
                    Nombre_Empresa = Nombre_Empresa,
                    Nombre_Propietario = _Nombre_Propietario,
                    Domicilio = Domicilio,
                    Telefono = Telefono
                };
                if (State == EntityState.Create)
                    return await proveedorRepository.AddAsync(model, Id);
                else
                if (State == EntityState.Update)
                    return await proveedorRepository.UpdateAsync(model, Id);

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
