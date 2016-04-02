namespace AdmTramasPLE.Archivos
{
    partial class frmArchivosMain
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
            this.tcPrincipal = new System.Windows.Forms.TabControl();
            this.tpImport = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbBuscar = new System.Windows.Forms.ToolStripButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbArchivos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stStrip = new System.Windows.Forms.StatusStrip();
            this.sstlblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLibro = new System.Windows.Forms.ComboBox();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.cmbOpe = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNroRuc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.txtRutaImport = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tpExport = new System.Windows.Forms.TabPage();
            this.stStrip2 = new System.Windows.Forms.StatusStrip();
            this.tslblExportS = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvErrores = new System.Windows.Forms.DataGridView();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.cmbMesGen = new System.Windows.Forms.ComboBox();
            this.txtAnioGen = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRutaExport = new System.Windows.Forms.TextBox();
            this.btnRutaExp = new System.Windows.Forms.Button();
            this.txtArchivoOrig = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.bkgwImport = new System.ComponentModel.BackgroundWorker();
            this.bkgwExport = new System.ComponentModel.BackgroundWorker();
            this.tcPrincipal.SuspendLayout();
            this.tpImport.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.stStrip.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpExport.SuspendLayout();
            this.stStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPrincipal
            // 
            this.tcPrincipal.Controls.Add(this.tpImport);
            this.tcPrincipal.Controls.Add(this.tpExport);
            this.tcPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tcPrincipal.Name = "tcPrincipal";
            this.tcPrincipal.SelectedIndex = 0;
            this.tcPrincipal.Size = new System.Drawing.Size(726, 614);
            this.tcPrincipal.TabIndex = 2;
            // 
            // tpImport
            // 
            this.tpImport.Controls.Add(this.toolStrip1);
            this.tpImport.Controls.Add(this.groupBox4);
            this.tpImport.Controls.Add(this.stStrip);
            this.tpImport.Controls.Add(this.groupBox3);
            this.tpImport.Controls.Add(this.groupBox1);
            this.tpImport.Controls.Add(this.groupBox2);
            this.tpImport.Location = new System.Drawing.Point(4, 22);
            this.tpImport.Name = "tpImport";
            this.tpImport.Padding = new System.Windows.Forms.Padding(3);
            this.tpImport.Size = new System.Drawing.Size(718, 588);
            this.tpImport.TabIndex = 0;
            this.tpImport.Text = "Import";
            this.tpImport.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBuscar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(712, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbBuscar
            // 
            this.tsbBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBuscar.Image = global::AdmTramasPLE.Properties.Resources.page_find;
            this.tsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuscar.Name = "tsbBuscar";
            this.tsbBuscar.Size = new System.Drawing.Size(23, 22);
            this.tsbBuscar.Text = "Buscar";
            this.tsbBuscar.ToolTipText = "Buscar";
            this.tsbBuscar.Click += new System.EventHandler(this.tsbBuscar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbArchivos);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(6, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(702, 58);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Archivo";
            // 
            // cmbArchivos
            // 
            this.cmbArchivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArchivos.FormattingEnabled = true;
            this.cmbArchivos.Location = new System.Drawing.Point(63, 25);
            this.cmbArchivos.Name = "cmbArchivos";
            this.cmbArchivos.Size = new System.Drawing.Size(164, 21);
            this.cmbArchivos.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Archivos:";
            // 
            // stStrip
            // 
            this.stStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sstlblEstado,
            this.tsslblStatus});
            this.stStrip.Location = new System.Drawing.Point(3, 563);
            this.stStrip.Name = "stStrip";
            this.stStrip.Size = new System.Drawing.Size(712, 22);
            this.stStrip.TabIndex = 4;
            this.stStrip.Text = "statusStrip1";
            // 
            // sstlblEstado
            // 
            this.sstlblEstado.Name = "sstlblEstado";
            this.sstlblEstado.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslblStatus
            // 
            this.tsslblStatus.Name = "tsslblStatus";
            this.tsslblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvCargas);
            this.groupBox3.Location = new System.Drawing.Point(6, 282);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(704, 278);
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
            this.dgvCargas.Location = new System.Drawing.Point(3, 16);
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.Size = new System.Drawing.Size(698, 259);
            this.dgvCargas.TabIndex = 0;
            this.dgvCargas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargas_CellClick);
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
            this.groupBox1.Location = new System.Drawing.Point(8, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 104);
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
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Contenido de Libro o Registro:";
            // 
            // txtNroRuc
            // 
            this.txtNroRuc.Location = new System.Drawing.Point(178, 27);
            this.txtNroRuc.MaxLength = 14;
            this.txtNroRuc.Name = "txtNroRuc";
            this.txtNroRuc.Size = new System.Drawing.Size(169, 20);
            this.txtNroRuc.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Indicador de Moneda:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnCargar);
            this.groupBox2.Controls.Add(this.txtRutaImport);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Location = new System.Drawing.Point(8, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 71);
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
            this.txtRutaImport.Size = new System.Drawing.Size(472, 20);
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
            // tpExport
            // 
            this.tpExport.Controls.Add(this.stStrip2);
            this.tpExport.Controls.Add(this.dgvErrores);
            this.tpExport.Controls.Add(this.dgvHistorial);
            this.tpExport.Controls.Add(this.label28);
            this.tpExport.Controls.Add(this.label26);
            this.tpExport.Controls.Add(this.groupBox11);
            this.tpExport.Controls.Add(this.groupBox10);
            this.tpExport.Location = new System.Drawing.Point(4, 22);
            this.tpExport.Name = "tpExport";
            this.tpExport.Padding = new System.Windows.Forms.Padding(3);
            this.tpExport.Size = new System.Drawing.Size(718, 588);
            this.tpExport.TabIndex = 1;
            this.tpExport.Text = "Export";
            this.tpExport.UseVisualStyleBackColor = true;
            // 
            // stStrip2
            // 
            this.stStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblExportS});
            this.stStrip2.Location = new System.Drawing.Point(3, 563);
            this.stStrip2.Name = "stStrip2";
            this.stStrip2.Size = new System.Drawing.Size(712, 22);
            this.stStrip2.TabIndex = 8;
            this.stStrip2.Text = "statusStrip1";
            // 
            // tslblExportS
            // 
            this.tslblExportS.Name = "tslblExportS";
            this.tslblExportS.Size = new System.Drawing.Size(0, 17);
            // 
            // dgvErrores
            // 
            this.dgvErrores.AllowUserToAddRows = false;
            this.dgvErrores.AllowUserToDeleteRows = false;
            this.dgvErrores.AllowUserToResizeColumns = false;
            this.dgvErrores.AllowUserToResizeRows = false;
            this.dgvErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvErrores.BackgroundColor = System.Drawing.Color.White;
            this.dgvErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrores.Location = new System.Drawing.Point(388, 198);
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.ReadOnly = true;
            this.dgvErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrores.Size = new System.Drawing.Size(324, 357);
            this.dgvErrores.TabIndex = 7;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AllowUserToResizeColumns = false;
            this.dgvHistorial.AllowUserToResizeRows = false;
            this.dgvHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(6, 198);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(376, 357);
            this.dgvHistorial.TabIndex = 6;
            this.dgvHistorial.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorial_CellDoubleClick);
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Silver;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(388, 170);
            this.label28.Name = "label28";
            this.label28.Padding = new System.Windows.Forms.Padding(5);
            this.label28.Size = new System.Drawing.Size(324, 25);
            this.label28.TabIndex = 4;
            this.label28.Text = "Detalle de Errores:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Silver;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(6, 170);
            this.label26.Name = "label26";
            this.label26.Padding = new System.Windows.Forms.Padding(5);
            this.label26.Size = new System.Drawing.Size(376, 25);
            this.label26.TabIndex = 3;
            this.label26.Text = "Archivos Generados:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnGenerar);
            this.groupBox11.Controls.Add(this.cmbMesGen);
            this.groupBox11.Controls.Add(this.txtAnioGen);
            this.groupBox11.Controls.Add(this.label24);
            this.groupBox11.Controls.Add(this.label23);
            this.groupBox11.Location = new System.Drawing.Point(8, 6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(704, 61);
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
            // txtAnioGen
            // 
            this.txtAnioGen.Location = new System.Drawing.Point(43, 30);
            this.txtAnioGen.MaxLength = 4;
            this.txtAnioGen.Name = "txtAnioGen";
            this.txtAnioGen.Size = new System.Drawing.Size(60, 20);
            this.txtAnioGen.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(109, 30);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(30, 13);
            this.label24.TabIndex = 2;
            this.label24.Text = "Mes:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 30);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "Año:";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label6);
            this.groupBox10.Controls.Add(this.txtRutaExport);
            this.groupBox10.Controls.Add(this.btnRutaExp);
            this.groupBox10.Controls.Add(this.txtArchivoOrig);
            this.groupBox10.Controls.Add(this.label29);
            this.groupBox10.Location = new System.Drawing.Point(6, 73);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(706, 94);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Ruta de Exportación";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Elegir Ruta:";
            // 
            // txtRutaExport
            // 
            this.txtRutaExport.BackColor = System.Drawing.Color.White;
            this.txtRutaExport.Location = new System.Drawing.Point(148, 56);
            this.txtRutaExport.Name = "txtRutaExport";
            this.txtRutaExport.ReadOnly = true;
            this.txtRutaExport.Size = new System.Drawing.Size(501, 20);
            this.txtRutaExport.TabIndex = 1;
            // 
            // btnRutaExp
            // 
            this.btnRutaExp.Location = new System.Drawing.Point(94, 54);
            this.btnRutaExp.Name = "btnRutaExp";
            this.btnRutaExp.Size = new System.Drawing.Size(43, 23);
            this.btnRutaExp.TabIndex = 1;
            this.btnRutaExp.Text = "...";
            this.btnRutaExp.UseVisualStyleBackColor = true;
            this.btnRutaExp.Click += new System.EventHandler(this.btnRutaExp_Click);
            // 
            // txtArchivoOrig
            // 
            this.txtArchivoOrig.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArchivoOrig.Location = new System.Drawing.Point(94, 28);
            this.txtArchivoOrig.Name = "txtArchivoOrig";
            this.txtArchivoOrig.ReadOnly = true;
            this.txtArchivoOrig.Size = new System.Drawing.Size(555, 22);
            this.txtArchivoOrig.TabIndex = 2;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 26);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(80, 13);
            this.label29.TabIndex = 2;
            this.label29.Text = "Archivo Origen:";
            // 
            // bkgwImport
            // 
            this.bkgwImport.WorkerReportsProgress = true;
            this.bkgwImport.WorkerSupportsCancellation = true;
            this.bkgwImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgwImport_DoWork);
            this.bkgwImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgwImport_RunWorkerCompleted);
            // 
            // bkgwExport
            // 
            this.bkgwExport.WorkerReportsProgress = true;
            this.bkgwExport.WorkerSupportsCancellation = true;
            this.bkgwExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgwExport_DoWork);
            this.bkgwExport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkgwExport_ProgressChanged);
            this.bkgwExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgwExport_RunWorkerCompleted);
            // 
            // frmArchivosMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 614);
            this.Controls.Add(this.tcPrincipal);
            this.Name = "frmArchivosMain";
            this.Text = "Import y Export";
            this.Load += new System.EventHandler(this.frmArchivosMain_Load);
            this.tcPrincipal.ResumeLayout(false);
            this.tpImport.ResumeLayout(false);
            this.tpImport.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.stStrip.ResumeLayout(false);
            this.stStrip.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tpExport.ResumeLayout(false);
            this.tpExport.PerformLayout();
            this.stStrip2.ResumeLayout(false);
            this.stStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPrincipal;
        private System.Windows.Forms.TabPage tpImport;
        private System.Windows.Forms.StatusStrip stStrip;
        private System.Windows.Forms.ToolStripStatusLabel sstlblEstado;
        private System.Windows.Forms.ToolStripStatusLabel tsslblStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.TextBox txtRutaImport;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbLibro;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.ComboBox cmbOpe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNroRuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpExport;
        private System.Windows.Forms.StatusStrip stStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tslblExportS;
        private System.Windows.Forms.DataGridView dgvErrores;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.ComboBox cmbMesGen;
        private System.Windows.Forms.TextBox txtArchivoOrig;
        private System.Windows.Forms.TextBox txtAnioGen;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox txtRutaExport;
        private System.Windows.Forms.Button btnRutaExp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbArchivos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker bkgwImport;
        private System.ComponentModel.BackgroundWorker bkgwExport;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbBuscar;

    }
}