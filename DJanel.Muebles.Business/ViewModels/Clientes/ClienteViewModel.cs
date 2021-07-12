using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Contracts.Validations;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.ViewModels.Clientes
{
    public class ClienteViewModel : Validable, INotifyPropertyChanged
    {
        #region Propiedades privadas
        private IClienteRepository Repository { get; set; }
        #endregion

        #region Propiedades públicas
        public BindingList<Cliente> ListaClientes { get; set; }
        public EntityState State { get; set; }
        #endregion

        #region Constructor
        public ClienteViewModel(IClienteRepository repository)
        {
            Repository = repository;
            ListaClientes = new BindingList<Cliente>();
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

        public async Task<Cliente> Guardar(int Id)
        {
            try
            {
                Cliente model = new Cliente
                {
                    IdCliente = IdCliente,
                    Nombre = Nombre,
                    Apellido_Pat = Apellido_Pat,
                    Apellido_Mat = Apellido_Mat,
                    Domicilio = Domicilio,
                    Telefono = Telefono,
                    Fecha_Nac = Fecha_Nac
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
                return await Repository.DeleteAsync(IdCliente, Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Binding(Variables)

        private int _IdCliente;

        public int IdCliente
        {
            get { return _IdCliente; }
            set
            {
                _IdCliente = value;
                OnPropertyChanged(nameof(IdCliente));

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

        private string _Apellido_Pat;

        public string Apellido_Pat
        {
            get { return _Apellido_Pat; }
            set
            {
                _Apellido_Pat = value;
                OnPropertyChanged(nameof(Apellido_Pat));
            }
        }

        private string _Apellido_Mat;

        public string Apellido_Mat
        {
            get { return _Apellido_Mat; }
            set
            {
                _Apellido_Mat = value;
                OnPropertyChanged(nameof(Apellido_Mat));
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

        private DateTime _Fecha_Nac;

        public DateTime Fecha_Nac
        {
            get { return _Fecha_Nac; }
            set
            {
                _Fecha_Nac = value;
                OnPropertyChanged(nameof(Fecha_Nac));
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
