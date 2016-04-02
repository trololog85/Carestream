using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Utils
{
    public class Archivo
    {
        public static string SeleccionarArchivo()
        {
            var fi = new OpenFileDialog
                     {
                         CheckFileExists = true,
                         CheckPathExists = true,
                         Title = "Seleccione el archivo",
                         Filter = "Excel|*.xlsx;*.xls",
                         InitialDirectory = @"\\"
                     };

            DialogResult dr = fi.ShowDialog();

            if (dr == DialogResult.OK) 
                return fi.FileName;

            return string.Empty;
        }



        public static string SeleccionarRuta()
        {
            var fi = new FolderBrowserDialog
                     {
                         SelectedPath = @"\\",
                         ShowNewFolderButton = true,
                         Description = "Elija un directorio."
                     };

            DialogResult dr = fi.ShowDialog();

            if (dr == DialogResult.OK)
            {
                return fi.SelectedPath;
            }
            else
            {
                return String.Empty;
            }
        }

        public static string SeleccionarArchivo(String ruta)
        {
            var fi = new OpenFileDialog
                     {
                         CheckFileExists = true,
                         CheckPathExists = true,
                         Title = "Seleccione el archivo",
                         Filter = "Excel|*.xlsx;*.xls",
                         InitialDirectory = ruta
                     };

            DialogResult dr = fi.ShowDialog();

            if (dr == DialogResult.OK)
            {
                return fi.FileName;
            }
            else
            {
                return String.Empty;
            }
        }

        public static void Inserta(string mensaje, string ruta)
        {
            using (var fs = new FileStream(ruta, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                using (var sw = new StreamWriter(fs, Encoding.Default))
                {
                    sw.WriteLine(mensaje);
                }
            }
        }

        public static void Inserta(List<string> mensaje, string ruta)
        {
            using (var fs = new FileStream(ruta, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                using (var sw = new StreamWriter(fs, Encoding.Default))
                {
                    var total = mensaje.Count;
                    var contador = 1;

                    foreach (var s in mensaje)
                    {
                        if (contador == total)
                        {
                            sw.Write(s);
                        }
                        else
                        {
                            sw.WriteLine(s);
                        }

                        contador++;
                    }
                }
            }
        }

        public static void EliminarArchivo(string ruta)
        {
            var fi = new FileInfo(ruta);

            if (fi.Exists)
            {
                fi.Delete();
            }
        }

        public static string ObtieneNombreArchivo(string ruta)
        {
            var fi = new FileInfo(ruta);

            return fi.Name;
        }

        public static void GuardarTrama(List<string> trama, RutaArchivo rutaArchivo)
        {
            var ruta = String.Format(@"{0}\{1}", rutaArchivo.Ruta, rutaArchivo.NombreArchivo);

            Inserta(trama, ruta);
        }

        public static void OpenPath(string path)
        {
            System.Diagnostics.Process.Start("explorer.exe",path);
        }
    }
}
