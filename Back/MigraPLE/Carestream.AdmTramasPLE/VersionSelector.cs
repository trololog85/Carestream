using System;
using Carestream.AdmTramas.Facade.Generator.Export;
using Carestream.AdmTramas.Facade.Generator.Import;
using V30 = Carestream.AdmTramas.Generator.Import.Version_3_0;
using V40 = Carestream.AdmTramas.Generator.Import.Version_4_0;
using Version = Carestream.AdmTramas.Model.Tipos.Version;

namespace Carestream.AdmTramasPLE
{
    public class VersionSelector
    {
        public static FCargaLibro GetImport(Version version)
        {
            switch (version)
            {
                case Version.V40:
                    return new FCargaLibro
                        (new V40.ImportRegistroVenta(),
                        new V40.ImportRegistroCompras(),
                        new V40.ImportLibroMayor(),
                        new V40.ImportLibroDiario(),
                        new V40.ImportLibroDiarioDetalle());
                default:
                    throw new ArgumentOutOfRangeException("version");
            }
        }

        public static FGeneraLibro GetExport(Version version)
        {
            switch (version)
            {
                case Version.V40:
                    return new FGeneraLibro();
                default:
                    throw new ArgumentOutOfRangeException("version");
            }
        }
    }
}
