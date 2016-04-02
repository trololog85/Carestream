using System;
using System.Threading.Tasks;

namespace MigraPle.Windows
{
    public partial class MainWindow
    {
        private async void InitializeWindow()
        {
            var result = await _loginFacade.TestConnection();

            this.Dispatcher.Invoke((Action)(() =>
            {
                if (result)
                    this.txtStatus.Text = "Conexion exitosa";
            }));
        }

        private async void GetGlobalParameters()
        {
            await Task.Run(()=>_archivoFacade.GetArchivos());
            await Task.Run(() => _masterEntitiesFacade.GetMetaData());
        }
    }
}