namespace AdmTramasPLE.Archivos
{
    partial class frmRegCompras
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLibro = new System.Windows.Forms.ComboBox();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.cmbOpe = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNroRuc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tcPrincipal = new System.Windows.Forms.TabControl();
            this.tpImport = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.txtRutaImport = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tpDetalleImport = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvDetalleImp = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtFechaCarga = new System.Windows.Forms.TextBox();
            this.txtNombreCarga = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tpExport = new System.Windows.Forms.TabPage();
            this.stExport = new System.Windows.Forms.StatusStrip();
            this.stlblExport = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblExport = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvErrores = new System.Windows.Forms.DataGridView();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.cmbMesGen = new System.Windows.Forms.ComboBox();
            this.txtArchivoOrig = new System.Windows.Forms.TextBox();
            this.txtAnioGen = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtRutaExport = new System.Windows.Forms.TextBox();
            this.btnRutaExp = new System.Windows.Forms.Button();
            this.tpDetalleExport = new System.Windows.Forms.TabPage();
            this.lstDetalleExport = new System.Windows.Forms.ListBox();
            this.label27 = new System.Windows.Forms.Label();
            this.bkgImport = new System.ComponentModel.BackgroundWorker();
            this.bkgExport = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.tcPrincipal.SuspendLayout();
            this.tpImport.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tpDetalleImport.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleImp)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tpExport.SuspendLayout();
            this.stExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tpDetalleExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbLibro);
            this.groupBox1.Controls.Add(this.cmbMoneda);
            this.groupBox1.Controls.Add(this.cmbOpe);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNroRuc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información General";
            // 
            // cmbLibro
            // 
            this.cmbLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLibro.FormattingEnabled = true;
            this.cmbLibro.Location = new System.Drawing.Point(178, 65);
            this.cmbLibro.Name = "cmbLibro";
            this.cmbLibro.Size = new System.Drawing.Size(166, 21);
            this.cmbLibro.TabIndex = 2;
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Location = new System.Drawing.Point(522, 65);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(166, 21);
            this.cmbMoneda.TabIndex = 2;
            // 
            // cmbOpe
            // 
            this.cmbOpe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOpe.FormattingEnabled = true;
            this.cmbOpe.Location = new System.Drawing.Point(522, 27);
            this.cmbOpe.Name = "cmbOpe";
            this.cmbOpe.Size = new System.Drawing.Size(166, 21);
            this.cmbOpe.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Contenido de Libro o Registro:";
            // 
            // txtNroRuc
            // 
            this.txtNroRuc.Location = new System.Drawing.Point(178, 27);
            this.txtNroRuc.MaxLength = 14;
            this.txtNroRuc.Name = "txtNroRuc";
            this.txtNroRuc.Size = new System.Drawing.Size(169, 22);
            this.txtNroRuc.TabIndex = 1;
            this.txtNroRuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroRuc_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Indicador de Moneda:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Indicador de Operaciones:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N° de RUC:";
            // 
            // tcPrincipal
            // 
            this.tcPrincipal.Controls.Add(this.tpImport);
            this.tcPrincipal.Controls.Add(this.tpDetalleImport);
            this.tcPrincipal.Controls.Add(this.tpExport);
            this.tcPrincipal.Controls.Add(this.tpDetalleExport);
            this.tcPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tcPrincipal.Name = "tcPrincipal";
            this.tcPrincipal.SelectedIndex = 0;
            this.tcPrincipal.Size = new System.Drawing.Size(1009, 618);
            this.tcPrincipal.TabIndex = 1;
            // 
            // tpImport
            // 
            this.tpImport.Controls.Add(this.statusStrip1);
            this.tpImport.Controls.Add(this.groupBox3);
            this.tpImport.Controls.Add(this.groupBox2);
            this.tpImport.Controls.Add(this.groupBox1);
            this.tpImport.Location = new System.Drawing.Point(4, 22);
            this.tpImport.Name = "tpImport";
            this.tpImport.Padding = new System.Windows.Forms.Padding(3);
            this.tpImport.Size = new System.Drawing.Size(1001, 592);
            this.tpImport.TabIndex = 0;
            this.tpImport.Text = "Import";
            this.tpImport.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(3, 567);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(995, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblStatus
            // 
            this.tslblStatus.Name = "tslblStatus";
            this.tslblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvCargas);
            this.groupBox3.Location = new System.Drawing.Point(8, 192);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(781, 392);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cargas";
            // 
            // dgvCargas
            // 
            this.dgvCargas.AllowUserToAddRows = false;
            this.dgvCargas.AllowUserToDeleteRows = false;
            this.dgvCargas.AllowUserToResizeRows = false;
            this.dgvCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCargas.Location = new System.Drawing.Point(3, 18);
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(775, 371);
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargas_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnCargar);
            this.groupBox2.Controls.Add(this.txtRutaImport);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Location = new System.Drawing.Point(6, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Carga de Archivo Input";
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(524, 30);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // txtRutaImport
            // 
            this.txtRutaImport.Location = new System.Drawing.Point(46, 32);
            this.txtRutaImport.Name = "txtRutaImport";
            this.txtRutaImport.Size = new System.Drawing.Size(472, 22);
            this.txtRutaImport.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(6, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tpDetalleImport
            // 
            this.tpDetalleImport.Controls.Add(this.toolStrip1);
            this.tpDetalleImport.Controls.Add(this.groupBox5);
            this.tpDetalleImport.Controls.Add(this.groupBox4);
            this.tpDetalleImport.Location = new System.Drawing.Point(4, 22);
            this.tpDetalleImport.Name = "tpDetalleImport";
            this.tpDetalleImport.Size = new System.Drawing.Size(1001, 592);
            this.tpDetalleImport.TabIndex = 2;
            this.tpDetalleImport.Text = "Principal";
            this.tpDetalleImport.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1001, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGuardar
            // 
            this.tsbGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardar.Image = global::AdmTramasPLE.Properties.Resources.page_save;
            this.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardar.Name = "tsbGuardar";
            this.tsbGuardar.Size = new System.Drawing.Size(23, 22);
            this.tsbGuardar.Text = "&Guardar";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.dgvDetalleImp);
            this.groupBox5.Location = new System.Drawing.Point(8, 124);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(985, 460);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalle:";
            // 
            // dgvDetalleImp
            // 
            this.dgvDetalleImp.AllowUserToAddRows = false;
            this.dgvDetalleImp.AllowUserToDeleteRows = false;
            this.dgvDetalleImp.AllowUserToOrderColumns = true;
            this.dgvDetalleImp.AllowUserToResizeColumns = false;
            this.dgvDetalleImp.AllowUserToResizeRows = false;
            this.dgvDetalleImp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleImp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleImp.Location = new System.Drawing.Point(3, 18);
            this.dgvDetalleImp.Name = "dgvDetalleImp";
            this.dgvDetalleImp.ReadOnly = true;
            this.dgvDetalleImp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleImp.Size = new System.Drawing.Size(979, 439);
            this.dgvDetalleImp.TabIndex = 0;
            this.dgvDetalleImp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleImp_CellClick);
            this.dgvDetalleImp.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleImp_RowEnter);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtFechaCarga);
            this.groupBox4.Controls.Add(this.txtNombreCarga);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(8, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(985, 90);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cabecera:";
            // 
            // txtFechaCarga
            // 
            this.txtFechaCarga.BackColor = System.Drawing.Color.White;
            this.txtFechaCarga.Location = new System.Drawing.Point(120, 54);
            this.txtFechaCarga.Name = "txtFechaCarga";
            this.txtFechaCarga.ReadOnly = true;
            this.txtFechaCarga.Size = new System.Drawing.Size(85, 22);
            this.txtFechaCarga.TabIndex = 3;
            // 
            // txtNombreCarga
            // 
            this.txtNombreCarga.BackColor = System.Drawing.Color.White;
            this.txtNombreCarga.Location = new System.Drawing.Point(120, 18);
            this.txtNombreCarga.Name = "txtNombreCarga";
            this.txtNombreCarga.ReadOnly = true;
            this.txtNombreCarga.Size = new System.Drawing.Size(327, 22);
            this.txtNombreCarga.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Fecha de Carga:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nombre de Archivo:";
            // 
            // tpExport
            // 
            this.tpExport.Controls.Add(this.stExport);
            this.tpExport.Controls.Add(this.dgvErrores);
            this.tpExport.Controls.Add(this.dgvHistorial);
            this.tpExport.Controls.Add(this.label28);
            this.tpExport.Controls.Add(this.label26);
            this.tpExport.Controls.Add(this.groupBox11);
            this.tpExport.Controls.Add(this.groupBox10);
            this.tpExport.Location = new System.Drawing.Point(4, 22);
            this.tpExport.Name = "tpExport";
            this.tpExport.Padding = new System.Windows.Forms.Padding(3);
            this.tpExport.Size = new System.Drawing.Size(1001, 592);
            this.tpExport.TabIndex = 1;
            this.tpExport.Text = "Export";
            this.tpExport.UseVisualStyleBackColor = true;
            // 
            // stExport
            // 
            this.stExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stlblExport,
            this.tslblExport});
            this.stExport.Location = new System.Drawing.Point(3, 567);
            this.stExport.Name = "stExport";
            this.stExport.Size = new System.Drawing.Size(995, 22);
            this.stExport.TabIndex = 8;
            this.stExport.Text = "statusStrip2";
            // 
            // stlblExport
            // 
            this.stlblExport.Name = "stlblExport";
            this.stlblExport.Size = new System.Drawing.Size(0, 17);
            // 
            // tslblExport
            // 
            this.tslblExport.Name = "tslblExport";
            this.tslblExport.Size = new System.Drawing.Size(0, 17);
            // 
            // dgvErrores
            // 
            this.dgvErrores.BackgroundColor = System.Drawing.Color.White;
            this.dgvErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrores.Location = new System.Drawing.Point(499, 175);
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.Size = new System.Drawing.Size(450, 389);
            this.dgvErrores.TabIndex = 7;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AllowUserToResizeColumns = false;
            this.dgvHistorial.AllowUserToResizeRows = false;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(6, 175);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(487, 389);
            this.dgvHistorial.TabIndex = 6;
            this.dgvHistorial.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorial_CellDoubleClick);
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Silver;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(499, 147);
            this.label28.Name = "label28";
            this.label28.Padding = new System.Windows.Forms.Padding(5);
            this.label28.Size = new System.Drawing.Size(450, 25);
            this.label28.TabIndex = 4;
            this.label28.Text = "Detalle de Errores:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Silver;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(6, 147);
            this.label26.Name = "label26";
            this.label26.Padding = new System.Windows.Forms.Padding(5);
            this.label26.Size = new System.Drawing.Size(487, 25);
            this.label26.TabIndex = 3;
            this.label26.Text = "Historial de Cargas:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnGenerar);
            this.groupBox11.Controls.Add(this.cmbMesGen);
            this.groupBox11.Controls.Add(this.txtArchivoOrig);
            this.groupBox11.Controls.Add(this.txtAnioGen);
            this.groupBox11.Controls.Add(this.label24);
            this.groupBox11.Controls.Add(this.label29);
            this.groupBox11.Controls.Add(this.label23);
            this.groupBox11.Location = new System.Drawing.Point(6, 71);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(943, 73);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Periodo a Generar";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(294, 30);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // cmbMesGen
            // 
            this.cmbMesGen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesGen.FormattingEnabled = true;
            this.cmbMesGen.Location = new System.Drawing.Point(146, 30);
            this.cmbMesGen.Name = "cmbMesGen";
            this.cmbMesGen.Size = new System.Drawing.Size(142, 21);
            this.cmbMesGen.TabIndex = 2;
            // 
            // txtArchivoOrig
            // 
            this.txtArchivoOrig.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArchivoOrig.Location = new System.Drawing.Point(483, 30);
            this.txtArchivoOrig.Name = "txtArchivoOrig";
            this.txtArchivoOrig.ReadOnly = true;
            this.txtArchivoOrig.Size = new System.Drawing.Size(356, 22);
            this.txtArchivoOrig.TabIndex = 2;
            // 
            // txtAnioGen
            // 
            this.txtAnioGen.Location = new System.Drawing.Point(43, 30);
            this.txtAnioGen.MaxLength = 4;
            this.txtAnioGen.Name = "txtAnioGen";
            this.txtAnioGen.Size = new System.Drawing.Size(60, 22);
            this.txtAnioGen.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(109, 30);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(31, 13);
            this.label24.TabIndex = 2;
            this.label24.Text = "Mes:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(390, 30);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(87, 13);
            this.label29.TabIndex = 2;
            this.label29.Text = "Archivo Origen:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 30);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "Año:";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtRutaExport);
            this.groupBox10.Controls.Add(this.btnRutaExp);
            this.groupBox10.Location = new System.Drawing.Point(6, 6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(943, 59);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Ruta";
            // 
            // txtRutaExport
            // 
            this.txtRutaExport.BackColor = System.Drawing.Color.White;
            this.txtRutaExport.Location = new System.Drawing.Point(55, 22);
            this.txtRutaExport.Name = "txtRutaExport";
            this.txtRutaExport.ReadOnly = true;
            this.txtRutaExport.Size = new System.Drawing.Size(501, 22);
            this.txtRutaExport.TabIndex = 1;
            // 
            // btnRutaExp
            // 
            this.btnRutaExp.Location = new System.Drawing.Point(6, 21);
            this.btnRutaExp.Name = "btnRutaExp";
            this.btnRutaExp.Size = new System.Drawing.Size(43, 23);
            this.btnRutaExp.TabIndex = 1;
            this.btnRutaExp.Text = "...";
            this.btnRutaExp.UseVisualStyleBackColor = true;
            this.btnRutaExp.Click += new System.EventHandler(this.btnRutaExp_Click);
            // 
            // tpDetalleExport
            // 
            this.tpDetalleExport.Controls.Add(this.lstDetalleExport);
            this.tpDetalleExport.Controls.Add(this.label27);
            this.tpDetalleExport.Location = new System.Drawing.Point(4, 22);
            this.tpDetalleExport.Name = "tpDetalleExport";
            this.tpDetalleExport.Size = new System.Drawing.Size(1001, 592);
            this.tpDetalleExport.TabIndex = 3;
            this.tpDetalleExport.Text = "Detalle Export";
            this.tpDetalleExport.UseVisualStyleBackColor = true;
            // 
            // lstDetalleExport
            // 
            this.lstDetalleExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDetalleExport.FormattingEnabled = true;
            this.lstDetalleExport.HorizontalScrollbar = true;
            this.lstDetalleExport.Location = new System.Drawing.Point(8, 37);
            this.lstDetalleExport.Name = "lstDetalleExport";
            this.lstDetalleExport.Size = new System.Drawing.Size(832, 550);
            this.lstDetalleExport.TabIndex = 5;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Silver;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(8, 9);
            this.label27.Name = "label27";
            this.label27.Padding = new System.Windows.Forms.Padding(5);
            this.label27.Size = new System.Drawing.Size(832, 25);
            this.label27.TabIndex = 4;
            this.label27.Text = "DETALLE DEL ARCHIVO:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bkgImport
            // 
            this.bkgImport.WorkerReportsProgress = true;
            this.bkgImport.WorkerSupportsCancellation = true;
            this.bkgImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgImport_DoWork);
            this.bkgImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgImport_RunWorkerCompleted);
            // 
            // bkgExport
            // 
            this.bkgExport.WorkerReportsProgress = true;
            this.bkgExport.WorkerSupportsCancellation = true;
            this.bkgExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgExport_DoWork);
            this.bkgExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgExport_RunWorkerCompleted);
            // 
            // frmRegCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1009, 618);
            this.Controls.Add(this.tcPrincipal);
            this.Name = "frmRegCompras";
            this.Text = "Registro de Compras";
            this.Load += new System.EventHandler(this.frmRegVentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tcPrincipal.ResumeLayout(false);
            this.tpImport.ResumeLayout(false);
            this.tpImport.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tpDetalleImport.ResumeLayout(false);
            this.tpDetalleImport.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleImp)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tpExport.ResumeLayout(false);
            this.tpExport.PerformLayout();
            this.stExport.ResumeLayout(false);
            this.stExport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.tpDetalleExport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNroRuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLibro;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.ComboBox cmbOpe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tcPrincipal;
        private System.Windows.Forms.TabPage tpImport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.TextBox txtRutaImport;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TabPage tpDetalleImport;
        private System.Windows.Forms.TabPage tpExport;
        private System.Windows.Forms.TabPage tpDetalleExport;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtNombreCarga;
        private System.Windows.Forms.DataGridView dgvDetalleImp;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox txtRutaExport;
        private System.Windows.Forms.Button btnRutaExp;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.ComboBox cmbMesGen;
        private System.Windows.Forms.TextBox txtAnioGen;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ListBox lstDetalleExport;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.TextBox txtFechaCarga;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGuardar;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtArchivoOrig;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridView dgvErrores;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker bkgImport;
        private System.ComponentModel.BackgroundWorker bkgExport;
        private System.Windows.Forms.ToolStripStatusLabel tslblStatus;
        private System.Windows.Forms.StatusStrip stExport;
        private System.Windows.Forms.ToolStripStatusLabel stlblExport;
        private System.Windows.Forms.ToolStripStatusLabel tslblExport;
    }
}
