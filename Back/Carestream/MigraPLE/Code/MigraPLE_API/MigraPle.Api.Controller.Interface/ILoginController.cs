using System;
using MigraPle.Model.Entities;

namespace MigraPle.Api.Controller.Interface
{
    public interface ILoginController
    {
        bool AuthenticateUser(Login login);
        DateTime GetSession();
    }
}