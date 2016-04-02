using System.Threading.Tasks;
using MigraPle.Model.Entities;

namespace MigraPle.Windows.Proxy
{
    public interface ILoginProxy
    {
        Task<bool> AuthenticateUser(Login login);
    }
}
