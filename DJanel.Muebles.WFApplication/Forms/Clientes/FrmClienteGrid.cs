using DJanel.Muebles.Business.ViewModels.Clientes;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.WFApplication.Constants;
using System;
using System.Windows.Forms;

namespace DJanel.Muebles.WFApplication.Forms.Clientes
{
    public partial class FrmClienteGrid : Form
    {
        #region Propiedades publicas
        public ClienteGridViewModel Model { get; set; }
        #endregion

        #region Propiedades privadas
        #endregion

        #region Metodos
        public FrmClienteGrid()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<ClienteGridViewModel>();
        }

        private void IniciarBinding()
        {
            try
            {

                BusquedaControl.DataBindings.Add("Text", Model, "Busqueda", true, DataSourceUpdateMode.OnPropertyChanged);

                this.DataGrid.AutoGenerateColumns = false;
                DataGrid.DataBindings.Add("DataSource", Model, "Listaclientes", true, DataSourceUpdateMode.OnPropertyChanged);
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
                    Model.Cliente = (Cliente)DataGrid.SelectedItem;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente GetProductoSingle()
        {
            return Model.Cliente;
        }
        #endregion

        #region Eventos
        private async void FrmClienteGrid_Shown(object sender, EventArgs e)
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

        private void BtnSeleccionar_Click(object sender, EventArgs e)
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


        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                await Model.BusquedaProducto();
                DataGrid.Refresh();
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
