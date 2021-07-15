using DJanel.Muebles.Business.ViewModels.Proveedores;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.WFApplication.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DJanel.Muebles.WFApplication.Forms.Proveedores
{
    public partial class FrmProveedorGrid : Form
    {
        #region Propiedades publicas
        public ProveedorGridViewModel Model { get; set; }
        #endregion

        #region Propiedades privadas
        #endregion

        #region Metodos
        public FrmProveedorGrid(Producto producto)
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<ProveedorGridViewModel>();
            Model.Producto = producto;
        }

        private void IniciarBinding()
        {
            try
            {

                BusquedaControl.DataBindings.Add("Text", Model, "Busqueda", true, DataSourceUpdateMode.OnPropertyChanged);

                this.DataGrid.AutoGenerateColumns = false;
                DataGrid.DataBindings.Add("DataSource", Model, "ListaProveedores", true, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void ObtenerSingleSelection()
        {
            try
            {
                if (DataGrid.SelectedItems.Count == 1)
                {
                    Model.Proveedor = (Proveedor)DataGrid.SelectedItem;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Eventos
        private async void FrmProductosGrid_Shown(object sender, EventArgs e)
        {
            try
            {
                await Model.GetAllAsync();
                IniciarBinding();
                LblTitulo.Text = "Proveedor de: " + Model.Producto.Nombre;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerSingleSelection();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Proveedor GetProductoSingle()
        {
            return Model.Proveedor;
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGrid.Refresh();
                await Model.BusquedaProducto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BusquedaControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBox1_Click(this, e);
            }
        }

        #endregion
    }
}
