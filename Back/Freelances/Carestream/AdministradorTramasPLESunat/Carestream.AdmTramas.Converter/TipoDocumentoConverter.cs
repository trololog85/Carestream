using Carestream.AdmTramas.Model.Tipos;

namespace Carestream.AdmTramas.Converter
{
    public class TipoDocumentoConverter
    {
        public static TipoDocumento Convert(string tipoDocumento)
        {
            switch (tipoDocumento)
            {
                case "0":
                    return TipoDocumento.Otros;
                case "1":
                    return TipoDocumento.LibretaElectoral;
                case "4":
                    return TipoDocumento.CarnetExtranjeria;
                case "6":
                    return TipoDocumento.RegUnicoContribuyente;
                case "7":
                    return TipoDocumento.Pasaporte;
                case "A":
                    return TipoDocumento.CedulaDiplomatica;
            }

            return TipoDocumento.Otros;
        }
    }
}
