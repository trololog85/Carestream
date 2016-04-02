using System.Threading.Tasks;
using System.Windows;
using MigraPle.Api.Windows.Utils;
using MigraPle.Api.Windows.Utils.Interfaces;
using MigraPle.Windows.Facade;
using MigraPle.Windows.Process;

namespace MigraPle.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILoginFacade _loginFacade;
        private readonly IArchivoFacade _archivoFacade;
        private readonly IMasterEntitiesFacade _masterEntitiesFacade;
        private readonly IWindowsUtils _windowsUtils;

        private MainWindow(ILoginFacade loginFacade, IWindowsUtils windowsUtils,
            IArchivoFacade archivoFacade, IMasterEntitiesFacade masterEntitiesFacade)
        {
            _loginFacade = loginFacade;
            _windowsUtils = windowsUtils;
            _archivoFacade = archivoFacade;
            _masterEntitiesFacade = masterEntitiesFacade;
            InitializeComponent();
        }

        public MainWindow():this(new LoginFacade(),new WindowsUtils(),new ArchivoFacade(),new MasterEntitiesFacade())
        {
            InitializeComponent();
        }

        private async void winMain_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => InitializeWindow());
            await Task.Run(() => GetGlobalParameters());
        }

        private void MenuImport_Click(object sender, RoutedEventArgs e)
        {
            _windowsUtils.OpenWindow(new Import());
        }

        private void MenuExport_Click(object sender, RoutedEventArgs e)
        {
            _windowsUtils.OpenWindow(new Export());
        }
    }
}
