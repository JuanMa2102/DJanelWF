using System;
using System.Windows.Forms;
using DJanel.Muebles.WFApplication.Forms.Clientes;
using DJanel.Muebles.WFApplication.Forms.Productos;
using DJanel.Muebles.WFApplication.Forms.Proveedores;
using DJanel.Muebles.WFApplication.Forms.Usuarios;
using DJanel.Muebles.WFApplication.Session;

namespace DJanel.Muebles.WFApplication.Forms.Home
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void GetPanel(object Formhijo)
        {
            try
            {
                if (this.pnl_Contenedor.Controls.Count > 0)
                {
                    for (int i = 0; i < pnl_Contenedor.Controls.Count+1; i++)
                    {
                        pnl_Contenedor.Controls.RemoveAt(i);
                    }
                }

                Form Fchild = Formhijo as Form;
                Fchild.TopLevel = false;
                Fchild.Dock = DockStyle.Fill;
                this.pnl_Contenedor.Controls.Add(Fchild);
                this.pnl_Contenedor.Tag = Fchild;
                Fchild.Dock = DockStyle.Fill;
                Fchild.Show();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void BtnReporteEmpleados_Click(object sender, EventArgs e)
        {

        }

        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            GetPanel(new FrmUsuario());
        }

        private void FrmHome_Shown(object sender, EventArgs e)
        {
            LblNameCurrent.Text = CurrentSession.NombreCompleto;
            LblRolCurrent.Text = CurrentSession.NombreRol;
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            GetPanel(new FrmProveedor());
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            GetPanel(new FrmProducto());
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            GetPanel(new FrmCliente());
        }

        private void BtnCompra_Click(object sender, EventArgs e)
        {
            GetPanel(new FrmProductoCompra());
        }
    }
}
