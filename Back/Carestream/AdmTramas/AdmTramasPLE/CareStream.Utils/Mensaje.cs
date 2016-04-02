using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CareStream.Utils
{
    public class Mensaje
    {
        /// <summary>
        /// Muestra un mensaje
        /// </summary>
        /// <param name="mensaje">Texto a mostrar</param>
        /// <param name="tipo">Tipo de mensaje: 1=Informacion, 2=Error</param>
        public static void MostrarMensaje(String mensaje, Int16 tipo)
        {
            switch (tipo)
            { 
                //Aviso
                case 1:
                    MessageBox.Show(mensaje, "Administrador de Tramas PLE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                //Error
                case 2:
                    MessageBox.Show(mensaje, "Administrador de Tramas PLE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            
            }
        }

        /// <summary>
        /// Abre por el explorador de Windows un directorio
        /// </summary>
        /// <param name="ruta"></param>
        public static void AbrirFolder(String ruta)
        {
            Process.Start(ruta);
        }
    }
}
