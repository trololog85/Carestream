using System;
using Version = Carestream.AdmTramas.Model.Tipos.Version;

namespace Carestream.AdmTramas.Converter
{
    public class VersionConverter
    {
        public static Version Convert(string version)
        {
            switch (version)
            {
                case "3.0":
                    return Version.V30;
                case "3.1":
                    return Version.V31;
                case "4.0":
                    return Version.V40;
                default:
                    return Version.V40;
            }
        }
    }
}
