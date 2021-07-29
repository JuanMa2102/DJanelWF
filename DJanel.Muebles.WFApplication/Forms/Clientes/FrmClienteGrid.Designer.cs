
namespace DJanel.Muebles.WFApplication.Forms.Clientes
{
    partial class FrmClienteGrid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClienteGrid));
            this.Container = new System.Windows.Forms.Panel();
            this.Body = new System.Windows.Forms.Panel();
            this.DataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.Footer = new System.Windows.Forms.Panel();
            this.UsuarioFLButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BusquedaControl = new System.Windows.Forms.TextBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.Container.SuspendLayout();
            this.Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.Footer.SuspendLayout();
            this.UsuarioFLButtons.SuspendLayout();
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Container
            // 
            this.Container.Controls.Add(this.Body);
            this.Container.Controls.Add(this.Footer);
            this.Container.Controls.Add(this.Header);
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(0, 0);
            this.Container.Name = "Container";
            this.Container.Size = new System.Drawing.Size(898, 471);
            this.Container.TabIndex = 0;
            // 
            // Body
            // 
            this.Body.Controls.Add(this.DataGrid);
            this.Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Body.Location = new System.Drawing.Point(0, 55);
            this.Body.Name = "Body";
            this.Body.Size = new System.Drawing.Size(898, 362);
            this.Body.TabIndex = 2;
            // 
            // DataGrid
            // 
            this.DataGrid.AccessibleName = "Table";
            this.DataGrid.AllowEditing = false;
            this.DataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn1.AllowEditing = false;
            gridTextColumn1.HeaderText = "IdCliente";
            gridTextColumn1.MappingName = "IdCliente";
            gridTextColumn1.Visible = false;
            gridTextColumn2.AllowEditing = false;
            gridTextColumn2.AllowResizing = true;
            gridTextColumn2.HeaderText = "Nombre Completo";
            gridTextColumn2.MappingName = "NombreCompleto";
            gridTextColumn3.AllowEditing = false;
            gridTextColumn3.AllowResizing = true;
            gridTextColumn3.HeaderText = "Fecha de Nacimiento";
            gridTextColumn3.MappingName = "Fecha_Nac";
            gridTextColumn4.AllowEditing = false;
            gridTextColumn4.AllowResizing = true;
            gridTextColumn4.HeaderText = "Telefono";
            gridTextColumn4.MappingName = "Telefono";
            gridTextColumn5.AllowEditing = false;
            gridTextColumn5.HeaderText = "Domicilio ";
            gridTextColumn5.MappingName = "Domicilio";
            gridTextColumn6.AllowEditing = false;
            gridTextColumn6.HeaderText = "Apeliido Paterno";
            gridTextColumn6.MappingName = "Apellido_Pat";
            this.DataGrid.Columns.Add(gridTextColumn1);
            this.DataGrid.Columns.Add(gridTextColumn2);
            this.DataGrid.Columns.Add(gridTextColumn3);
            this.DataGrid.Columns.Add(gridTextColumn4);
            this.DataGrid.Columns.Add(gridTextColumn5);
            this.DataGrid.Columns.Add(gridTextColumn6);
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid.EditorSelectionBehavior = Syncfusion.WinForms.DataGrid.Enums.EditorSelectionBehavior.SelectAll;
            this.DataGrid.Location = new System.Drawing.Point(0, 0);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(898, 362);
            this.DataGrid.TabIndex = 1;
            this.DataGrid.Text = "sfDataGrid1";
            // 
            // Footer
            // 
            this.Footer.BackColor = System.Drawing.Color.White;
            this.Footer.Controls.Add(this.UsuarioFLButtons);
            this.Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Footer.Location = new System.Drawing.Point(0, 417);
            this.Footer.Name = "Footer";
            this.Footer.Size = new System.Drawing.Size(898, 54);
            this.Footer.TabIndex = 1;
            // 
            // UsuarioFLButtons
            // 
            this.UsuarioFLButtons.Controls.Add(this.BtnNuevo);
            this.UsuarioFLButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.UsuarioFLButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.UsuarioFLButtons.Location = new System.Drawing.Point(477, 0);
            this.UsuarioFLButtons.Name = "UsuarioFLButtons";
            this.UsuarioFLButtons.Padding = new System.Windows.Forms.Padding(5, 10, 0, 5);
            this.UsuarioFLButtons.Size = new System.Drawing.Size(421, 54);
            this.UsuarioFLButtons.TabIndex = 16;
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNuevo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.BtnNuevo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnNuevo.Location = new System.Drawing.Point(273, 13);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(140, 32);
            this.BtnNuevo.TabIndex = 15;
            this.BtnNuevo.Text = "Seleccionar";
            this.BtnNuevo.UseVisualStyleBackColor = false;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.Header.Controls.Add(this.panel7);
            this.Header.Controls.Add(this.pictureBox1);
            this.Header.Controls.Add(this.BusquedaControl);
            this.Header.Controls.Add(this.LblTitulo);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(898, 55);
            this.Header.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(640, 39);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(245, 2);
            this.panel7.TabIndex = 29;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DJanel.Muebles.WFApplication.Properties.Resources.BUSCAR;
            this.pictureBox1.Location = new System.Drawing.Point(860, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BusquedaControl
            // 
            this.BusquedaControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.BusquedaControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BusquedaControl.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusquedaControl.ForeColor = System.Drawing.Color.White;
            this.BusquedaControl.Location = new System.Drawing.Point(639, 20);
            this.BusquedaControl.MaxLength = 100;
            this.BusquedaControl.Name = "BusquedaControl";
            this.BusquedaControl.Size = new System.Drawing.Size(221, 16);
            this.BusquedaControl.TabIndex = 27;
            this.BusquedaControl.Text = "ASDAS";
            this.BusquedaControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BusquedaControl_KeyDown);
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(12, 17);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(89, 23);
            this.LblTitulo.TabIndex = 0;
            this.LblTitulo.Text = "Clientes";
            // 
            // FrmClienteGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 471);
            this.Controls.Add(this.Container);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmClienteGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProductosGrid";
            this.Shown += new System.EventHandler(this.FrmClienteGrid_Shown);
            this.Container.ResumeLayout(false);
            this.Body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.Footer.ResumeLayout(false);
            this.UsuarioFLButtons.ResumeLayout(false);
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Container;
        private System.Windows.Forms.Panel Body;
        private System.Windows.Forms.Panel Footer;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.FlowLayoutPanel UsuarioFLButtons;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox BusquedaControl;
        private System.Windows.Forms.Panel panel7;
        private Syncfusion.WinForms.DataGrid.SfDataGrid DataGrid;
    }
}