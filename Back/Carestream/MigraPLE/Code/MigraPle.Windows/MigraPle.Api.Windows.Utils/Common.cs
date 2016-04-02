using System;
using System.IO;
using System.Windows.Forms;

namespace MigraPle.Api.Windows.Utils
{
    public class Common
    {
        public static string GetCurrentPath(string extraPath)
        {
           var basePath = Path.GetDirectoryName(Application.ExecutablePath);

            if (string.IsNullOrEmpty(extraPath))
                return basePath;

            return basePath + extraPath;
        }

        public static string GetMachineName()
        {
            return Environment.MachineName;
        }

        public static DateTime GetDefaultDate()
        {
            return new DateTime(1900,1,1);
        }
    }
}
