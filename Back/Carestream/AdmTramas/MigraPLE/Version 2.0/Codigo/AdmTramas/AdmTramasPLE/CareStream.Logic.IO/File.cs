using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace CareStream.Logic.IO
{
    public class File
    {
        public static String AbrirArchivo()
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
                return fi.FileName;
            }
            else
            {
                return String.Empty;
            }
        }

        public static String AbrirRuta()
        {
            FolderBrowserDialog fi = new FolderBrowserDialog();
            fi.SelectedPath = @"\\";
            fi.ShowNewFolderButton = true;
            fi.Description = "Elija un directorio.";

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

        public static String AbrirArchivo(String ruta)
        {
            FileDialog fi = new OpenFileDialog();
            fi.CheckFileExists = true;
            fi.CheckPathExists = true;
            fi.Title = "Seleccione el archivo";
            fi.Filter = "Excel|*.xlsx;*.xls";
            fi.InitialDirectory = ruta;

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

        public static void Inserta(String mensaje, String ruta)
        {
            using (FileStream fs = new FileStream(ruta, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                {
                    sw.WriteLine(mensaje);
                }
            }
        }

        public static void Inserta(List<String> mensaje, String ruta)
        {
            using (FileStream fs = new FileStream(ruta, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                {
                    Int32 total = mensaje.Count;
                    Int32 contador = 1;

                    foreach (String s in mensaje)
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

        public static void EliminarArchivo(String ruta)
        {
            FileInfo fi = new FileInfo(ruta);

            if (fi.Exists)
            {
                fi.Delete();
            }
        }
    }
}
