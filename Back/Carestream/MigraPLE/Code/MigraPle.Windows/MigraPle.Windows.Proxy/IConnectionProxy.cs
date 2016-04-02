using System.Threading.Tasks;

namespace MigraPle.Windows.Proxy
{
    public interface IConnectionProxy
    {
        Task<string> GetSession();
    }
}
