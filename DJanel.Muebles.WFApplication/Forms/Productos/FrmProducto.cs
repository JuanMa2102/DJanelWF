using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.Business.ViewModels.Productos;
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

namespace DJanel.Muebles.WFApplication.Forms.Productos
{
    public partial class FrmProducto : Form
    {
        #region Propiedades publicas
        public ProductoViewModel Model { get; set; }
        #endregion

        #region Metodos
        public FrmProducto()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<ProductoViewModel>();
        }

        private void IniciarBinding()
        {
            try
            {
                NombreControl.DataBindings.Add("Text", Model, "Nombre", true, DataSourceUpdateMode.OnPropertyChanged);
                DescripcionControl.DataBindings.Add("Text", Model, "Descripcion", true, DataSourceUpdateMode.OnPropertyChanged);
                StockControl.DataBindings.Add("Text", Model, "Stock", true, DataSourceUpdateMode.OnPropertyChanged);
                PrecioControl.DataBindings.Add("Text", Model, "Precio", true, DataSourceUpdateMode.OnPropertyChanged);
                MarcaControl.DataBindings.Add("Text", Model, "Marca", true, DataSourceUpdateMode.OnPropertyChanged);
                ModeloControl.DataBindings.Add("Text", Model, "Modelo", true, DataSourceUpdateMode.OnPropertyChanged);
                ClaveBusquedaControl.DataBindings.Add("Text", Model, "ClaveBusqueda", true, DataSourceUpdateMode.OnPropertyChanged);

                this.DataGrid.AutoGenerateColumns = false;
                DataGrid.DataBindings.Add("DataSource", Model, "ListaProductos", true, DataSourceUpdateMode.OnPropertyChanged);
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
                DescripcionControl.Text = "";
                Model.Stock = 0;
                Model.Precio = 0;
                MarcaControl.Text = "";
                ModeloControl.Text = "";
                ClaveBusquedaControl.Text = "";

                GBoxFormulario.Text = "Nuevo Producto";
                Model.State = EntityState.Create;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Producto ObtenerSeleccionado()
        {
            try
            {
                if (DataGrid.SelectedItems.Count == 1)
                {
                    return (Producto)DataGrid.SelectedItem;
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
                        Model.IdProducto = item.IdProducto;
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
                this.CleanErrors(errorProvider, typeof(ProductoViewModel));
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
                this.CleanErrors(errorProvider, typeof(ProductoViewModel));
                var item = ObtenerSeleccionado();
                if (item != null)
                {
                    GBoxFormulario.Text = "Modificar Producto";
                    Model.IdProducto = item.IdProducto;
                    Model.Nombre = item.Nombre;
                    Model.Descripcion = item.Descripcion;
                    Model.Stock = item.Stock;
                    Model.Precio = item.Precio;
                    Model.Marca = item.Marca;
                    Model.Modelo = item.Modelo;
                    Model.ClaveBusqueda = item.ClaveBusqueda;

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
                this.CleanErrors(errorProvider, typeof(ProductoViewModel));
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
                    this.ShowErrors(errorProvider, typeof(ProductoViewModel), validationResults);
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

        private async void FrmProducto_Shown(object sender, EventArgs e)
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
