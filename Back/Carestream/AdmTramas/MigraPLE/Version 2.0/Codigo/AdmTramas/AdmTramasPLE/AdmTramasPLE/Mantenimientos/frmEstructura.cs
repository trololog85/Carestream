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


namespace AdmTramasPLE.Mantenimientos
{
    public partial class frmEstructura : AdmTramasPLE.Base.frmBase
    {
        private String rutaArchivo;
        private Estructura est = null;
        private Boolean sel = false;

        public frmEstructura()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarArchivo();
        }

        private void CargarArchivo()
        {
            FileDialog fi = new OpenFileDialog();
            fi.CheckFileExists = true;
            fi.CheckPathExists = true;
            fi.Title = "Seleccione el archivo";
            fi.Filter = "Excel|*.xlsx;*.xls";
            fi.InitialDirectory = @"\\";

            DialogResult dr = fi.ShowDialog();

            if (dr == DialogResult.OK)
            {
                rutaArchivo = fi.FileName;
                this.txtRuta.Text = fi.FileName;
            }
        }

        private void GuardarEstructura()
        {
            FEstructura objF = new FEstructura();

            Estructura objE = new Estructura();

            objE.nombre = this.txtNombreEstructura.Text.Trim();
            objE.longitud = 0;

            String rpta = objF.Guardar(this.txtRuta.Text, objE);

            if (rpta != String.Empty)
            {
                Mensaje.MostrarMensaje(String.Format("Ocurrio el siguiente error: {0}", rpta), 2);
            }
            else
            {
                Mensaje.MostrarMensaje("Se guardó la estructura de forma correcta.", 1);
            }
        }

        private Boolean Validar()
        {
            if (this.txtRuta.Text.Trim() == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe elegir un archivo a cargar.", 1);

                this.txtRuta.Focus();

                return false;
            }

            if (this.txtNombreEstructura.Text.Trim() == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe ingresar el nombre de la estructura.", 1);

                this.txtNombreEstructura.Focus();

                return false;
            }

            return true;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarEstructura();

                LimpiarFormulario();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            this.txtRuta.Text = String.Empty;
            this.txtNombreEstructura.Text = String.Empty;

            CargarEstructuras();
        }

        private void CargarEstructuras()
        {
            FEstructura objF = new FEstructura();

            List<Estructura> lst = objF.Listar();

            this.lstEstructuras.DataSource = lst;
            this.lstEstructuras.ValueMember = "id";
            this.lstEstructuras.DisplayMember = "nombre";
        }

        private void lstEstructuras_Click(object sender, EventArgs e)
        {
            Estructura obj = ((Estructura)(this.lstEstructuras.SelectedItem));

            est = obj;

            CargarInfoEstructura(obj.id);
        }

        private void CargarInfoEstructura(Int32 id_estructura)
        { 
            FInfoEstructura objF = new FInfoEstructura();

            List<InfoEstructura> lst = objF.Listar(id_estructura);

            this.lstCampos.DataSource = lst;
            this.lstCampos.ValueMember = "num_campo";
            this.lstCampos.DisplayMember = "descripcion";
        }

        private void lstCampos_Click(object sender, EventArgs e)
        {
            sel = true;

            InfoEstructura obj = ((InfoEstructura)(this.lstCampos.SelectedItem));

            this.txtNombreCampo.Text = obj.descripcion;
            this.txtLongitud.Text = obj.longitud_campo.ToString();

            this.cbObligatorio.Checked = obj.obligatorio;

            this.cmbFormato.SelectedValue = Convert.ToChar(obj.tipo_dato);
        }

        private void frmEstructura_Load(object sender, EventArgs e)
        {
            CargarFormulario();

            CargarEstructuras();
        }

        private void CargarFormulario()
        {
            this.cmbFormato.DataSource = Combo.ListaFormatos();

            this.cmbFormato.ValueMember = "cod";
            this.cmbFormato.DisplayMember = "nombre";

            this.btnCargar.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FEstructura objF = new FEstructura();

            if (est == null)
            {
                Mensaje.MostrarMensaje("Debe elegir un registro.", 1);
            }
            else
            {
                String s = objF.Eliminar(est);

                if (s != String.Empty)
                {
                    Mensaje.MostrarMensaje(s, 2);
                }
                else
                {
                    CargarEstructuras();
                }

                est = null;
            }
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {
            if (this.lstCampos.SelectedItem != null && this.sel)
            {
                InfoEstructura obj = new InfoEstructura();

                InfoEstructura aux = ((InfoEstructura)(this.lstCampos.SelectedItem));

                obj.descripcion = this.txtNombreCampo.Text.Trim();
                obj.longitud_campo = Convert.ToInt32(this.txtLongitud.Text.Trim());
                obj.obligatorio = this.cbObligatorio.Checked;
                obj.tipo_dato = this.cmbFormato.SelectedValue.ToString();
                obj.id_estructura = est.id;
                obj.num_campo = aux.num_campo;
                obj.nombre_input = aux.nombre_input;
                obj.pos_inicial = aux.pos_inicial;
                obj.pos_final = aux.pos_final;

                GuardarInfoEstructura(obj);
            }
            else
            {
                Mensaje.MostrarMensaje("Debe elegir un registro.", 1);
            }
        }
        private void GuardarInfoEstructura(InfoEstructura obj)
        {
            FInfoEstructura objF = new FInfoEstructura();

            String s = objF.Actualizar(obj);

            if (s != String.Empty)
            {
                Mensaje.MostrarMensaje(s, 2);
            }
            else
            {
                LimpiarDetalle();
            }
        }

        private void LimpiarDetalle()
        {
            this.txtNombreCampo.Text = String.Empty;
            this.txtLongitud.Text = String.Empty;
            this.cbObligatorio.Checked = false;
            this.cmbFormato.SelectedIndex = 0;

            lstEstructuras_Click(null, null);
        }
    }
}
