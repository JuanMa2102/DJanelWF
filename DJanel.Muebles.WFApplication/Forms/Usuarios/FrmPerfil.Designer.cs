
namespace DJanel.Muebles.WFApplication.Forms.Usuarios
{
    partial class FrmPerfil
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.UsuarioFLButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.UsuarioGridPanel = new System.Windows.Forms.Panel();
            this.UsuarioConteiner = new System.Windows.Forms.Panel();
            this.errorProviderUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.UsuarioACPanel = new System.Windows.Forms.Panel();
            this.GBUsuario = new System.Windows.Forms.GroupBox();
            this.UsernameControl = new System.Windows.Forms.TextBox();
            this.Apellido_MatControl = new System.Windows.Forms.TextBox();
            this.NombreControl = new System.Windows.Forms.TextBox();
            this.Apellido_PatControl = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.TelefonoControl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.DomicilioControl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PanelPassword = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PasswordControl = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.PasswordDosControl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PasswordEnable = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            this.UsuarioFLButtons.SuspendLayout();
            this.UsuarioGridPanel.SuspendLayout();
            this.UsuarioConteiner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUsuario)).BeginInit();
            this.UsuarioACPanel.SuspendLayout();
            this.GBUsuario.SuspendLayout();
            this.panel3.SuspendLayout();
            this.PanelPassword.SuspendLayout();
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
            this.UsuarioFLButtons.Controls.Add(this.BtnGuardar);
            this.UsuarioFLButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.UsuarioFLButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.UsuarioFLButtons.Location = new System.Drawing.Point(879, 0);
            this.UsuarioFLButtons.Name = "UsuarioFLButtons";
            this.UsuarioFLButtons.Padding = new System.Windows.Forms.Padding(5, 10, 0, 5);
            this.UsuarioFLButtons.Size = new System.Drawing.Size(421, 48);
            this.UsuarioFLButtons.TabIndex = 15;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.BtnGuardar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnGuardar.Location = new System.Drawing.Point(320, 13);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(93, 32);
            this.BtnGuardar.TabIndex = 12;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
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
            this.UsuarioConteiner.Controls.Add(this.UsuarioACPanel);
            this.UsuarioConteiner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsuarioConteiner.Location = new System.Drawing.Point(0, 0);
            this.UsuarioConteiner.Name = "UsuarioConteiner";
            this.UsuarioConteiner.Size = new System.Drawing.Size(1300, 732);
            this.UsuarioConteiner.TabIndex = 1;
            // 
            // errorProviderUsuario
            // 
            this.errorProviderUsuario.BlinkRate = 50;
            this.errorProviderUsuario.ContainerControl = this;
            // 
            // UsuarioACPanel
            // 
            this.UsuarioACPanel.Controls.Add(this.GBUsuario);
            this.UsuarioACPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsuarioACPanel.Location = new System.Drawing.Point(0, 0);
            this.UsuarioACPanel.Name = "UsuarioACPanel";
            this.UsuarioACPanel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.UsuarioACPanel.Size = new System.Drawing.Size(1300, 732);
            this.UsuarioACPanel.TabIndex = 20;
            // 
            // GBUsuario
            // 
            this.GBUsuario.Controls.Add(this.PasswordEnable);
            this.GBUsuario.Controls.Add(this.PanelPassword);
            this.GBUsuario.Controls.Add(this.panel3);
            this.GBUsuario.Controls.Add(this.panel2);
            this.GBUsuario.Controls.Add(this.label7);
            this.GBUsuario.Controls.Add(this.label2);
            this.GBUsuario.Controls.Add(this.panel10);
            this.GBUsuario.Controls.Add(this.label3);
            this.GBUsuario.Controls.Add(this.DomicilioControl);
            this.GBUsuario.Controls.Add(this.label6);
            this.GBUsuario.Controls.Add(this.panel7);
            this.GBUsuario.Controls.Add(this.panel9);
            this.GBUsuario.Controls.Add(this.label4);
            this.GBUsuario.Controls.Add(this.TelefonoControl);
            this.GBUsuario.Controls.Add(this.label5);
            this.GBUsuario.Controls.Add(this.panel8);
            this.GBUsuario.Controls.Add(this.Apellido_PatControl);
            this.GBUsuario.Controls.Add(this.NombreControl);
            this.GBUsuario.Controls.Add(this.Apellido_MatControl);
            this.GBUsuario.Controls.Add(this.UsernameControl);
            this.GBUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GBUsuario.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.GBUsuario.Location = new System.Drawing.Point(10, 0);
            this.GBUsuario.Name = "GBUsuario";
            this.GBUsuario.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.GBUsuario.Size = new System.Drawing.Size(1280, 722);
            this.GBUsuario.TabIndex = 39;
            this.GBUsuario.TabStop = false;
            this.GBUsuario.Text = "Modificar Contraseña";
            // 
            // UsernameControl
            // 
            this.UsernameControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.UsernameControl.ForeColor = System.Drawing.Color.Black;
            this.UsernameControl.Location = new System.Drawing.Point(379, 77);
            this.UsernameControl.MaxLength = 100;
            this.UsernameControl.Multiline = true;
            this.UsernameControl.Name = "UsernameControl";
            this.UsernameControl.Size = new System.Drawing.Size(221, 27);
            this.UsernameControl.TabIndex = 32;
            // 
            // Apellido_MatControl
            // 
            this.Apellido_MatControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Apellido_MatControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.Apellido_MatControl.ForeColor = System.Drawing.Color.Black;
            this.Apellido_MatControl.Location = new System.Drawing.Point(40, 236);
            this.Apellido_MatControl.MaxLength = 100;
            this.Apellido_MatControl.Multiline = true;
            this.Apellido_MatControl.Name = "Apellido_MatControl";
            this.Apellido_MatControl.Size = new System.Drawing.Size(221, 27);
            this.Apellido_MatControl.TabIndex = 20;
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
            // Apellido_PatControl
            // 
            this.Apellido_PatControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Apellido_PatControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.Apellido_PatControl.ForeColor = System.Drawing.Color.Black;
            this.Apellido_PatControl.Location = new System.Drawing.Point(39, 155);
            this.Apellido_PatControl.MaxLength = 100;
            this.Apellido_PatControl.Multiline = true;
            this.Apellido_PatControl.Name = "Apellido_PatControl";
            this.Apellido_PatControl.Size = new System.Drawing.Size(221, 27);
            this.Apellido_PatControl.TabIndex = 17;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel8.Location = new System.Drawing.Point(32, 259);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(229, 2);
            this.panel8.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(28, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Apellido Materno";
            // 
            // TelefonoControl
            // 
            this.TelefonoControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TelefonoControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.TelefonoControl.ForeColor = System.Drawing.Color.Black;
            this.TelefonoControl.Location = new System.Drawing.Point(39, 315);
            this.TelefonoControl.MaxLength = 100;
            this.TelefonoControl.Multiline = true;
            this.TelefonoControl.Name = "TelefonoControl";
            this.TelefonoControl.Size = new System.Drawing.Size(221, 27);
            this.TelefonoControl.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(27, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Apellido Paterno";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel9.Location = new System.Drawing.Point(31, 338);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(229, 2);
            this.panel9.TabIndex = 24;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel7.Location = new System.Drawing.Point(31, 178);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(229, 2);
            this.panel7.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(27, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Telefono";
            // 
            // DomicilioControl
            // 
            this.DomicilioControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DomicilioControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.DomicilioControl.ForeColor = System.Drawing.Color.Black;
            this.DomicilioControl.Location = new System.Drawing.Point(41, 407);
            this.DomicilioControl.MaxLength = 100;
            this.DomicilioControl.Multiline = true;
            this.DomicilioControl.Name = "DomicilioControl";
            this.DomicilioControl.Size = new System.Drawing.Size(574, 27);
            this.DomicilioControl.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(367, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nombre de usuario";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel10.Location = new System.Drawing.Point(33, 430);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(570, 2);
            this.panel10.TabIndex = 27;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(29, 385);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "Domicilio";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel2.Location = new System.Drawing.Point(31, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 2);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(371, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(229, 2);
            this.panel3.TabIndex = 14;
            // 
            // PanelPassword
            // 
            this.PanelPassword.Controls.Add(this.label8);
            this.PanelPassword.Controls.Add(this.PasswordDosControl);
            this.PanelPassword.Controls.Add(this.panel11);
            this.PanelPassword.Controls.Add(this.label10);
            this.PanelPassword.Controls.Add(this.PasswordControl);
            this.PanelPassword.Controls.Add(this.panel1);
            this.PanelPassword.Location = new System.Drawing.Point(352, 188);
            this.PanelPassword.Name = "PanelPassword";
            this.PanelPassword.Size = new System.Drawing.Size(291, 192);
            this.PanelPassword.TabIndex = 38;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel1.Location = new System.Drawing.Point(19, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 2);
            this.panel1.TabIndex = 36;
            // 
            // PasswordControl
            // 
            this.PasswordControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.PasswordControl.ForeColor = System.Drawing.Color.Black;
            this.PasswordControl.Location = new System.Drawing.Point(28, 46);
            this.PasswordControl.MaxLength = 50;
            this.PasswordControl.Name = "PasswordControl";
            this.PasswordControl.Size = new System.Drawing.Size(221, 17);
            this.PasswordControl.TabIndex = 29;
            this.PasswordControl.UseSystemPasswordChar = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(15, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 16);
            this.label10.TabIndex = 37;
            this.label10.Text = "Ingrese de nuevo la contraseña";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel11.Location = new System.Drawing.Point(19, 66);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(229, 2);
            this.panel11.TabIndex = 30;
            // 
            // PasswordDosControl
            // 
            this.PasswordDosControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordDosControl.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.PasswordDosControl.ForeColor = System.Drawing.Color.Black;
            this.PasswordDosControl.Location = new System.Drawing.Point(28, 128);
            this.PasswordDosControl.MaxLength = 50;
            this.PasswordDosControl.Name = "PasswordDosControl";
            this.PasswordDosControl.Size = new System.Drawing.Size(221, 17);
            this.PasswordDosControl.TabIndex = 35;
            this.PasswordDosControl.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(15, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 16);
            this.label8.TabIndex = 31;
            this.label8.Text = "Contraseña";
            // 
            // PasswordEnable
            // 
            this.PasswordEnable.AutoSize = true;
            this.PasswordEnable.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.PasswordEnable.Location = new System.Drawing.Point(370, 160);
            this.PasswordEnable.Name = "PasswordEnable";
            this.PasswordEnable.Size = new System.Drawing.Size(153, 20);
            this.PasswordEnable.TabIndex = 39;
            this.PasswordEnable.Text = "Modificar Contraseña";
            this.PasswordEnable.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(229, 2);
            this.panel5.TabIndex = 15;
            // 
            // FrmPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 780);
            this.Controls.Add(this.UsuarioGridPanel);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPerfil";
            this.Text = "Usuario";
            this.Shown += new System.EventHandler(this.FrmPerfil_Shown);
            this.panel4.ResumeLayout(false);
            this.UsuarioFLButtons.ResumeLayout(false);
            this.UsuarioGridPanel.ResumeLayout(false);
            this.UsuarioGridPanel.PerformLayout();
            this.UsuarioConteiner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUsuario)).EndInit();
            this.UsuarioACPanel.ResumeLayout(false);
            this.GBUsuario.ResumeLayout(false);
            this.GBUsuario.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.PanelPassword.ResumeLayout(false);
            this.PanelPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel UsuarioGridPanel;
        private System.Windows.Forms.Panel UsuarioConteiner;
        private System.Windows.Forms.FlowLayoutPanel UsuarioFLButtons;
        private System.Windows.Forms.ErrorProvider errorProviderUsuario;
        private System.Windows.Forms.Panel UsuarioACPanel;
        private System.Windows.Forms.GroupBox GBUsuario;
        private System.Windows.Forms.CheckBox PasswordEnable;
        private System.Windows.Forms.Panel PanelPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PasswordDosControl;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PasswordControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DomicilioControl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TelefonoControl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox Apellido_PatControl;
        private System.Windows.Forms.TextBox NombreControl;
        private System.Windows.Forms.TextBox Apellido_MatControl;
        private System.Windows.Forms.TextBox UsernameControl;
    }
}