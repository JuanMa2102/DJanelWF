using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.Business.ViewModels.Productos;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.WFApplication.Constants;
using DJanel.Muebles.WFApplication.Extencions;
using DJanel.Muebles.WFApplication.Forms.Proveedores;
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

namespace DJanel.Muebles.WFApplication.Forms.Productos
{
    public partial class FrmProductoCompra : Form
    {

        #region Propiedades publicas
        public ProductoCompraViewModel Model { get; set; }
        #endregion

        #region Metodos
        public FrmProductoCompra()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<ProductoCompraViewModel>();
        }

        private void IniciarBinding()
        {
            try
            {
                CantidadControl.DataBindings.Add("Text", Model, "Cantidad", true, DataSourceUpdateMode.OnPropertyChanged);
                TotalControl.DataBindings.Add("Text", Model, "Total", true, DataSourceUpdateMode.OnPropertyChanged);
                CostoControl.DataBindings.Add("Text", Model, "Costo", true, DataSourceUpdateMode.OnPropertyChanged);
                FechaControl.DataBindings.Add("Text", Model, "FechaString", true, DataSourceUpdateMode.OnPropertyChanged);
                
                this.DataGrid.AutoGenerateColumns = false;
                DataGrid.DataBindings.Add("DataSource", Model, "ListaProductosCompra", true, DataSourceUpdateMode.OnPropertyChanged);
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
                ProductoControl.Text = "";
                ProveedorControl.Text = "";
                Model.Cantidad = 0;
                Model.Total = 0;
                Model.Costo = 0;
                Model.Fecha = DateTime.Now;

                GBoxFormulario.Text = "Nueva Compra";
                Model.State = EntityState.Create;

                ProveedorBusqueda.Visible = true;
                ProductoBusqueda.Visible = true;

                errorProvider.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ValidarBusqueda()
        {
            try
            {
                errorProvider.Clear();
                if (Model.Producto.IdProducto == 0)
                {
                    errorProvider.SetError(ProductoBusqueda,Messages.ErroNotSelectProducto );
                    return false;
                }
                else if (Model.Proveedor.IdProveedor == 0)
                {
                    errorProvider.SetError(ProveedorBusqueda,Messages.ErrorNotSelectProveedor);
                    return false;
                }
                else return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ProductoCompra ObtenerSeleccionado()
        {
            try
            {
                if (DataGrid.SelectedItems.Count == 1)
                {
                    return (ProductoCompra)DataGrid.SelectedItem;
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
        private void ProductoBusqueda_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            var HomeForm = new FrmProductosGrid(SelectMode.Single);
            HomeForm.ShowDialog();
            HomeForm.Dispose();
            DataGrid.Refresh();

            var _Producto = HomeForm.GetProductoSingle();

            if(Model.Producto != _Producto)
            {
                Model.Producto = _Producto;
                ProductoControl.Text = Model.Producto.Nombre;
                ProveedorControl.Text = string.Empty;
            }
        }

        private void ProveedorBusqueda_Click(object sender, EventArgs e)
        { 
            if (Model.Producto.IdProducto != 0)
            {
                errorProvider.Clear();
                var HomeForm = new FrmProveedorGrid(Model.Producto);
                HomeForm.ShowDialog();
                HomeForm.Dispose();
                DataGrid.Refresh();

                Model.Proveedor = HomeForm.GetProductoSingle();
                ProveedorControl.Text = Model.Proveedor.Nombre_Empresa;
            }
            else
            {
                errorProvider.SetError(ProductoBusqueda, Messages.ErroNotSelectProducto);
            }
        }

        private async void FrmProductoCompra_Shown(object sender, EventArgs e)
        {
            try
            {
                await Model.GetAllAsync();
                IniciarBinding();
                Model.FechaString = DateTime.Now.ToShortDateString();
                Model.Fecha = DateTime.Now;

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

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BtnGuardar.Enabled = true;
                if (ValidarBusqueda())
                {
                    this.CleanErrors(errorProvider, typeof(ProductoCompraViewModel));
                    var validationResults = Model.Validate();
                    validationResults.ToString();

                    if (validationResults.IsValid)
                    {
                        BtnGuardar.Enabled = false;
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
                        if (Resultado.Resultado == -1)
                        {
                            MessageBox.Show(Messages.ErroAlmacenProducto, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarPropiedades();
                            BtnGuardar.Enabled = false;
                        }
                        else
                            MessageBox.Show(Messages.ErrorMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        this.ShowErrors(errorProvider, typeof(ProductoCompraViewModel), validationResults);
                }
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

        #region Evento Hover
        private void ProveedorBusqueda_MouseHover(object sender, EventArgs e)
        {
            this.ProveedorBusqueda.Image = Properties.Resources.buscar_hoover;
        }
        private void ProductoBusqueda_MouseHover(object sender, EventArgs e)
        {
            this.ProductoBusqueda.Image = Properties.Resources.buscar_hoover;
        }

        private void ProductoBusqueda_MouseLeave(object sender, EventArgs e)
        {
            this.ProductoBusqueda.Image = Properties.Resources.BUSCAR;
        }
        private void ProveedorBusqueda_MouseLeave(object sender, EventArgs e)
        {
            this.ProveedorBusqueda.Image = Properties.Resources.BUSCAR;
        }
        #endregion

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CleanErrors(errorProvider, typeof(ProductoCompraViewModel));
                var item = ObtenerSeleccionado();
                if (item != null)
                {
                    GBoxFormulario.Text = "Modificar Producto";
                    Model.IdProductoCompra = item.IdProductoCompra;
                    Model.Producto = item.DatosProducto;
                    Model.Proveedor = item.DatosProveedor;
                    Model.Costo = item.Costo;
                    Model.Cantidad = item.Cantidad;
                    Model.Total = item.Total;
                    Model.State = EntityState.Update;

                    ProveedorControl.Text = Model.Proveedor.Nombre_Empresa;
                    ProductoControl.Text = Model.Producto.Nombre;

                    ProductoBusqueda.Visible = false;
                    ProveedorBusqueda.Visible = false;
                }
                else
                    MessageBox.Show(Messages.GridSelectMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var item = ObtenerSeleccionado();
                if (item != null)
                {
                    if (MessageBox.Show(Messages.ConfirmDeleteMessage, Messages.SystemName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Model.IdProductoCompra = item.IdProductoCompra;
                        Model.Producto = item.DatosProducto;
                        var result = await Model.Remove(CurrentSession.IdUsuario);

                        if (result == 1)
                        {
                            MessageBox.Show(Messages.SuccessDeleteMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarPropiedades();
                            DataGrid.Refresh();
                            await Model.GetAllAsync();
                        }
                        else
                        if (result == -1)
                        {
                            MessageBox.Show(Messages.ErroAlmacenProducto, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarPropiedades();
                            BtnGuardar.Enabled = false;
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
                this.CleanErrors(errorProvider, typeof(ProductoCompraViewModel));
            }
            catch (Exception)
            {
                MessageBox.Show(Messages.ErrorLoadMessage, Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
