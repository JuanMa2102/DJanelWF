using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.Business.ViewModels.Usuarios;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.WFApplication.Constants;
using DJanel.Muebles.WFApplication.Extencions;
using DJanel.Muebles.WFApplication.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DJanel.Muebles.WFApplication.Forms.Usuarios
{
    public partial class FrmPerfil : Form
    {
        #region Propiedades publicas
        public PerfilViewModel Model { get; set; }
        #endregion
        public FrmPerfil()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<PerfilViewModel>();
        }

        private void IniciarBinding()
        {
            try
            {
                NombreControl.DataBindings.Add("Text", Model, "Nombre", true, DataSourceUpdateMode.OnPropertyChanged);
                Apellido_PatControl.DataBindings.Add("Text", Model, "Apellido_Pat", true, DataSourceUpdateMode.OnPropertyChanged);
                Apellido_MatControl.DataBindings.Add("Text", Model, "Apellido_Mat", true, DataSourceUpdateMode.OnPropertyChanged);
                TelefonoControl.DataBindings.Add("Text", Model, "Telefono", true, DataSourceUpdateMode.OnPropertyChanged);
                DomicilioControl.DataBindings.Add("Text", Model, "Domicilio", true, DataSourceUpdateMode.OnPropertyChanged);
                UsernameControl.DataBindings.Add("Text", Model, "Username", true, DataSourceUpdateMode.OnPropertyChanged);
                PasswordControl.DataBindings.Add("Text", Model, "Password", true, DataSourceUpdateMode.OnPropertyChanged);
                PasswordDosControl.DataBindings.Add("Text", Model, "PasswordDos", true, DataSourceUpdateMode.OnPropertyChanged);

                PasswordEnable.DataBindings.Add("Checked", Model, "Enable", true, DataSourceUpdateMode.OnPropertyChanged);
                PanelPassword.DataBindings.Add("Visible", Model, "Enable", true, DataSourceUpdateMode.OnPropertyChanged);
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
                CurrentSession.Nombre = Model.Nombre;
                CurrentSession.Apellido_Pat = Model.Apellido_Pat;
                CurrentSession.Apellido_Mat = Model.Apellido_Mat;
                CurrentSession.Domicilio = Model.Domicilio;
                CurrentSession.Username = Model.Username;
                CurrentSession.IdRol = Model.IdRol;
                CurrentSession.NombreCompleto = Model.NombreCompleto;
                CurrentSession.Telefono = Model.Telefono;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async void FrmPerfil_Shown(object sender, EventArgs e)
        {
            IniciarBinding();
            await Model.GetAsync(CurrentSession.IdUsuario);
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Model.State = EntityState.Update;
                BtnGuardar.Enabled = true;
                this.CleanErrors(errorProviderUsuario, typeof(UsuarioViewModel));
                var validationResults = Model.Validate();
                validationResults.ToString();

                if (validationResults.IsValid)
                {
                    var Resultado = await Model.Guardar(CurrentSession.IdUsuario);

                    if (Resultado.Resultado == 1)
                    {
                        MessageBox.Show(Messages.SuccessMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        await Model.GetAsync(CurrentSession.IdUsuario);
                        GuardarSession();
                        Model.Enable = false;
                        BtnGuardar.Enabled = false;
                    }
                    else
                        MessageBox.Show(Messages.ErrorMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    this.ShowErrors(errorProviderUsuario, typeof(UsuarioViewModel), validationResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BtnGuardar.Enabled = true;
            }
        }
    }
}
