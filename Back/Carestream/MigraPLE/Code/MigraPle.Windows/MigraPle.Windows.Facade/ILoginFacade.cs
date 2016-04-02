using System.Threading.Tasks;
using MigraPle.Model.Entities;

namespace MigraPle.Windows.Facade
{
    public interface ILoginFacade
    {
        bool AuthenticateUser(Login login);
        Task<bool> TestConnection();
    }
}
