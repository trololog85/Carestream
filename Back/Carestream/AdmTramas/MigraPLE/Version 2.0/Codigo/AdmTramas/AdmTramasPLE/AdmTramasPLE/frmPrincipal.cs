using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdmTramasPLE.Mantenimientos;
using AdmTramasPLE.Archivos;

namespace AdmTramasPLE
{
    public partial class frmPrincipal : Form
    {
        private frmArchivo objfrmArchivo;
        private frmEstructura objFrmEstructura;
        private frmRegVentas objFrmRegVentas;
        private frmRegCompras objFrmRegCompras;
        private Info objFrmInfo;
        private frmArchivosMain objFrmArchivoMain;

        private Boolean NoEstaCreado(Form obj)
        {
            return (obj == null || obj.IsDisposed);
        }

        private void MostrarForm(Form obj)
        {
            obj.Show();
            obj.MdiParent = this;
            obj.Activate();
        }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void tsmiArchivos_Click(object sender, EventArgs e)
        {
            if (NoEstaCreado(objfrmArchivo))
            {
                objfrmArchivo = new frmArchivo();
            }

            MostrarForm(objfrmArchivo);
        }

        private void tsmiEstructura_Click(object sender, EventArgs e)
        {
            if (NoEstaCreado(objFrmEstructura))
            {
                objFrmEstructura = new frmEstructura();
            }

            MostrarForm(objFrmEstructura);
        }

        private void acercaTsmi_Click(object sender, EventArgs e)
        {
            if (NoEstaCreado(objFrmInfo))
            {
                objFrmInfo = new Info();
            }

            MostrarForm(objFrmInfo);
        }

        private void importYExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NoEstaCreado(objFrmArchivoMain))
            {
                objFrmArchivoMain = new frmArchivosMain();
            }

            MostrarForm(objFrmArchivoMain);
        }
    }
}
