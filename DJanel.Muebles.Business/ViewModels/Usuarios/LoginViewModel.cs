using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Contracts.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.ViewModels.Usuarios
{
    public class LoginViewModel : Validable, INotifyPropertyChanged
    {
        #region Propiedades Privadas
        private IUsuarioRepository usuarioRepository { get; set; }
        #endregion

        #region Constructor
        public LoginViewModel(IUsuarioRepository repository)
        {
            usuarioRepository = repository;
        }

        #endregion

        #region Metodos
        public async Task<int?> Login()
        {
            try
            {
                Usuario x = await usuarioRepository.Login(UserAccount, UserPassword);
                IdUsuario = x.IdUsuario;
                Nombre = x.Nombre;
                Apellido_Pat = x.Apellido_Pat;
                Apellido_Mat = x.Apellido_Mat;
                Telefono = x.Telefono;
                Domicilio = x.Domicilio;
                Username = x.Username;
                NombreRol = x.DatosRol.Nombre;
                IdRol = x.DatosRol.IdRol;
                NombreCompleto = x.Nombre + " " + x.Apellido_Pat + " " + x.Apellido_Mat;
                return x.Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Binding(Variables)


        private string _UserAccount;

        public string UserAccount
        {
            get { return _UserAccount; }
            set
            {
                _UserAccount = value;
                OnPropertyChanged(nameof(UserAccount));

            }
        }

        private string _UserPassword;

        public string UserPassword
        {
            get { return _UserPassword; }
            set
            {
                _UserPassword = value;
                OnPropertyChanged(nameof(UserPassword));

            }
        }

        private int _IdRol;

        public int IdRol
        {
            get { return _IdRol; }
            set
            {
                _IdRol = value;
                OnPropertyChanged(nameof(IdRol));

            }
        }

        private int _IdUsuario;

        public int IdUsuario
        {
            get { return _IdUsuario; }
            set
            {
                _IdUsuario = value;
                OnPropertyChanged(nameof(IdUsuario));

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

        private string _NombreRol;

        public string NombreRol
        {
            get { return _NombreRol; }
            set
            {
                _NombreRol = value;
                OnPropertyChanged(nameof(NombreRol));

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

        private string _Username;

        public string Username
        {
            get { return _Username; }
            set
            {
                _Username = value;
                OnPropertyChanged(nameof(Username));

            }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged(nameof(Password));

            }
        }

        private string _PasswordDos;
        public string PasswordDos
        {
            get { return _PasswordDos; }
            set
            {
                _PasswordDos = value;
                OnPropertyChanged(nameof(PasswordDos));

            }
        }

        private string _NombreCompleto;

        public string NombreCompleto
        {
            get { return _NombreCompleto; }
            set
            {
                _NombreCompleto = value;
                OnPropertyChanged(nameof(NombreCompleto));

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