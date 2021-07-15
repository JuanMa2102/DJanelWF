using DJanel.Muebles.Business.ValueObjects;
using DJanel.Muebles.Business.ViewModels.Productos;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.WFApplication.Constants;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DJanel.Muebles.WFApplication.Forms.Productos
{
    public partial class FrmProductosGrid : Form
    {
        #region Propiedades publicas
        public ProductoGridViewModel Model { get; set; }
        #endregion

        #region Propiedades privadas
        private SelectMode Tipo;
        #endregion
        
        #region Metodos
        public FrmProductosGrid()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<ProductoGridViewModel>();
        }

        public FrmProductosGrid(SelectMode tipo)
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<ProductoGridViewModel>();
            Tipo = tipo;
        }

        private void IniciarBinding()
        {
            try
            {

                BusquedaControl.DataBindings.Add("Text", Model, "Busqueda", true, DataSourceUpdateMode.OnPropertyChanged);

                this.DataGrid.AutoGenerateColumns = false;
                DataGrid.DataBindings.Add("DataSource", Model, "ListaProductos", true, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void ObtenerMultipleSelection()
        {
            try
            {
                
                if (DataGrid.SelectedItems.Count > 0)
                {
                    foreach (var item in DataGrid.SelectedItems)
                    {
                        Model.ListaSeleccionados.Add((Producto)item);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ObtenerSingleSelection()
        {
            try
            {
                if (DataGrid.SelectedItems.Count == 1)
                {
                    Model.Producto =  (Producto)DataGrid.SelectedItem;
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
                if (Tipo == SelectMode.Single)
                {
                    this.DataGrid.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Single;
                }
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
                if (Tipo == SelectMode.Multiple)
                    ObtenerMultipleSelection();
                else
                if (Tipo == SelectMode.Single)
                    ObtenerSingleSelection();

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), Messages.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public BindingList<Producto> GetProductos()
        {
            return Model.ListaSeleccionados;
        }

        public Producto GetProductoSingle()
        {
            return Model.Producto;
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
            if(e.KeyCode == Keys.Enter)
            {
                pictureBox1_Click(this, e);
            }
        }

        #endregion
    }
}
