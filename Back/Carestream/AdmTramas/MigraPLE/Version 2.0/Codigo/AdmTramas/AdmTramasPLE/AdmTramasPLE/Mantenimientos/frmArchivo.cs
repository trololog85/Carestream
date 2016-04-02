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
    public partial class frmArchivo : AdmTramasPLE.Base.frmBase
    {
        private Boolean insercion = true;
        private Int32 id;

        public frmArchivo()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            insercion = true;

            this.txtNombreArchivo.Text = String.Empty;
            this.cmbEstructura.SelectedIndex = 0;
            this.txtCodigo.Text = String.Empty;

            ListarArchivos();

            this.txtNombreArchivo.Focus();
        }

        private void ListarArchivos()
        {
            FArchivo objF = new FArchivo();

            this.lstArchivos.DataSource = objF.Listar();
            this.lstArchivos.ValueMember = "id";
            this.lstArchivos.DisplayMember = "nombre_proceso";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                if (insercion)
                {
                    Guardar();
                }
                else
                {
                    Actualizar();
                }

                LimpiarFormulario();
                ListarArchivos();
            }
            
            
        }

        private Boolean Validar()
        {
            if (this.txtNombreArchivo.Text.Trim() == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe colocar el nombre del archivo.", 1);

                this.txtNombreArchivo.Focus();

                return false;
            }

            if (this.txtCodigo.Text.Trim() == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe colocar el código del archivo.", 2);

                this.txtCodigo.Focus();

                return false;
            }

            return true;
        }

        private void Guardar()
        {
            Archivo obj = new Archivo();

            obj.nombre_proceso = this.txtNombreArchivo.Text.Trim();
            obj.id_estructura = Convert.ToInt32(this.cmbEstructura.SelectedValue);
            obj.codigo = this.txtCodigo.Text.Trim();

            FArchivo objF = new FArchivo();

            String s = objF.Guardar(obj);

            if (s != String.Empty)
            {
                Mensaje.MostrarMensaje(s, 2);
            }
            else
            {
                CargarForm();
            }
        }

        private void Actualizar()
        {
            Archivo obj = new Archivo();

            obj.nombre_proceso = this.txtNombreArchivo.Text.Trim();
            obj.id = this.id;
            obj.id_estructura = Convert.ToInt32(this.cmbEstructura.SelectedValue);
            obj.codigo = this.txtCodigo.Text.Trim();

            FArchivo objF = new FArchivo();

            String s = objF.Actualizar(obj);
        }

        private void frmArchivo_Load(object sender, EventArgs e)
        {
            CargarForm();
        }

        private void CargarForm()
        {
            FEstructura objF = new FEstructura();

            this.cmbEstructura.DataSource = objF.Listar();
            this.cmbEstructura.ValueMember = "id";
            this.cmbEstructura.DisplayMember = "nombre";

            ListarArchivos();

            this.txtNombreArchivo.Focus();
        }

        private void lstArchivos_Click(object sender, EventArgs e)
        {
            insercion = false;


            Archivo obj = (Archivo)(this.lstArchivos.SelectedItem);

            this.txtNombreArchivo.Text = obj.nombre_proceso;            
            this.id = obj.id;
            this.txtCodigo.Text = obj.codigo;
            this.cmbEstructura.SelectedValue = obj.id_estructura;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Formato.ValidaEntero(e.KeyChar.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (insercion)
            {
                Mensaje.MostrarMensaje("Debe elegir un registro.", 1);
            }
            else
            {
                Archivo obj = (Archivo)(this.lstArchivos.SelectedItem);

                FArchivo objF = new FArchivo();

                String s = objF.Eliminar(obj);

                if (s != String.Empty)
                {
                    Mensaje.MostrarMensaje(s, 2);
                }
                else
                {
                    ListarArchivos();
                    LimpiarFormulario();
                }
            }
        }


    }
}
