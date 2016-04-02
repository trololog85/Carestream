using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CareStream.Logic.Facade;
using CareStream.Data.Access;
using CareStream.Utils;
using CareStream.Logic.IO;

namespace AdmTramasPLE.Archivos
{
    public partial class frmArchivosMain : Form
    {
        private String ruta_archivo;
        private Char ope;
        private String moneda;
        private Char libro;
        private String ruc;
        private Int32 mes;
        private Int32 anio;
        private String rpta = String.Empty;
        private String ruta_export;

        private Int32 id_archivo;
        private String l_num_ruc;
        private Int32 l_id_ope;
        private Int32 l_id_libro;
        private String l_id_moneda;
        private Int32 l_id_archivo;

        private Archivo archivo = null;

        public frmArchivosMain()
        {
            InitializeComponent();
        }

        private void frmArchivosMain_Load(object sender, EventArgs e)
        {
            CargarForm();
        }

        private void CargarForm()
        { 
            //Cargar Archivos
            CargarArchivos();
            CargarCombosAux();
        }

        private void CargarArchivos()
        {
            FArchivo obj = new FArchivo();

            List<Archivo> lst = obj.Listar();

            this.cmbArchivos.DataSource = lst;
            this.cmbArchivos.ValueMember = "id";
            this.cmbArchivos.DisplayMember = "nombre_proceso";
        }

        private void CargarCombosAux()
        {
            cmbOpe.DataSource = Combo.ListaIndicadorOperaciones();
            cmbOpe.ValueMember = "cod";
            cmbOpe.DisplayMember = "nombre";

            cmbLibro.DataSource = Combo.ListaIndicadorLibroRegistro();
            cmbLibro.ValueMember = "cod";
            cmbLibro.DisplayMember = "nombre";

            cmbMoneda.DataSource = Combo.ListaIndicadordeMoneda();
            cmbMoneda.ValueMember = "scod";
            cmbMoneda.DisplayMember = "nombre";

            cmbMesGen.DataSource = Combo.ListaMeses();
            cmbMesGen.ValueMember = "sCod";
            cmbMesGen.DisplayMember = "Nombre";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtRutaImport.Text = File.AbrirArchivo();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarArchivo();
        }

        private void CargarArchivo()
        {
            if (Validar())
            {
                //Cargamos las variables
                this.tsslblStatus.Text = "Cargando Archivo...";

                this.ruta_archivo = this.txtRutaImport.Text;
                this.ruc = txtNroRuc.Text;
                this.ope = Convert.ToChar(cmbOpe.SelectedValue);
                this.moneda = cmbMoneda.SelectedValue.ToString();
                this.libro = Convert.ToChar(cmbLibro.SelectedValue);

                //Deshabilitamos el boton
                this.btnCargar.Enabled = false;

                this.archivo = (Archivo)(this.cmbArchivos.SelectedItem);

                ObtieneArchivoxCod();

                bkgwImport.RunWorkerAsync();
            }
        }

        private Boolean Validar()
        {
            if (this.txtRutaImport.Text.Trim() == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe seleccionar un archivo.", 1);
                return false;
            }

            if (this.txtNroRuc.Text.Trim() == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe ingresar el número de RUC.", 1);
                return false;
            }

            return true;
        }

        private void bkgwImport_DoWork(object sender, DoWorkEventArgs e)
        {
            FInput objF = new FInput();

            this.rpta = objF.CargarArchivo(this.ruta_archivo, this.archivo.codigo, this.ruc,
                    this.ope, this.moneda, this.libro, this.id_archivo);
        }

        private void bkgwImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (rpta != String.Empty)
            {
                Mensaje.MostrarMensaje(rpta, 2);
            }
            else
            {
                ObtieneCargas();

                LimpiarFormulario();
            }

            this.tsslblStatus.Text = String.Empty;

            this.btnCargar.Enabled = true;
        }

        private void LimpiarFormulario()
        {
            this.txtNroRuc.Text = String.Empty;
            this.cmbOpe.SelectedIndex = 0;
            this.cmbLibro.SelectedIndex = 0;
            this.cmbMoneda.SelectedIndex = 0;
            this.txtRutaImport.Text = String.Empty;
            this.sstlblEstado.Text = String.Empty;
        }

        private void ObtieneCargas()
        {
            FArchivoLog objF = new FArchivoLog();

            List<ArchivoLog> lst = objF.ListarxLogxOpe("I", id_archivo);

            this.dgvCargas.DataSource = lst;

            this.dgvCargas.Columns["nombre_carga"].HeaderText = "Nombre de Archivo";
            this.dgvCargas.Columns["nombre_carga"].Width = 250;
            this.dgvCargas.Columns["nombre_carga"].DisplayIndex = 0;

            this.dgvCargas.Columns["fecha_carga"].HeaderText = "Fecha de Carga";
            this.dgvCargas.Columns["fecha_carga"].Width = 150;
            this.dgvCargas.Columns["fecha_carga"].DisplayIndex = 1;

            this.dgvCargas.Columns["cant_registros"].HeaderText = "Cantidad de Registros";
            this.dgvCargas.Columns["cant_registros"].Width = 150;
            this.dgvCargas.Columns["cant_registros"].DisplayIndex = 2;

            this.dgvCargas.Columns["id"].Visible = false;
            this.dgvCargas.Columns["id_archivo"].Visible = false;
            this.dgvCargas.Columns["num_ruc"].Visible = false;
            this.dgvCargas.Columns["indicador_ope"].Visible = false;
            this.dgvCargas.Columns["indicador_moneda"].Visible = false;
            this.dgvCargas.Columns["indicador_libro"].Visible = false;
            this.dgvCargas.Columns["archivologdetalles"].Visible = false;
            this.dgvCargas.Columns["tipo_ope"].Visible = false;
            this.dgvCargas.Columns["fecha_generacion"].Visible = false;

            if (this.dgvCargas.Columns["ImgExportar"] == null)
            {
                DataGridViewImageColumn dgvBc = new DataGridViewImageColumn();
                dgvBc.Name = "ImgExportar";
                dgvBc.HeaderText = "Exportar";
                dgvBc.Image = Properties.Resources.page;
                dgvBc.Visible = true;
                dgvBc.DisplayIndex = 5;
                dgvBc.Width = 60;
                dgvCargas.Columns.Add(dgvBc);
            }

            if (this.dgvCargas.Columns["ImgDetalle"] == null)
            {
                DataGridViewImageColumn dgvBc = new DataGridViewImageColumn();
                dgvBc.Name = "ImgDetalle";
                dgvBc.HeaderText = "Detalle";
                dgvBc.Image = Properties.Resources.magnifier_zoom_in;
                dgvBc.Visible = true;
                dgvBc.DisplayIndex = 5;
                dgvBc.Width = 60;
                dgvCargas.Columns.Add(dgvBc);
            }
        }

        private void ObtieneArchivoxCod()
        {
            FArchivo objF = new FArchivo();

            this.id_archivo = objF.ObtieneIDxCod(this.archivo.codigo);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (ValidarPeriodo())
            {
                ObtieneArchivoxCod();

                this.tslblExportS.Text = "Cargando Archivo...";

                this.btnGenerar.Enabled = false;

                this.ruta_archivo = txtRutaExport.Text;
                this.anio = Int32.Parse(txtAnioGen.Text);
                this.mes = Convert.ToInt32(cmbMesGen.SelectedValue);

                ruta_export = this.txtRutaExport.Text;

                bkgwExport.RunWorkerAsync();
            }
        }

        private Boolean ValidarPeriodo()
        {
            Int32 mes = DateTime.Now.Month;
            Int32 anio = DateTime.Now.Year;

            if (this.txtArchivoOrig.Text == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe elegir un archivo fuente.", 1);

                return false;
            }

            if (this.txtAnioGen.Text == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe ingresar el año del periodo.", 1);

                return false;
            }

            if (this.txtRutaExport.Text.Trim() == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe ingresar la ruta de exportacion.", 1);

                return false;
            }

            /*if (anio < Int32.Parse(txtAnioGen.Text))
            {
                Mensaje.MostrarMensaje("El periodo a generar no puede ser mayor a la fecha actual.", 1);

                return false;
            }
            else
            {
                if (mes < Convert.ToInt32(cmbMesGen.SelectedValue))
                {
                    Mensaje.MostrarMensaje("El periodo a generar no puede ser mayor a la fecha actual.", 1);

                    return false;    
                }
            }*/

            return true;
        }

        private void bkgwExport_DoWork(object sender, DoWorkEventArgs e)
        {
            FExport objF = new FExport();

            this.rpta = objF.ExportaArchivo(this.ruta_archivo, id_archivo, this.archivo.codigo,
                    this.l_num_ruc, this.l_id_ope, this.l_id_libro, this.l_id_moneda,
                    this.mes, this.anio, this.l_id_archivo);
        }

        private void bkgwExport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bkgwExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CargarHistorial();

            this.tslblExportS.Text = String.Empty;

            this.btnGenerar.Enabled = true;

            if (rpta != String.Empty)
            {
                Mensaje.MostrarMensaje(rpta, 2);
            }
            else
            {
                Mensaje.AbrirFolder(ruta_export);
            }
        }

        private void CargarHistorial()
        {
            FArchivoLog objF = new FArchivoLog();

            List<ArchivoLog> lstLog = objF.ListarxLogxOpe("E", id_archivo);

            dgvHistorial.DataSource = lstLog;

            dgvHistorial.Columns["id"].Visible = false;
            dgvHistorial.Columns["id_archivo"].Visible = false;
            dgvHistorial.Columns["num_ruc"].Visible = false;
            dgvHistorial.Columns["indicador_ope"].Visible = false;
            dgvHistorial.Columns["indicador_moneda"].Visible = false;
            dgvHistorial.Columns["indicador_libro"].Visible = false;
            dgvHistorial.Columns["tipo_ope"].Visible = false;
            dgvHistorial.Columns["fecha_generacion"].Visible = false;
            dgvHistorial.Columns["fecha_generacion"].Visible = false;
            dgvHistorial.Columns["archivologdetalles"].Visible = false;

            dgvHistorial.Columns["nombre_carga"].HeaderText = "Archivo";
            dgvHistorial.Columns["nombre_carga"].Width = 250;
            dgvHistorial.Columns["nombre_carga"].DisplayIndex = 0;

            dgvHistorial.Columns["cant_registros"].HeaderText = "N° Registros";
            dgvHistorial.Columns["cant_registros"].Width = 120;
            dgvHistorial.Columns["cant_registros"].DisplayIndex = 1;

            dgvHistorial.Columns["fecha_carga"].HeaderText = "Fecha de Carga";
            dgvHistorial.Columns["fecha_carga"].Width = 160;
            dgvHistorial.Columns["fecha_carga"].DisplayIndex = 2;
        }

        private void LimpiarExport()
        {
            this.txtAnioGen.Text = String.Empty;
            this.cmbMesGen.SelectedIndex = 0;
            this.txtArchivoOrig.Text = String.Empty;
        }
        
        private void dgvCargas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Int32 i = this.dgvCargas.Columns["ImgExportar"].Index;
                Int32 i1 = this.dgvCargas.Columns["ImgDetalle"].Index;

                if (e.ColumnIndex == i)
                {
                    LimpiarExport();
                    
                    this.l_id_archivo = Convert.ToInt32(dgvCargas.Rows[e.RowIndex].Cells["id"].Value);
                    this.l_id_libro = Convert.ToInt32(dgvCargas.Rows[e.RowIndex].Cells["indicador_libro"].Value);
                    this.l_id_moneda = dgvCargas.Rows[e.RowIndex].Cells["indicador_moneda"].Value.ToString();
                    this.l_id_ope = Convert.ToInt32(dgvCargas.Rows[e.RowIndex].Cells["indicador_ope"].Value);
                    this.l_num_ruc = dgvCargas.Rows[e.RowIndex].Cells["num_ruc"].Value.ToString();
                    this.txtArchivoOrig.Text = dgvCargas.Rows[e.RowIndex].Cells["nombre_carga"].Value.ToString();

                    Archivo archivo = (Archivo)(this.cmbArchivos.SelectedItem);

                    CargarHistorial();

                    this.tcPrincipal.SelectedTab = tpExport;
                }
                else if (e.ColumnIndex == i1)
                { 
                    //CargarDetalle()
                }
            }
        }

        private void dgvHistorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Int32 id_archivo_log = Convert.ToInt32(dgvHistorial.Rows[e.RowIndex].Cells["id"].Value);

                CargarDetalleError(id_archivo_log);
            }
        }

        private void CargarDetalleError(Int32 id_archivo_log)
        {
            FErrorLineaDetalle objF = new FErrorLineaDetalle();

            List<ErrorLineaDetalle> lst = objF.ListarxArchivoLog(id_archivo_log);

            dgvErrores.DataSource = lst;

            dgvErrores.Columns["id_archivo_log"].Visible = false;
            dgvErrores.Columns["id_error"].Visible = false;

            dgvErrores.Columns["n_linea"].DisplayIndex = 0;
            dgvErrores.Columns["n_linea"].HeaderText = "N° de Linea";
            dgvErrores.Columns["n_linea"].Width = 120;

            dgvErrores.Columns["nombre_campo"].DisplayIndex = 1;
            dgvErrores.Columns["nombre_campo"].HeaderText = "Campo";
            dgvErrores.Columns["nombre_campo"].Width = 200;

            dgvErrores.Columns["descripcion"].DisplayIndex = 2;
            dgvErrores.Columns["descripcion"].HeaderText = "Descripción";
            dgvErrores.Columns["descripcion"].Width = 500;

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            this.archivo = (Archivo)(this.cmbArchivos.SelectedItem);

            ObtieneArchivoxCod();

            ObtieneCargas();

            LimpiarExport();
        }

        private void btnRutaExp_Click(object sender, EventArgs e)
        {
            txtRutaExport.Text = File.AbrirRuta();
        }
    }
}
