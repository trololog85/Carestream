using System.Windows;
using MigraPle.Api.Windows.Resolver;


namespace MigraPle.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /*protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer kernel = new UnityContainer();
            var resolver = new KernelResolver();

            resolver.ConfigureKernel(kernel);

            var window = kernel.Resolve<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }*/
    }
}
