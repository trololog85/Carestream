
using System.Windows.Forms;

namespace Carestream.AdmTramas.Utils
{
    public class Mensaje
    {
        public enum TipoMensaje
        {
            Informacion = 0,
            Error = 1
        };


        public static void MostrarMensaje(string mensaje, TipoMensaje tipo)
        {
            switch (tipo)
            {
                //Aviso
                case TipoMensaje.Informacion:
                    MessageBox.Show(mensaje, "Administrador de Tramas PLE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                //Error
                case TipoMensaje.Error:
                    MessageBox.Show(mensaje, "Administrador de Tramas PLE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
