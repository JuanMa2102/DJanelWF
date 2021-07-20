using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.Business.ViewModels.Usuarios;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.WFApplication.Constants;
using DJanel.Muebles.WFApplication.Extencions;
using DJanel.Muebles.WFApplication.Session;
using System;
using System.Windows.Forms;

namespace DJanel.Muebles.WFApplication.Forms.Usuarios
{
    public partial class FrmUsuario : Form
    {
        #region Propiedades publicas
        public UsuarioViewModel Model { get; set; }
        #endregion
        
        #region Metodos
        public FrmUsuario()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<UsuarioViewModel>();
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
                IdRolControl.DataBindings.Add("SelectedValue", Model, "IdRol", true, DataSourceUpdateMode.OnPropertyChanged);
                IdRolControl.DataBindings.Add("DataSource", Model, "ListaRol", true, DataSourceUpdateMode.OnPropertyChanged);
                this.DataGridUsuario.AutoGenerateColumns = false;
                DataGridUsuario.DataBindings.Add("DataSource", Model, "ListaUsuarios", true, DataSourceUpdateMode.OnPropertyChanged);
                
                IniciarComboRol();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void IniciarComboRol()
        {
            try
            {
                IdRolControl.DisplayMember = "Nombre";
                IdRolControl.ValueMember = "IdRol";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LimpiarPropiedades()
        {
            try
            {
                NombreControl.Text = "";
                Apellido_PatControl.Text = "";
                Apellido_MatControl.Text = "";
                TelefonoControl.Text = "";
                DomicilioControl.Text = "";
                UsernameControl.Text = "";
                PasswordControl.Text = "";
                PasswordDosControl.Text = "";
                IdRolControl.SelectedIndex = 0;

                Model.Modificar = false;
                PanelPassword.Visible = true;
                GBUsuario.Text = "Nuevo Usuario";

                Model.State = EntityState.Create;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Usuario ObtenerSeleccionado()
        {
            try
            {
                if (DataGridUsuario.SelectedItems.Count == 1)
                {
                    return (Usuario)DataGridUsuario.SelectedItem;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
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
                CurrentSession.NombreRol = Model.NombreRol;
                CurrentSession.NombreCompleto = Model.NombreCompleto;
                CurrentSession.Telefono = Model.Telefono;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Eventos
        async private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
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
                        if (Model.IdUsuario == CurrentSession.IdUsuario)
                        {
                            await Model.GetAsync(CurrentSession.IdUsuario);
                            if (Model.IdRol != CurrentSession.IdRol)
                            {
                                MessageBox.Show(Messages.CloseSession, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //this.Close();
                            }
                            GuardarSession();
                        }
                        LimpiarPropiedades();
                        DataGridUsuario.Refresh();
                        await Model.GetAllAsync();
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

        async private void FrmUsuario_Shown(object sender, EventArgs e)
        {
            try
            {
                await Model.LlenarListaRol();
                await Model.GetAllAsync();
                IniciarBinding();
                if (CurrentSession.IdRol == 2)
                {
                    this.BtnEliminar.Visible = false;
                    this.BtnModificar.Visible = false;
                    this.BtnNuevo.Visible = false;
                    this.BtnGuardar.Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.CleanErrors(errorProviderUsuario, typeof(UsuarioViewModel));
                var item = ObtenerSeleccionado();
                if (item != null)
                {
                    GBUsuario.Text = "Modificar Usuario";
                    PanelPassword.Visible = false;
                    Model.IdUsuario = item.IdUsuario;
                    Model.Username = item.Username;
                    Model.Nombre = item.Nombre;
                    Model.Apellido_Pat = item.Apellido_Pat;
                    Model.Apellido_Mat = item.Apellido_Mat;
                    Model.Telefono = item.Telefono;
                    Model.Domicilio = item.Domicilio;
                    Model.IdRol = item.DatosRol.IdRol;
                    Model.State = EntityState.Update;
                    Model.Modificar = true;
                    
                }
                else
                    MessageBox.Show(Messages.GridSelectMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarPropiedades();
                this.CleanErrors(errorProviderUsuario, typeof(UsuarioViewModel));
            }
            catch (Exception)
            {

                MessageBox.Show(Messages.ErrorLoadMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var item = ObtenerSeleccionado();
                if (item != null)
                {
                    if (item.IdUsuario == CurrentSession.IdUsuario)
                    {

                        if (MessageBox.Show(Messages.ConfirmDeleteMessage, Messages.SystemName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Model.IdUsuario = item.IdUsuario;
                            var result = await Model.Remove(CurrentSession.IdUsuario);

                            if (result == 1)
                            {
                                MessageBox.Show(Messages.SuccessDeleteMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarPropiedades();
                                DataGridUsuario.Refresh();
                                await Model.GetAllAsync();
                            }
                            else
                                MessageBox.Show(Messages.ErrorDeleteMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    MessageBox.Show(Messages.DeleteCurrentUser, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(Messages.GridSelectMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show(Messages.ErrorLoadMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
