using System;
using System.Net.Http;
using System.Threading.Tasks;
using MigraPle.Model.Entities;
using MigraPle.Windows.Proxy;

namespace MigraPle.Windows.Facade
{
    public class LoginFacade : ILoginFacade
    {
        private readonly ILoginProxy _loginProxy;
        private readonly IConnectionProxy _connectionProxy;

        public LoginFacade():this(new LoginProxy(),new ConnectionProxy())
        {
            
        }

        private LoginFacade(ILoginProxy loginProxy, IConnectionProxy connectionProxy)
        {
            _loginProxy = loginProxy;
            _connectionProxy = connectionProxy;
        }

        public bool AuthenticateUser(Login login)
        {
            return _loginProxy.AuthenticateUser(login).Result;
        }

        public async Task<bool> TestConnection()    
        {
            var response = await _connectionProxy.GetSession();

            DateTime date;

            return DateTime.TryParse(response, out date);
        }
    }
}