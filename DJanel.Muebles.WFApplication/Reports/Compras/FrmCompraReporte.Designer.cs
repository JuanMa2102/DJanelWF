
namespace DJanel.Muebles.WFApplication.Reports.Compras
{
    partial class FrmCompraReporte
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelPersonalizado = new System.Windows.Forms.Panel();
            this.Generar = new System.Windows.Forms.Button();
            this.endDateControl = new System.Windows.Forms.DateTimePicker();
            this.startDateControl = new System.Windows.Forms.DateTimePicker();
            this.Custom = new System.Windows.Forms.Button();
            this.ThisYear = new System.Windows.Forms.Button();
            this.LastMonth = new System.Windows.Forms.Button();
            this.ThisMonth = new System.Windows.Forms.Button();
            this.LastWeek = new System.Windows.Forms.Button();
            this.Today = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.PanelPersonalizado.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.PanelPersonalizado);
            this.panel1.Controls.Add(this.Custom);
            this.panel1.Controls.Add(this.ThisYear);
            this.panel1.Controls.Add(this.LastMonth);
            this.panel1.Controls.Add(this.ThisMonth);
            this.panel1.Controls.Add(this.LastWeek);
            this.panel1.Controls.Add(this.Today);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 645);
            this.panel1.TabIndex = 0;
            // 
            // PanelPersonalizado
            // 
            this.PanelPersonalizado.Controls.Add(this.Generar);
            this.PanelPersonalizado.Controls.Add(this.endDateControl);
            this.PanelPersonalizado.Controls.Add(this.startDateControl);
            this.PanelPersonalizado.Location = new System.Drawing.Point(0, 421);
            this.PanelPersonalizado.Name = "PanelPersonalizado";
            this.PanelPersonalizado.Size = new System.Drawing.Size(262, 190);
            this.PanelPersonalizado.TabIndex = 9;
            this.PanelPersonalizado.Visible = false;
            // 
            // Generar
            // 
            this.Generar.FlatAppearance.BorderSize = 0;
            this.Generar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(164)))), ((int)(((byte)(232)))));
            this.Generar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Generar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Generar.Location = new System.Drawing.Point(0, 123);
            this.Generar.Name = "Generar";
            this.Generar.Size = new System.Drawing.Size(262, 50);
            this.Generar.TabIndex = 10;
            this.Generar.Text = "Generar ";
            this.Generar.UseVisualStyleBackColor = true;
            this.Generar.Click += new System.EventHandler(this.Generar_Click);
            this.Generar.MouseEnter += new System.EventHandler(this.Generar_MouseEnter);
            this.Generar.MouseLeave += new System.EventHandler(this.Generar_MouseLeave);
            // 
            // endDateControl
            // 
            this.endDateControl.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateControl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateControl.Location = new System.Drawing.Point(29, 59);
            this.endDateControl.Name = "endDateControl";
            this.endDateControl.Size = new System.Drawing.Size(200, 27);
            this.endDateControl.TabIndex = 1;
            // 
            // startDateControl
            // 
            this.startDateControl.CalendarFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateControl.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateControl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateControl.Location = new System.Drawing.Point(29, 14);
            this.startDateControl.Name = "startDateControl";
            this.startDateControl.Size = new System.Drawing.Size(200, 27);
            this.startDateControl.TabIndex = 0;
            // 
            // Custom
            // 
            this.Custom.FlatAppearance.BorderSize = 0;
            this.Custom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(164)))), ((int)(((byte)(232)))));
            this.Custom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Custom.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Custom.Location = new System.Drawing.Point(0, 365);
            this.Custom.Name = "Custom";
            this.Custom.Size = new System.Drawing.Size(262, 50);
            this.Custom.TabIndex = 8;
            this.Custom.Text = "Personalizado";
            this.Custom.UseVisualStyleBackColor = true;
            this.Custom.Click += new System.EventHandler(this.Custom_Click);
            this.Custom.MouseEnter += new System.EventHandler(this.Custom_MouseEnter);
            this.Custom.MouseLeave += new System.EventHandler(this.Custom_MouseLeave);
            // 
            // ThisYear
            // 
            this.ThisYear.FlatAppearance.BorderSize = 0;
            this.ThisYear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(164)))), ((int)(((byte)(232)))));
            this.ThisYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThisYear.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThisYear.Location = new System.Drawing.Point(0, 309);
            this.ThisYear.Name = "ThisYear";
            this.ThisYear.Size = new System.Drawing.Size(262, 50);
            this.ThisYear.TabIndex = 7;
            this.ThisYear.Text = "Este año";
            this.ThisYear.UseVisualStyleBackColor = true;
            this.ThisYear.Click += new System.EventHandler(this.ThisYear_Click);
            this.ThisYear.MouseEnter += new System.EventHandler(this.ThisYear_MouseEnter);
            this.ThisYear.MouseLeave += new System.EventHandler(this.ThisYear_MouseLeave);
            // 
            // LastMonth
            // 
            this.LastMonth.FlatAppearance.BorderSize = 0;
            this.LastMonth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(164)))), ((int)(((byte)(232)))));
            this.LastMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LastMonth.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastMonth.Location = new System.Drawing.Point(0, 253);
            this.LastMonth.Name = "LastMonth";
            this.LastMonth.Size = new System.Drawing.Size(262, 50);
            this.LastMonth.TabIndex = 6;
            this.LastMonth.Text = "Ultimos 30 días";
            this.LastMonth.UseVisualStyleBackColor = true;
            this.LastMonth.Click += new System.EventHandler(this.LastMonth_Click);
            this.LastMonth.MouseEnter += new System.EventHandler(this.LastMonth_MouseEnter);
            this.LastMonth.MouseLeave += new System.EventHandler(this.LastMonth_MouseLeave);
            // 
            // ThisMonth
            // 
            this.ThisMonth.FlatAppearance.BorderSize = 0;
            this.ThisMonth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(164)))), ((int)(((byte)(232)))));
            this.ThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThisMonth.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThisMonth.Location = new System.Drawing.Point(0, 197);
            this.ThisMonth.Name = "ThisMonth";
            this.ThisMonth.Size = new System.Drawing.Size(262, 50);
            this.ThisMonth.TabIndex = 5;
            this.ThisMonth.Text = "Este mes";
            this.ThisMonth.UseVisualStyleBackColor = true;
            this.ThisMonth.Click += new System.EventHandler(this.ThisMonth_Click);
            this.ThisMonth.MouseEnter += new System.EventHandler(this.ThisMonth_MouseEnter);
            this.ThisMonth.MouseLeave += new System.EventHandler(this.ThisMonth_MouseLeave);
            // 
            // LastWeek
            // 
            this.LastWeek.FlatAppearance.BorderSize = 0;
            this.LastWeek.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(164)))), ((int)(((byte)(232)))));
            this.LastWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LastWeek.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastWeek.Location = new System.Drawing.Point(0, 140);
            this.LastWeek.Name = "LastWeek";
            this.LastWeek.Size = new System.Drawing.Size(262, 50);
            this.LastWeek.TabIndex = 4;
            this.LastWeek.Text = "Ultimos 7 días";
            this.LastWeek.UseVisualStyleBackColor = true;
            this.LastWeek.Click += new System.EventHandler(this.button2_Click);
            this.LastWeek.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.LastWeek.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // Today
            // 
            this.Today.FlatAppearance.BorderSize = 0;
            this.Today.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(164)))), ((int)(((byte)(232)))));
            this.Today.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Today.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Today.Location = new System.Drawing.Point(0, 84);
            this.Today.Name = "Today";
            this.Today.Size = new System.Drawing.Size(262, 50);
            this.Today.TabIndex = 0;
            this.Today.Text = "Hoy";
            this.Today.UseVisualStyleBackColor = true;
            this.Today.Click += new System.EventHandler(this.Today_Click);
            this.Today.MouseEnter += new System.EventHandler(this.Today_MouseEnter);
            this.Today.MouseLeave += new System.EventHandler(this.Today_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(128)))), ((int)(((byte)(181)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 84);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(91, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "compras";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reporte de";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DJanel.Muebles.WFApplication.Reports.Ventas.VentaReporte.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(262, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(937, 645);
            this.reportViewer1.TabIndex = 1;
            // 
            // FrmCompraReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 645);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCompraReporte";
            this.Text = "FrmVentasReporte";
            this.Load += new System.EventHandler(this.FrmVentasReporte_Load);
            this.panel1.ResumeLayout(false);
            this.PanelPersonalizado.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Custom;
        private System.Windows.Forms.Button ThisYear;
        private System.Windows.Forms.Button LastMonth;
        private System.Windows.Forms.Button ThisMonth;
        private System.Windows.Forms.Button LastWeek;
        private System.Windows.Forms.Button Today;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelPersonalizado;
        private System.Windows.Forms.Button Generar;
        private System.Windows.Forms.DateTimePicker endDateControl;
        private System.Windows.Forms.DateTimePicker startDateControl;
    }
}