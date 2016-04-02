using System.Windows;
using MigraPle.Windows.Facade;

namespace MigraPle.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly ILoginFacade _loginFacade;

        public Login(ILoginFacade loginFacade)
        {
            _loginFacade = loginFacade;
            InitializeComponent();
        }

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
