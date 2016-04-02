namespace AdmTramasPLE
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mantenimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEstructura = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiArchivos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiErrores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiParametros = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoDeArchivoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mstiImpExp = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 525);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(971, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientosToolStripMenuItem,
            this.ingresoDeArchivoaToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mantenimientosToolStripMenuItem
            // 
            this.mantenimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEstructura,
            this.tsmiArchivos,
            this.tsmiErrores,
            this.tsmiParametros});
            this.mantenimientosToolStripMenuItem.Name = "mantenimientosToolStripMenuItem";
            this.mantenimientosToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.mantenimientosToolStripMenuItem.Text = "&Mantenimientos";
            // 
            // tsmiEstructura
            // 
            this.tsmiEstructura.Name = "tsmiEstructura";
            this.tsmiEstructura.Size = new System.Drawing.Size(152, 22);
            this.tsmiEstructura.Text = "Estructuras";
            this.tsmiEstructura.Click += new System.EventHandler(this.tsmiEstructura_Click);
            // 
            // tsmiArchivos
            // 
            this.tsmiArchivos.Name = "tsmiArchivos";
            this.tsmiArchivos.Size = new System.Drawing.Size(152, 22);
            this.tsmiArchivos.Text = "Archivos";
            this.tsmiArchivos.Click += new System.EventHandler(this.tsmiArchivos_Click);
            // 
            // tsmiErrores
            // 
            this.tsmiErrores.Name = "tsmiErrores";
            this.tsmiErrores.Size = new System.Drawing.Size(152, 22);
            this.tsmiErrores.Text = "Tipos de Error";
            this.tsmiErrores.Visible = false;
            // 
            // tsmiParametros
            // 
            this.tsmiParametros.Name = "tsmiParametros";
            this.tsmiParametros.Size = new System.Drawing.Size(152, 22);
            this.tsmiParametros.Text = "Parametros";
            this.tsmiParametros.Visible = false;
            // 
            // ingresoDeArchivoaToolStripMenuItem
            // 
            this.ingresoDeArchivoaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mstiImpExp});
            this.ingresoDeArchivoaToolStripMenuItem.Name = "ingresoDeArchivoaToolStripMenuItem";
            this.ingresoDeArchivoaToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.ingresoDeArchivoaToolStripMenuItem.Text = "&Archivos";
            // 
            // mstiImpExp
            // 
            this.mstiImpExp.Name = "mstiImpExp";
            this.mstiImpExp.Size = new System.Drawing.Size(155, 22);
            this.mstiImpExp.Text = "Import y Export";
            this.mstiImpExp.Click += new System.EventHandler(this.importYExportToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaTsmi});
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.acercaDeToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaTsmi
            // 
            this.acercaTsmi.Name = "acercaTsmi";
            this.acercaTsmi.Size = new System.Drawing.Size(132, 22);
            this.acercaTsmi.Text = "Acerca de..";
            this.acercaTsmi.Click += new System.EventHandler(this.acercaTsmi_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 547);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Administrador de Tramas - PLE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mantenimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresoDeArchivoaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaTsmi;
        private System.Windows.Forms.ToolStripMenuItem tsmiEstructura;
        private System.Windows.Forms.ToolStripMenuItem tsmiArchivos;
        private System.Windows.Forms.ToolStripMenuItem tsmiErrores;
        private System.Windows.Forms.ToolStripMenuItem tsmiParametros;
        private System.Windows.Forms.ToolStripMenuItem mstiImpExp;
    }
}

