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
    public partial class frmRegCompras : AdmTramasPLE.Base.frmBase
    {
        private Int32 id_archivo;
        private String l_num_ruc;
        private Int32 l_id_ope;
        private Int32 l_id_libro;
        private String l_id_moneda;
        private Int32 l_id_archivo;

        //

        private String ruta_archivo;
        private Char ope;
        private String moneda;
        private Char libro;
        private String ruc;
        private Int32 mes;
        private Int32 anio;
        private String rpta = String.Empty;

        private String ruta_export;

        public frmRegCompras()
        {
            InitializeComponent();
        }

        private void txtNroRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Formato.ValidaEntero(e.KeyChar.ToString());
        }

        private void frmRegVentas_Load(object sender, EventArgs e)
        {
            CargarFormulario();

            ObtieneArchivoxCod();

            ObtieneCargas();
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
                dgvBc.Width = 120;
                dgvCargas.Columns.Add(dgvBc);
            }
        }

        private void ObtieneArchivoxCod()
        { 
            FArchivo objF = new FArchivo();

            id_archivo = objF.ObtieneIDxCod("080100");
        }

        private void CargarFormulario()
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

            FCodigoDetalle objF = new FCodigoDetalle();

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
                this.tslblStatus.Text = "Cargando Archivo...";

                this.ruta_archivo = this.txtRutaImport.Text;
                this.ruc = txtNroRuc.Text;
                this.ope = Convert.ToChar(cmbOpe.SelectedValue);
                this.moneda = cmbMoneda.SelectedValue.ToString();
                this.libro = Convert.ToChar(cmbLibro.SelectedValue);

                //Deshabilitamos el boton
                this.btnCargar.Enabled = false;

                bkgImport.RunWorkerAsync();
            }
        }

        private Boolean Validar()
        {
            if (this.txtRutaImport.Text.Trim() == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe seleccionar un archivo Excel.", 1);
                return false;
            }

            if (this.txtNroRuc.Text.Trim() == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe ingresar el número de RUC.", 1);
                return false;
            }

            return true;
        }

        
        private void CargarDetalle(Int32 idarchivo_log)
        {
            FInputDetalle objDA = new FInputDetalle();

            List<InputRegistroCompra> lst = objDA.ObtieneDetalleRegistroCompra(idarchivo_log);

            this.dgvDetalleImp.DataSource = lst;

            /*dgvDetalleImp.Columns["id_archivo_log"].Visible = false;
            dgvDetalleImp.Columns["id_linea"].Visible = false;
            dgvDetalleImp.Columns["fechamod"].Visible = false;
            dgvDetalleImp.Columns["tipomod"].Visible = false;
            dgvDetalleImp.Columns["seriemod"].Visible = false;
            dgvDetalleImp.Columns["nomod"].Visible = false;
            dgvDetalleImp.Columns["vvmod"].Visible = false;
            dgvDetalleImp.Columns["igvmod"].Visible = false;
            dgvDetalleImp.Columns["pvmod"].Visible = false;
            
            dgvDetalleImp.Columns["num_correlativo"].DisplayIndex = 0;
            dgvDetalleImp.Columns["num_correlativo"].HeaderText = "Nro.";
            dgvDetalleImp.Columns["num_correlativo"].Width = 80;

            dgvDetalleImp.Columns["fecha_comprobante"].DisplayIndex = 1;
            dgvDetalleImp.Columns["fecha_comprobante"].HeaderText = "Fecha Comprobante";
            dgvDetalleImp.Columns["fecha_comprobante"].Width = 120;

            dgvDetalleImp.Columns["tipo_comprobante"].DisplayIndex = 2;
            dgvDetalleImp.Columns["tipo_comprobante"].HeaderText = "Tipo Comprobante";
            dgvDetalleImp.Columns["tipo_comprobante"].Width = 120;

            dgvDetalleImp.Columns["interno_comprobante"].DisplayIndex = 3;
            dgvDetalleImp.Columns["interno_comprobante"].HeaderText = "Nro. Interno";
            dgvDetalleImp.Columns["interno_comprobante"].Width = 120;

            dgvDetalleImp.Columns["interno_comprobante"].DisplayIndex = 4;
            dgvDetalleImp.Columns["interno_comprobante"].HeaderText = "Nro. Interno";
            dgvDetalleImp.Columns["interno_comprobante"].Width = 120;

            dgvDetalleImp.Columns["serie_comprobante"].DisplayIndex = 5;
            dgvDetalleImp.Columns["serie_comprobante"].HeaderText = "Nro. Serie";
            dgvDetalleImp.Columns["serie_comprobante"].Width = 120;

            dgvDetalleImp.Columns["num_comprobante"].DisplayIndex = 6;
            dgvDetalleImp.Columns["num_comprobante"].HeaderText = "Nro. Comprobante";
            dgvDetalleImp.Columns["num_comprobante"].Width = 120;

            dgvDetalleImp.Columns["tipo_documento"].DisplayIndex = 7;
            dgvDetalleImp.Columns["tipo_documento"].HeaderText = "Tipo Doc.";
            dgvDetalleImp.Columns["tipo_documento"].Width = 120;

            dgvDetalleImp.Columns["num_documento"].DisplayIndex = 8;
            dgvDetalleImp.Columns["num_documento"].HeaderText = "Num Doc.";
            dgvDetalleImp.Columns["num_documento"].Width = 120;

            dgvDetalleImp.Columns["codigo_documento"].DisplayIndex = 9;
            dgvDetalleImp.Columns["codigo_documento"].HeaderText = "Cod. Documento";
            dgvDetalleImp.Columns["codigo_documento"].Width = 120;

            dgvDetalleImp.Columns["nombre_razon_social"].DisplayIndex = 10;
            dgvDetalleImp.Columns["nombre_razon_social"].HeaderText = "Nombre/Razon Social";
            dgvDetalleImp.Columns["nombre_razon_social"].Width = 120;

            dgvDetalleImp.Columns["valor_venta_orig"].DisplayIndex = 11;
            dgvDetalleImp.Columns["valor_venta_orig"].HeaderText = "Valor Venta";
            dgvDetalleImp.Columns["valor_venta_orig"].Width = 120;
            dgvDetalleImp.Columns["valor_venta_orig"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalleImp.Columns["moneda"].DisplayIndex = 12;
            dgvDetalleImp.Columns["moneda"].HeaderText = "Moneda";
            dgvDetalleImp.Columns["moneda"].Width = 120;

            dgvDetalleImp.Columns["tipo_cambio"].DisplayIndex = 13;
            dgvDetalleImp.Columns["tipo_cambio"].HeaderText = "Tipo Cambio";
            dgvDetalleImp.Columns["tipo_cambio"].Width = 120;
            dgvDetalleImp.Columns["tipo_cambio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalleImp.Columns["tipo_cambio"].DisplayIndex = 14;
            dgvDetalleImp.Columns["tipo_cambio"].HeaderText = "Tipo Cambio";
            dgvDetalleImp.Columns["tipo_cambio"].Width = 120;
            dgvDetalleImp.Columns["tipo_cambio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalleImp.Columns["vv"].DisplayIndex = 15;
            dgvDetalleImp.Columns["vv"].HeaderText = "V.V.";
            dgvDetalleImp.Columns["vv"].Width = 120;
            dgvDetalleImp.Columns["vv"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalleImp.Columns["igv"].DisplayIndex = 16;
            dgvDetalleImp.Columns["igv"].HeaderText = "IGV";
            dgvDetalleImp.Columns["igv"].Width = 120;
            dgvDetalleImp.Columns["igv"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalleImp.Columns["pv"].DisplayIndex = 17;
            dgvDetalleImp.Columns["pv"].HeaderText = "P.V.";
            dgvDetalleImp.Columns["pv"].Width = 120;
            dgvDetalleImp.Columns["pv"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalleImp.Columns["pv"].DisplayIndex = 18;
            dgvDetalleImp.Columns["pv"].HeaderText = "P.V.";
            dgvDetalleImp.Columns["pv"].Width = 120;
            dgvDetalleImp.Columns["pv"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalleImp.Columns["pv"].DisplayIndex = 19;
            dgvDetalleImp.Columns["pv"].HeaderText = "P.V.";
            dgvDetalleImp.Columns["pv"].Width = 120;
            dgvDetalleImp.Columns["pv"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;*/
        }

        private void LimpiarFormulario()
        {
            this.txtNroRuc.Text = String.Empty;
            this.cmbOpe.SelectedIndex = 0;
            this.cmbLibro.SelectedIndex = 0;
            this.cmbMoneda.SelectedIndex = 0;
            this.txtRutaImport.Text = String.Empty;
        }

        private void dgvDetalleImp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                MostrarDetalle(e.RowIndex);
            }
        }

        private void MostrarDetalle(Int32 row)
        {
            
        }

        private void dgvCargas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 i = this.dgvCargas.Columns["ImgExportar"].Index;

            if (e.ColumnIndex == i)
            {
                if (e.RowIndex != -1)
                {
                    this.l_id_archivo = Convert.ToInt32(dgvCargas.Rows[e.RowIndex].Cells["id"].Value);
                    this.l_id_libro = Convert.ToInt32(dgvCargas.Rows[e.RowIndex].Cells["indicador_libro"].Value);
                    this.l_id_moneda = dgvCargas.Rows[e.RowIndex].Cells["indicador_moneda"].Value.ToString();
                    this.l_id_ope = Convert.ToInt32(dgvCargas.Rows[e.RowIndex].Cells["indicador_ope"].Value);
                    this.l_num_ruc = dgvCargas.Rows[e.RowIndex].Cells["num_ruc"].Value.ToString();
                    this.txtArchivoOrig.Text = dgvCargas.Rows[e.RowIndex].Cells["nombre_carga"].Value.ToString();

                    CargarHistorial();

                    this.tcPrincipal.SelectedTab = tpExport;
                }
            }
            else
            {
                if (e.RowIndex != -1)
                {
                    txtNroRuc.Text = dgvCargas.Rows[e.RowIndex].Cells["num_ruc"].Value.ToString();
                    cmbOpe.SelectedValue = Convert.ToChar(dgvCargas.Rows[e.RowIndex].Cells["indicador_ope"].Value);
                    cmbLibro.SelectedValue = Convert.ToChar(dgvCargas.Rows[e.RowIndex].Cells["indicador_libro"].Value);
                    cmbMoneda.SelectedValue = dgvCargas.Rows[e.RowIndex].Cells["indicador_moneda"].Value.ToString();

                    Int32 id_archivo = Convert.ToInt32(dgvCargas.Rows[e.RowIndex].Cells["id"].Value);

                    txtNombreCarga.Text = dgvCargas.Rows[e.RowIndex].Cells["nombre_carga"].Value.ToString();
                    txtFechaCarga.Text = DateTime.Parse(dgvCargas.Rows[e.RowIndex].Cells["fecha_carga"].Value.ToString()).ToShortDateString();

                    CargarDetalle(id_archivo);
                }
            }
        }

        private void dgvDetalleImp_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            MostrarDetalle(e.RowIndex);
        }

        private void txtValOrig_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Formato.ValidaNumerico(e.KeyChar.ToString());
        }

        private void txtVV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Formato.ValidaNumerico(e.KeyChar.ToString());
        }

        private void txtTipoCamb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Formato.ValidaNumerico(e.KeyChar.ToString());
        }

        private void txtIGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Formato.ValidaNumerico(e.KeyChar.ToString());
        }

        private void txtPV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Formato.ValidaNumerico(e.KeyChar.ToString());
        }

        private void btnRutaExp_Click(object sender, EventArgs e)
        {
            txtRutaExport.Text = File.AbrirRuta();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (ValidarPeriodo())
            {
                ObtieneArchivoxCod();

                this.tslblExport.Text = "Cargando Archivo...";

                this.btnGenerar.Enabled = false;

                this.ruta_archivo = txtRutaExport.Text;
                this.anio = Int32.Parse(txtAnioGen.Text);
                this.mes = Convert.ToInt32(cmbMesGen.SelectedValue);

                ruta_export = this.txtRutaExport.Text;

                bkgExport.RunWorkerAsync();
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

        private void dgvHistorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Int32 id_archivo_log = Convert.ToInt32(dgvHistorial.Rows[e.RowIndex].Cells["id"].Value);

                CargarDetalleError(id_archivo_log);

                CargarDetalleArchivo(id_archivo_log);
            }
        }

        private void CargarDetalleArchivo(Int32 id_archivo_log)
        {
            FArchivoLogDetalle obj = new FArchivoLogDetalle();

            List<ArchivoLogDetalle> lst = obj.ListarxArchivoLog(id_archivo_log);

            this.lstDetalleExport.DataSource = lst;

            this.lstDetalleExport.DisplayMember = "trama";
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

        private void bkgImport_DoWork(object sender, DoWorkEventArgs e)
        {
            FInput objF = new FInput();

            //this.rpta = objF.CargarRegistroCompra(this.ruta_archivo, this.ruc,
            //    this.ope, this.moneda, this.libro, id_archivo);
        }

        private void bkgImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (rpta != String.Empty)
            {
                Mensaje.MostrarMensaje(rpta, 2);
            }
            else
            {
                LimpiarFormulario();

                ObtieneCargas();
            }

            this.tslblStatus.Text = String.Empty;

            this.btnCargar.Enabled = true;
        }

        private void bkgExport_DoWork(object sender, DoWorkEventArgs e)
        {
            FExport objF = new FExport();

            //this.rpta = objF.ExportaRegistroCompras(this.ruta_archivo, id_archivo, "080100",
            //        this.l_num_ruc, this.l_id_ope, this.l_id_libro, this.l_id_moneda,
            //        this.mes, this.anio, this.l_id_archivo);
        }

        private void bkgExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CargarHistorial();

            this.tslblExport.Text = String.Empty;

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
    }
}
