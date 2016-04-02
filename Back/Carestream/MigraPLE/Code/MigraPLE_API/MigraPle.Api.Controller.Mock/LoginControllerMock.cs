using System;
using MigraPle.Api.Configurations;
using MigraPle.Api.Controller.Interface;
using MigraPle.Model.Entities;

namespace MigraPle.Api.Controller.Mock
{
    public class LoginControllerMock:ILoginController
    {
        private readonly IConfigurationGetter _configurationGetter;

        public LoginControllerMock(IConfigurationGetter configurationGetter)
        {
            _configurationGetter = configurationGetter;
        }

        public bool AuthenticateUser(Login login)
        {
            var isValid = _configurationGetter.GetConfiguration("IsUserValid");

            return bool.Parse(isValid);
        }

        public DateTime GetSession()
        {
            return DateTime.Now;
        }
    }
}