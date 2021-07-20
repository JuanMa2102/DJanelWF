using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.Business.ViewModels.Ventas;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.WFApplication.Constants;
using DJanel.Muebles.WFApplication.Extencions;
using DJanel.Muebles.WFApplication.Forms.Clientes;
using DJanel.Muebles.WFApplication.Forms.Productos;
using DJanel.Muebles.WFApplication.Session;
using System;
using System.Windows.Forms;

namespace DJanel.Muebles.WFApplication.Forms.Ventas
{
    public partial class FrmVenta : Form
    {
        #region Propiedades publicas
        public VentaViewModel Model { get; set; }
        #endregion

        #region Metodos
        public FrmVenta()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<VentaViewModel>();
        }
        private void IniciarBinding()
        {
            try
            {
                FolioControl.DataBindings.Add("Text", Model, "Folio", true, DataSourceUpdateMode.OnPropertyChanged);
                CantidadControl.DataBindings.Add("Text", Model, "Cantidad", true, DataSourceUpdateMode.OnPropertyChanged);
                ClaveBusquedaControl.DataBindings.Add("Text", Model, "ClaveBusqueda", true, DataSourceUpdateMode.OnPropertyChanged);
                TotalControl.DataBindings.Add("Text", Model, "Total", true, DataSourceUpdateMode.OnPropertyChanged);
                ArticuloControl.DataBindings.Add("Text", Model, "Articulo", true, DataSourceUpdateMode.OnPropertyChanged);
                NombreClienteControl.DataBindings.Add("Text", Model, "NombreCliente", true, DataSourceUpdateMode.OnPropertyChanged);
                PagoControl.DataBindings.Add("Text", Model, "Pago", true, DataSourceUpdateMode.OnPropertyChanged);
                CambioControl.DataBindings.Add("Text", Model, "Cambio", true, DataSourceUpdateMode.OnPropertyChanged);

                this.ListaControl.AutoGenerateColumns = false;
                ListaControl.DataBindings.Add("DataSource", Model, "Lista", true, DataSourceUpdateMode.OnPropertyChanged);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private VentaDetalle ObtenerSeleccionado()
        {
            try
            {
                if (ListaControl.SelectedItems.Count == 1)
                {
                    return (VentaDetalle)ListaControl.SelectedItem;
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
        private async void FrmVenta_Shown(object sender, EventArgs e)
        {
            try
            {
                IniciarBinding();
                await Model.GetFolio();
                EmpleadoControl.Text = CurrentSession.NombreCompleto;
                ClaveBusquedaControl.Focus();
                Model.Cantidad = 1;
                Model.GetClienteDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Hover
        private void BusquedaRapida_MouseHover(object sender, EventArgs e)
        {
            this.BusquedaRapida.Image = Properties.Resources.ICON_PLUS_HOVER;
        }

        private void BusquedaRapida_MouseLeave(object sender, EventArgs e)
        {
            this.BusquedaRapida.Image = Properties.Resources.ICON_PLUS;
        }

        private void BusquedaCliente_MouseHover(object sender, EventArgs e)
        {
            this.BusquedaCliente.Image = Properties.Resources.ICON_SEARCH_HOVER;
        }

        private void BusquedaCliente_MouseLeave(object sender, EventArgs e)
        {
            this.BusquedaCliente.Image = Properties.Resources.ICON_SEARCH;
        }

        private void newClient_MouseHover(object sender, EventArgs e)
        {
            this.newClient.Image = Properties.Resources.ICON_PLUS_HOVER;
        }

        private void newClient_MouseLeave(object sender, EventArgs e)
        {
            this.newClient.Image = Properties.Resources.ICON_PLUS;
        }

        private void ProductoMas_MouseHover(object sender, EventArgs e)
        {
            this.ProductoMas.Image = Properties.Resources.ICON_PLUS_HOVER;
        }

        private void ProductoMas_MouseLeave(object sender, EventArgs e)
        {
            this.ProductoMas.Image = Properties.Resources.ICON_PLUS;
        }

        private void ProductoMenos_MouseHover(object sender, EventArgs e)
        {
            this.ProductoMenos.Image = Properties.Resources.ICON_MINUS_HOVER;
        }

        private void ProductoMenos_MouseLeave(object sender, EventArgs e)
        {
            this.ProductoMenos.Image = Properties.Resources.ICON_MINUS;
        }

        private void ProductoEliminar_MouseHover(object sender, EventArgs e)
        {
            this.ProductoEliminar.Image = Properties.Resources.ICON_ELIMINAR_HOVER;
        }

        private void ProductoEliminar_MouseLeave(object sender, EventArgs e)
        {
            this.ProductoEliminar.Image = Properties.Resources.ICON_ELIMINAR;
        }
        #endregion

        private async void BusquedaRapida_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                var x = await Model.GetProductoAsync();
                if (x.Resultado == -1)
                    errorProvider.SetError(BusquedaRapida, Messages.ErrorProductNotFound);
                else
                {
                    var result = await Model.AddProductoAsync(x);
                    if (!result) errorProvider.SetError(BusquedaRapida, Messages.ErrorStock);
                    ListaControl.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClaveBusquedaControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BusquedaRapida_Click(this, e);
            }
        }

        private void BusquedaCliente_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            var HomeForm = new FrmClienteGrid();
            HomeForm.ShowDialog();
            HomeForm.Dispose();

            Model.Cliente = HomeForm.GetProductoSingle();
            Model.NombreCliente = Model.Cliente.NombreCompleto;
            if (Model.Cliente.IdCliente == 0)
                Model.GetClienteDefault();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        #endregion

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            var HomeForm = new FrmProductosGrid(SelectMode.Single);
            HomeForm.ShowDialog();
            HomeForm.Dispose();

            var x = HomeForm.GetProductoSingle();
            
            var result = await Model.AddProductoAsync(x);
            if (!result) errorProvider.SetError(BtnBuscar, Messages.ErrorStock);
            ListaControl.Refresh();
        }

        private void ProductoEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                var item = ObtenerSeleccionado();
                if (item != null)
                {
                    Model.RemoveProducto(item);
                    ListaControl.Refresh();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void ProductoMas_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                var item = ObtenerSeleccionado();
                if (item != null)
                {
                    var result = await Model.AddCantidadProducto(item);
                    if (!result) errorProvider.SetError(AccionesGrid, Messages.ErrorStock);
                    ListaControl.Refresh();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void ProductoMenos_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                var item = ObtenerSeleccionado();
                if (item != null)
                {
                    Model.SubCantidadProducto(item);
                    ListaControl.Refresh();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void BtnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                BtnPagar.Enabled = false;
                this.CleanErrors(errorProvider, typeof(VentaViewModel));
                var validationResults = Model.Validate();
                validationResults.ToString();

                if (validationResults.IsValid)
                {
                    var Resultado = await Model.Guardar(CurrentSession.IdUsuario);

                    if (Resultado.Resultado > 0)
                    {
                        var frm = new FrmVentaResult(Resultado, Model.Folio, Model.Pago, Model.Cambio);
                        frm.ShowDialog();
                        frm.Dispose();

                        Model.LimpiarPropiedades();
                        ClaveBusquedaControl.Focus();
                        ListaControl.Refresh();
                    }
                    else  if (Resultado.Resultado == -1)
                        MessageBox.Show(Messages.ErrorStockVenta, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(Messages.ErrorMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    this.ShowErrors(errorProvider, typeof(VentaViewModel), validationResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BtnPagar.Enabled = true;
            }
        }

        private void PagoControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void PagoControl_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
