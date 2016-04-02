using System.Windows;

namespace MigraPle.Api.Windows.Utils.Interfaces
{
    public interface IWindowsUtils
    {
        void OpenWindow(Window window);
        void OpenDialog(Window window);
        string SelectFile();
        void CopyToShared(string path);
    }
}
