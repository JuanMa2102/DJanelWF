using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Contracts.Validations;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.ViewModels.Usuarios
{
    public class UsuarioViewModel : Validable, INotifyPropertyChanged
    {
        #region Propiedades privadas
        private IRolRepository RolRepository { get; set; }
        private IUsuarioRepository UsuarioRepository { get; set; }
        #endregion

        #region Propiedades públicas
        public BindingList<Rol> ListaRol { get; set; }
        public BindingList<Usuario> ListaUsuarios { get; set; }
        public EntityState State { get; set; }
        #endregion

        #region Constructor
        public UsuarioViewModel(IRolRepository rolRepository, IUsuarioRepository usuarioRepository)
        {
            IdRol = 0;
            Password = "";
            PasswordDos = "";
            Modificar = false;
            RolRepository = rolRepository;
            UsuarioRepository = usuarioRepository;
            ListaRol = new BindingList<Rol>();
            ListaUsuarios = new BindingList<Usuario>();
        }
        #endregion

        #region Metodos
        public async Task GetAllAsync()
        {
            try
            {
                var x = await UsuarioRepository.GetAllAsync();
                ListaUsuarios.Clear();
                foreach (var item in x)
                {
                    item.NombreCompleto = item.Nombre + " " + item.Apellido_Pat + " "+ item.Apellido_Mat;
                    ListaUsuarios.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task LlenarListaRol()
        {
            try
            {
                var listaRol = await RolRepository.GetComboRol();
                foreach (var item in listaRol)
                {
                    ListaRol.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> Guardar(int Id)
        {
            try
            {
                Usuario model = new Usuario
                {
                    IdUsuario = IdUsuario,
                    Nombre = Nombre,
                    Apellido_Pat = Apellido_Pat,
                    Apellido_Mat = Apellido_Mat,
                    Domicilio = Domicilio,
                    Telefono = Telefono,
                    DatosRol = { IdRol = IdRol },
                    Username = Username,
                    Password = Password,
                    
                };
                if (State == EntityState.Create)
                    return await UsuarioRepository.AddAsync(model, Id);
                else
                if (State == EntityState.Update)
                    return await UsuarioRepository.UpdateAsync(model, Id);

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
                return await UsuarioRepository.DeleteAsync(IdUsuario, Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task GetAsync(int Idusuario)
        {
            try
            {
                var x = await UsuarioRepository.GetAsync(Idusuario);
                IdUsuario = x.IdUsuario;
                Nombre = x.Nombre;
                Apellido_Pat = x.Apellido_Pat;
                Apellido_Mat = x.Apellido_Mat;
                Domicilio = x.Domicilio;
                Telefono = x.Telefono;
                Username = x.Username;
                IdRol = x.DatosRol.IdRol;
                NombreRol = x.DatosRol.Nombre;
                NombreCompleto = x.Nombre + " " + x.Apellido_Pat + " " + x.Apellido_Mat;
                Password = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Binding(Variables)

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
