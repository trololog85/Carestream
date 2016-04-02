using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using MigraPle.Api.Configurations;
using MigraPle.Api.Windows.Utils.Entities;
using MigraPle.Api.Windows.Utils.Interfaces;
using MessageBox = System.Windows.MessageBox;

namespace MigraPle.Api.Windows.Utils
{
    public class WindowsUtils : IWindowsUtils
    {
        private readonly IConfigurationGetter _configurationGetter;

        private WindowsUtils(IConfigurationGetter configurationGetter)
        {
            _configurationGetter = configurationGetter;
        }

        public WindowsUtils():this(new ConfigurationGetter())
        {
            
        }

        public void OpenWindow(Window window)
        {
            window.Show();
            window.ShowActivated = true;
        }

        public void OpenDialog(Window window)
        {
            window.ShowDialog();
        }

        public string SelectFile()
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

        public void CopyToShared(string path)
        {
            var file = new FileInfo(path);

            var computerName = @"\\" + Common.GetMachineName();

            var destination = Path.Combine(_configurationGetter.GetConfiguration("ImportPath"), file.Name);

            file.CopyTo(computerName + destination, true);
        }

        public static void MostrarMensaje(string mensaje, TipoMensaje tipo)
        {
            switch (tipo)
            {
                //Aviso
                case TipoMensaje.Informacion:
                    MessageBox.Show(mensaje,"Migra PLE",MessageBoxButton.OK,MessageBoxImage.Information);
                    break;
                //Error
                case TipoMensaje.Error:
                    MessageBox.Show(mensaje, "Migra PLE", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case TipoMensaje.Validacion:
                    MessageBox.Show(mensaje, "Migra PLE", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    break;
            }
        }

        public static void MostrarMensaje(Exception exception)
        {
            var pre = "Ocurrio una excepcion:";
            var innerException = exception.InnerException;
            var message = exception.Message;
            var source = exception.StackTrace;

            var mensaje = pre + Environment.NewLine + innerException + Environment.NewLine + message + Environment.NewLine + source;

            MessageBox.Show(mensaje, "Migra PLE", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}