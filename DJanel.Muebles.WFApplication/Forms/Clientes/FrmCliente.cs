using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.Business.ViewModels.Clientes;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.Entities;
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

namespace DJanel.Muebles.WFApplication.Forms.Clientes
{
    public partial class FrmCliente : Form
    {
        #region Propiedades publicas
        public ClienteViewModel Model { get; set; }
        #endregion

        #region Metodos
        public FrmCliente()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<ClienteViewModel>();
        }

        private void IniciarBinding()
        {
            try
            {
                NombreControl.DataBindings.Add("Text", Model, "Nombre", true, DataSourceUpdateMode.OnPropertyChanged);
                Apellido_PatControl.DataBindings.Add("Text", Model, "Apellido_Pat", true, DataSourceUpdateMode.OnPropertyChanged);
                Apellido_MatControl.DataBindings.Add("Text", Model, "Apellido_Mat", true, DataSourceUpdateMode.OnPropertyChanged);
                DomicilioControl.DataBindings.Add("Text", Model, "Domicilio", true, DataSourceUpdateMode.OnPropertyChanged);
                Fecha_NacControl.DataBindings.Add("Text", Model, "Fecha_Nac", true, DataSourceUpdateMode.OnPropertyChanged);
                TelefonoControl.DataBindings.Add("Text", Model, "Telefono", true, DataSourceUpdateMode.OnPropertyChanged);

                this.DataGrid.AutoGenerateColumns = false;
                DataGrid.DataBindings.Add("DataSource", Model, "ListaClientes", true, DataSourceUpdateMode.OnPropertyChanged);
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
                Model.Nombre = string.Empty;
                Model.Apellido_Pat = string.Empty;
                Model.Apellido_Mat = string.Empty;
                Model.Fecha_Nac = DateTime.Now;
                Model.Domicilio = string.Empty;
                Model.Telefono = string.Empty;

                GBoxFormulario.Text = "Nuevo Cliente";
                Model.State = EntityState.Create;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Cliente ObtenerSeleccionado()
        {
            try
            {
                if (DataGrid.SelectedItems.Count == 1)
                {
                    return (Cliente)DataGrid.SelectedItem;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Eventos
        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var item = ObtenerSeleccionado();
                if (item != null)
                {
                    if (MessageBox.Show(Messages.ConfirmDeleteMessage, Messages.SystemName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Model.IdCliente = item.IdCliente;
                        var result = await Model.Remove(CurrentSession.IdUsuario);

                        if (result == 1)
                        {
                            MessageBox.Show(Messages.SuccessDeleteMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarPropiedades();
                            DataGrid.Refresh();
                            await Model.GetAllAsync();
                        }
                        else
                            MessageBox.Show(Messages.ErrorDeleteMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show(Messages.GridSelectMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show(Messages.ErrorLoadMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarPropiedades();
                this.CleanErrors(errorProvider, typeof(ClienteViewModel));
            }
            catch (Exception)
            {

                MessageBox.Show(Messages.ErrorLoadMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CleanErrors(errorProvider, typeof(ClienteViewModel));
                var item = ObtenerSeleccionado();
                if (item != null)
                {
                    GBoxFormulario.Text = "Modificar Cliente";
                    Model.IdCliente = item.IdCliente;
                    Model.Nombre = item.Nombre;
                    Model.Apellido_Pat = item.Apellido_Pat;
                    Model.Apellido_Mat = item.Apellido_Mat;
                    Model.Domicilio = item.Domicilio;
                    Model.Fecha_Nac = item.Fecha_Nac;
                    Model.Telefono = item.Telefono;

                    Model.State = EntityState.Update;
                }
                else
                    MessageBox.Show(Messages.GridSelectMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BtnGuardar.Enabled = true;
                this.CleanErrors(errorProvider, typeof(ClienteViewModel));
                var validationResults = Model.Validate();
                validationResults.ToString();

                if (validationResults.IsValid)
                {
                    var Resultado = await Model.Guardar(CurrentSession.IdUsuario);

                    if (Resultado.Resultado == 1)
                    {
                        MessageBox.Show(Messages.SuccessMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarPropiedades();
                        DataGrid.Refresh();
                        await Model.GetAllAsync();
                        BtnGuardar.Enabled = false;
                    }
                    else
                        MessageBox.Show(Messages.ErrorMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    this.ShowErrors(errorProvider, typeof(ClienteViewModel), validationResults);
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

        private async void FrmCliente_Shown(object sender, EventArgs e)
        {
            try
            {
                await Model.GetAllAsync();
                IniciarBinding();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
