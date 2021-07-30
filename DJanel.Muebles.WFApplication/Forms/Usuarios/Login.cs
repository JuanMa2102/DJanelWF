using DJanel.Muebles.Business.ViewModels.Usuarios;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.WFApplication.Constants;
using DJanel.Muebles.WFApplication.Extencions;
using DJanel.Muebles.WFApplication.Forms.Home;
using DJanel.Muebles.WFApplication.Session;
using System;
using System.Windows.Forms;

namespace DJanel.Muebles.WFApplication.Forms.Usuarios
{
    public partial class Login : Form
    {
        #region Propiedades
        public LoginViewModel Model { get; set; }
        #endregion

        #region Constructor
        public Login()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<LoginViewModel>();
        }
        #endregion

        #region Métodos
        private void IniciarBinding()
        {
            try
            {
                UserAccountControl.DataBindings.Add("Text", Model, "UserAccount", true, DataSourceUpdateMode.OnPropertyChanged);
                UserPasswordControl.DataBindings.Add("Text", Model, "UserPassword", true, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GuardarSession()
        {
            try
            {
                CurrentSession.IdUsuario = Model.IdUsuario;
                CurrentSession.Nombre = Model.Nombre;
                CurrentSession.Apellido_Pat = Model.Apellido_Pat;
                CurrentSession.Apellido_Mat = Model.Apellido_Mat;
                CurrentSession.Domicilio = Model.Domicilio;
                CurrentSession.Username = Model.Username;
                CurrentSession.IdRol = Model.IdRol;
                CurrentSession.NombreRol = Model.NombreRol;
                CurrentSession.NombreCompleto = Model.NombreCompleto;
                CurrentSession.Telefono = Model.Telefono;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void AbrirFormHome()
        {
            try
            {
                this.Visible = false;
                var HomeForm = new FrmHome();
                HomeForm.ShowDialog();
                HomeForm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ObtenerMensajeError(int? Error)
        {
            try
            {
                //string ErrorMessage = Constants.LoginErrorMessage;
                string ErrorMessage = "FAVOR DE VERIFICAR BIEN SUS CREDENCIALES";
                switch (Error)
                {
                    case -9:
                        ErrorMessage = "La cuenta de usuario no existe.";
                        break;
                    case -7:
                        ErrorMessage = "La contraseña es incorrecta.";
                        break;
                }
                return ErrorMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Eventos

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {

                MessageBox.Show(Messages.Error, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                LblError.Visible = false;
                this.CleanErrors(errorProvider1, typeof(LoginViewModel));
                var validationResults = Model.Validate();
                if (validationResults.IsValid)
                {
                    BtnLogin.Enabled = false;
                    var x = await Model.Login();
                    if (x == 1)
                    {
                        GuardarSession();
                        AbrirFormHome();
                        this.UserAccountControl.Text = string.Empty;
                        this.UserPasswordControl.Text = string.Empty;
                    }
                    else
                    {
                        LblError.Visible = true;
                        LblError.Text = ObtenerMensajeError(x);
                    }
                }
                else
                    this.ShowErrors(errorProvider1, typeof(LoginViewModel), validationResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                BtnLogin.Enabled = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                IniciarBinding();
                //this.LblVersion.Text = "Version 1.0.0";
                //this.LblEmpresa.Text = "Impulsado por ITTG - Todos los derechos reservados " + DateTime.Now.Year.ToString();
                //this.LblDerechoReservado.Text = "Impulsado por CID Fares® - Todos los derechos reservados " + DateTime.Now.Year.ToString();
                //UserAccountControl.Text = "admin";
                //UserPasswordControl.Text = "123456";
                //BtnLogin_Click(this,e);
            }
            catch (Exception)
            {
                MessageBox.Show(Messages.Error, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        private void lblversion_Click(object sender, EventArgs e)
        {

        }
    }
}
