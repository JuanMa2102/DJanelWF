
namespace DJanel.Muebles.WFApplication.Forms.Clientes
{
    partial class FrmCliente
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
            this.components = new System.ComponentModel.Container();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.UsuarioFLButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.UsuarioACPanel = new System.Windows.Forms.Panel();
            this.GBoxFormulario = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DomicilioControl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.Apellido_PatControl = new System.Windows.Forms.TextBox();
            this.NombreControl = new System.Windows.Forms.TextBox();
            this.Apellido_MatControl = new System.Windows.Forms.TextBox();
            this.UsuarioGridPanel = new System.Windows.Forms.Panel();
            this.UsuarioConteiner = new System.Windows.Forms.Panel();
            this.UsuarioContainerGrid = new System.Windows.Forms.Panel();
            this.DataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.UsuarioContainerAC = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fecha_NacControl = new System.Windows.Forms.DateTimePicker();
            this.TelefonoControl = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            this.UsuarioFLButtons.SuspendLayout();
            this.UsuarioACPanel.SuspendLayout();
            this.GBoxFormulario.SuspendLayout();
            this.UsuarioGridPanel.SuspendLayout();
            this.UsuarioConteiner.SuspendLayout();
            this.UsuarioContainerGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.UsuarioContainerAC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.UsuarioFLButtons);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 732);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1300, 48);
            this.panel4.TabIndex = 18;
            // 
            // UsuarioFLButtons
            // 
            this.UsuarioFLButtons.Controls.Add(this.BtnNuevo);
            this.UsuarioFLButtons.Controls.Add(this.BtnModificar);
            this.UsuarioFLButtons.Controls.Add(this.BtnEliminar);
            this.UsuarioFLButtons.Controls.Add(this.BtnGuardar);
            this.UsuarioFLButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.UsuarioFLButtons.Location = new System.Drawing.Point(879, 0);
            this.UsuarioFLButtons.Name = "UsuarioFLButtons";
            this.UsuarioFLButtons.Padding = new System.Windows.Forms.Padding(5, 10, 0, 5);
            this.UsuarioFLButtons.Size = new System.Drawing.Size(421, 48);
            this.UsuarioFLButtons.TabIndex = 15;
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNuevo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.BtnNuevo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnNuevo.Location = new System.Drawing.Point(8, 13);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(93, 32);
            this.BtnNuevo.TabIndex = 15;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = false;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.OrangeRed;
            this.BtnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.BtnModificar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnModificar.Location = new System.Drawing.Point(107, 13);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(103, 32);
            this.BtnModificar.TabIndex = 14;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.Red;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.BtnEliminar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnEliminar.Location = new System.Drawing.Point(216, 13);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(92, 32);
            this.BtnEliminar.TabIndex = 13;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.BtnGuardar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnGuardar.Location = new System.Drawing.Point(314, 13);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(93, 32);
            this.BtnGuardar.TabIndex = 12;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // UsuarioACPanel
            // 
            this.UsuarioACPanel.Controls.Add(this.GBoxFormulario);
            this.UsuarioACPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.UsuarioACPanel.Location = new System.Drawing.Point(0, 0);
            this.UsuarioACPanel.Name = "UsuarioACPanel";
            this.UsuarioACPanel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.UsuarioACPanel.Size = new System.Drawing.Size(669, 732);
            this.UsuarioACPanel.TabIndex = 20;
            // 
            // GBoxFormulario
            // 
            this.GBoxFormulario.Controls.Add(this.panel5);
            this.GBoxFormulario.Controls.Add(this.TelefonoControl);
            this.GBoxFormulario.Controls.Add(this.Fecha_NacControl);
            this.GBoxFormulario.Controls.Add(this.label3);
            this.GBoxFormulario.Controls.Add(this.panel3);
            this.GBoxFormulario.Controls.Add(this.DomicilioControl);
            this.GBoxFormulario.Controls.Add(this.label1);
            this.GBoxFormulario.Controls.Add(this.panel1);
            this.GBoxFormulario.Controls.Add(this.panel2);
            this.GBoxFormulario.Controls.Add(this.label7);
            this.GBoxFormulario.Controls.Add(this.label2);
            this.GBoxFormulario.Controls.Add(this.panel7);
            this.GBoxFormulario.Controls.Add(this.label4);
            this.GBoxFormulario.Controls.Add(this.label5);
            this.GBoxFormulario.Controls.Add(this.panel8);
            this.GBoxFormulario.Controls.Add(this.Apellido_PatControl);
            this.GBoxFormulario.Controls.Add(this.NombreControl);
            this.GBoxFormulario.Controls.Add(this.Apellido_MatControl);
            this.GBoxFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GBoxFormulario.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.GBoxFormulario.Location = new System.Drawing.Point(10, 0);
            this.GBoxFormulario.Name = "GBoxFormulario";
            this.GBoxFormulario.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.GBoxFormulario.Size = new System.Drawing.Size(649, 722);
            this.GBoxFormulario.TabIndex = 40;
            this.GBoxFormulario.TabStop = false;
            this.GBoxFormulario.Text = "Nuevo Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(28, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Domicilio";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel3.Location = new System.Drawing.Point(35, 382);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(570, 2);
            this.panel3.TabIndex = 38;
            // 
            // DomicilioControl
            // 
            this.DomicilioControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DomicilioControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.DomicilioControl.ForeColor = System.Drawing.Color.Black;
            this.DomicilioControl.Location = new System.Drawing.Point(43, 359);
            this.DomicilioControl.MaxLength = 100;
            this.DomicilioControl.Multiline = true;
            this.DomicilioControl.Name = "DomicilioControl";
            this.DomicilioControl.Size = new System.Drawing.Size(574, 27);
            this.DomicilioControl.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(373, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "Fecha de Nacimiento";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel1.Location = new System.Drawing.Point(377, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 2);
            this.panel1.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel2.Location = new System.Drawing.Point(31, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 2);
            this.panel2.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(373, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "Telefono";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(27, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel7.Location = new System.Drawing.Point(32, 192);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(229, 2);
            this.panel7.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(28, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Apellido Paterno";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(27, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Apellido Materno";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel8.Location = new System.Drawing.Point(35, 289);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(229, 2);
            this.panel8.TabIndex = 21;
            // 
            // Apellido_PatControl
            // 
            this.Apellido_PatControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Apellido_PatControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.Apellido_PatControl.ForeColor = System.Drawing.Color.Black;
            this.Apellido_PatControl.Location = new System.Drawing.Point(40, 169);
            this.Apellido_PatControl.MaxLength = 100;
            this.Apellido_PatControl.Multiline = true;
            this.Apellido_PatControl.Name = "Apellido_PatControl";
            this.Apellido_PatControl.Size = new System.Drawing.Size(221, 27);
            this.Apellido_PatControl.TabIndex = 17;
            // 
            // NombreControl
            // 
            this.NombreControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NombreControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.NombreControl.ForeColor = System.Drawing.Color.Black;
            this.NombreControl.Location = new System.Drawing.Point(39, 77);
            this.NombreControl.MaxLength = 100;
            this.NombreControl.Multiline = true;
            this.NombreControl.Name = "NombreControl";
            this.NombreControl.Size = new System.Drawing.Size(221, 27);
            this.NombreControl.TabIndex = 10;
            // 
            // Apellido_MatControl
            // 
            this.Apellido_MatControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Apellido_MatControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.Apellido_MatControl.ForeColor = System.Drawing.Color.Black;
            this.Apellido_MatControl.Location = new System.Drawing.Point(43, 266);
            this.Apellido_MatControl.MaxLength = 100;
            this.Apellido_MatControl.Multiline = true;
            this.Apellido_MatControl.Name = "Apellido_MatControl";
            this.Apellido_MatControl.Size = new System.Drawing.Size(221, 27);
            this.Apellido_MatControl.TabIndex = 20;
            // 
            // UsuarioGridPanel
            // 
            this.UsuarioGridPanel.Controls.Add(this.UsuarioConteiner);
            this.UsuarioGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsuarioGridPanel.Location = new System.Drawing.Point(0, 0);
            this.UsuarioGridPanel.Name = "UsuarioGridPanel";
            this.UsuarioGridPanel.Size = new System.Drawing.Size(1300, 732);
            this.UsuarioGridPanel.TabIndex = 21;
            // 
            // UsuarioConteiner
            // 
            this.UsuarioConteiner.AutoSize = true;
            this.UsuarioConteiner.Controls.Add(this.UsuarioContainerGrid);
            this.UsuarioConteiner.Controls.Add(this.UsuarioContainerAC);
            this.UsuarioConteiner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsuarioConteiner.Location = new System.Drawing.Point(0, 0);
            this.UsuarioConteiner.Name = "UsuarioConteiner";
            this.UsuarioConteiner.Size = new System.Drawing.Size(1300, 732);
            this.UsuarioConteiner.TabIndex = 1;
            // 
            // UsuarioContainerGrid
            // 
            this.UsuarioContainerGrid.Controls.Add(this.DataGrid);
            this.UsuarioContainerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsuarioContainerGrid.Location = new System.Drawing.Point(0, 0);
            this.UsuarioContainerGrid.Name = "UsuarioContainerGrid";
            this.UsuarioContainerGrid.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.UsuarioContainerGrid.Size = new System.Drawing.Size(631, 732);
            this.UsuarioContainerGrid.TabIndex = 1;
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
            gridTextColumn2.MappingName = "Nombre";
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
            this.DataGrid.Columns.Add(gridTextColumn1);
            this.DataGrid.Columns.Add(gridTextColumn2);
            this.DataGrid.Columns.Add(gridTextColumn3);
            this.DataGrid.Columns.Add(gridTextColumn4);
            this.DataGrid.Columns.Add(gridTextColumn5);
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid.EditorSelectionBehavior = Syncfusion.WinForms.DataGrid.Enums.EditorSelectionBehavior.SelectAll;
            this.DataGrid.Location = new System.Drawing.Point(0, 10);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(621, 712);
            this.DataGrid.TabIndex = 0;
            this.DataGrid.Text = "sfDataGrid1";
            // 
            // UsuarioContainerAC
            // 
            this.UsuarioContainerAC.Controls.Add(this.UsuarioACPanel);
            this.UsuarioContainerAC.Dock = System.Windows.Forms.DockStyle.Right;
            this.UsuarioContainerAC.Location = new System.Drawing.Point(631, 0);
            this.UsuarioContainerAC.Name = "UsuarioContainerAC";
            this.UsuarioContainerAC.Size = new System.Drawing.Size(669, 732);
            this.UsuarioContainerAC.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 50;
            this.errorProvider.ContainerControl = this;
            // 
            // Fecha_NacControl
            // 
            this.Fecha_NacControl.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.Fecha_NacControl.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Fecha_NacControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.Fecha_NacControl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha_NacControl.Location = new System.Drawing.Point(377, 76);
            this.Fecha_NacControl.Name = "Fecha_NacControl";
            this.Fecha_NacControl.Size = new System.Drawing.Size(230, 24);
            this.Fecha_NacControl.TabIndex = 40;
            this.Fecha_NacControl.Value = new System.DateTime(2021, 7, 12, 0, 0, 0, 0);
            // 
            // TelefonoControl
            // 
            this.TelefonoControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TelefonoControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.TelefonoControl.ForeColor = System.Drawing.Color.Black;
            this.TelefonoControl.Location = new System.Drawing.Point(386, 169);
            this.TelefonoControl.MaxLength = 10;
            this.TelefonoControl.Multiline = true;
            this.TelefonoControl.Name = "TelefonoControl";
            this.TelefonoControl.Size = new System.Drawing.Size(221, 27);
            this.TelefonoControl.TabIndex = 41;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel5.Location = new System.Drawing.Point(378, 192);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(229, 2);
            this.panel5.TabIndex = 19;
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 780);
            this.Controls.Add(this.UsuarioGridPanel);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCliente";
            this.Text = "Usuario";
            this.Shown += new System.EventHandler(this.FrmCliente_Shown);
            this.panel4.ResumeLayout(false);
            this.UsuarioFLButtons.ResumeLayout(false);
            this.UsuarioACPanel.ResumeLayout(false);
            this.GBoxFormulario.ResumeLayout(false);
            this.GBoxFormulario.PerformLayout();
            this.UsuarioGridPanel.ResumeLayout(false);
            this.UsuarioGridPanel.PerformLayout();
            this.UsuarioConteiner.ResumeLayout(false);
            this.UsuarioContainerGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.UsuarioContainerAC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel UsuarioACPanel;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Panel UsuarioGridPanel;
        private System.Windows.Forms.Panel UsuarioConteiner;
        private System.Windows.Forms.Panel UsuarioContainerGrid;
        private System.Windows.Forms.Panel UsuarioContainerAC;
        private System.Windows.Forms.FlowLayoutPanel UsuarioFLButtons;
        private Syncfusion.WinForms.DataGrid.SfDataGrid DataGrid;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox GBoxFormulario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox Apellido_PatControl;
        private System.Windows.Forms.TextBox NombreControl;
        private System.Windows.Forms.TextBox Apellido_MatControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox DomicilioControl;
        private System.Windows.Forms.DateTimePicker Fecha_NacControl;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox TelefonoControl;
    }
}