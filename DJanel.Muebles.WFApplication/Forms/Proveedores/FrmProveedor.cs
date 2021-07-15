using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.Business.ViewModels.Proveedores;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.WFApplication.Constants;
using DJanel.Muebles.WFApplication.Extencions;
using DJanel.Muebles.WFApplication.Forms.Productos;
using DJanel.Muebles.WFApplication.Session;
using System;
using System.Windows.Forms;

namespace DJanel.Muebles.WFApplication.Forms.Proveedores
{
    public partial class FrmProveedor : Form
    {
        #region Propiedades publicas
        public ProveedorViewModel Model { get; set; }
        #endregion

        #region Metodos
        public FrmProveedor()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<ProveedorViewModel>();
        }

        private void IniciarBinding()
        {
            try
            {
                Nombre_EmpresaControl.DataBindings.Add("Text", Model, "Nombre_Empresa", true, DataSourceUpdateMode.OnPropertyChanged);
                Nombre_PropietarioControl.DataBindings.Add("Text", Model, "Nombre_Propietario", true, DataSourceUpdateMode.OnPropertyChanged);
                TelefonoControl.DataBindings.Add("Text", Model, "Telefono", true, DataSourceUpdateMode.OnPropertyChanged);
                DomicilioControl.DataBindings.Add("Text", Model, "Domicilio", true, DataSourceUpdateMode.OnPropertyChanged);
                
                this.DataGrid.AutoGenerateColumns = false;
                DataGrid.DataBindings.Add("DataSource", Model, "ListaProveedores", true, DataSourceUpdateMode.OnPropertyChanged);

                this.GridProductos.AutoGenerateColumns = false;
                GridProductos.DataBindings.Add("DataSource", Model, "ListaProductos", true, DataSourceUpdateMode.OnPropertyChanged);
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
                Nombre_EmpresaControl.Text = "";
                Nombre_PropietarioControl.Text = "";
                TelefonoControl.Text = "";
                DomicilioControl.Text = "";
                Model.ListaProductos.Clear();

                GBUsuario.Text = "Nuevo Proveedor";
                Model.State = EntityState.Create;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Proveedor ObtenerSeleccionado()
        {
            try
            {
                if (DataGrid.SelectedItems.Count == 1)
                {
                    return (Proveedor)DataGrid.SelectedItem;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Producto ObtenerProductoSeleccionado()
        {
            try
            {
                if (GridProductos.SelectedItems.Count == 1)
                {
                    return (Producto)GridProductos.SelectedItem;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AbrirForm()
        {
            try
            {
                var HomeForm = new FrmProductosGrid();
                HomeForm.ShowDialog();
                HomeForm.Dispose();
                GridProductos.Refresh();
                Model.GetListaProductos(HomeForm.GetProductos());
            }
            catch (Exception ex)
            {
                throw ex;
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
                            Model.IdProveedor = item.IdProveedor;
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
                this.CleanErrors(errorProviderUsuario, typeof(ProveedorViewModel));
            }
            catch (Exception)
            {

                MessageBox.Show(Messages.ErrorLoadMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CleanErrors(errorProviderUsuario, typeof(ProveedorViewModel));
                var item = ObtenerSeleccionado();
                if (item != null)
                {
                    GBUsuario.Text = "Modificar Proveedor";
                    Model.IdProveedor = item.IdProveedor;
                    Model.Nombre_Empresa = item.Nombre_Empresa;
                    Model.Nombre_Propietario = item.Nombre_Propietario;
                    Model.Telefono = item.Telefono;
                    Model.Domicilio = item.Domicilio;
                    await Model.LlenarListaProductosAsync();

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
                this.CleanErrors(errorProviderUsuario, typeof(ProveedorViewModel));
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
                    this.ShowErrors(errorProviderUsuario, typeof(ProveedorViewModel), validationResults);
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

        private async void FrmProveedor_Shown(object sender, EventArgs e)
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

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirForm();
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
                var item = ObtenerProductoSeleccionado();
                DataGrid.Refresh();
                Model.RemoveListaProductos(item);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
