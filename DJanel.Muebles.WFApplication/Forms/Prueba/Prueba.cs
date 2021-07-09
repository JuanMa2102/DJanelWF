using DJanel.Muebles.Business.ViewModels.Prueba;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.Entities.Prueba;
using System;
using System.Windows.Forms;

namespace DJanel.Muebles.WFApplication.Forms.Prueba
{
    public partial class Prueba : Form
    {
        #region Propiedades Públicas
        public ProductoViewModel Model { get; set; }
        #endregion

        public Prueba()
        {
            InitializeComponent();
            Model = ServiceLocator.Instance.Resolve<ProductoViewModel>();
            IniciarBinding();
        }

        private void IniciarBinding()
        {
            try
            {
                NombreControl.DataBindings.Add("Text", Model, "Nombre", true, DataSourceUpdateMode.OnPropertyChanged);
                PrecioControl.DataBindings.Add("Text", Model, "Precio", true, DataSourceUpdateMode.OnPropertyChanged);

                this.dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataBindings.Add("DataSource", Model, "ListaProductos", true, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                btnGuardar.Enabled = false;
                Producto Resul = await Model.GuardarCambios();
                await Model.GetAllAsync();
                    
            }
            catch (Exception ex)
            {
                //ErrorLogHelper.AddExcFileTxt(ex, "FrmCategoriaProducto ~ btnGuardar_Click(object sender, EventArgs e)");
                //CIDMessageBox.ShowAlert(Messages.SystemName, Messages.ErrorMessage, TypeMessage.error);
                
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }


    }
}
