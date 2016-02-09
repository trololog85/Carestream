using Carestream.AdmTramas.Generator.Import.Interface;
using Carestream.AdmTramas.Generator.Import.Version_4_0;
using Carestream.AdmTramas.Model.Entities;
using NUnit.Framework;

namespace Carestream.AdmTramas.Mocks
{
    [TestFixture]
    public class TestImports
    {
        [Test]
        public void ImportLibroDiario()
        {
            var import = new Import
            {
                Ruta = @"D:\Proyectos\Carestream\4.0\PLE\Carestream.AdmTramas.Mocks\Files\Version_4_0\LibroDiario.xlsx"
            };

            IImportLibroDiario f = new ImportLibroDiario();

            f.LeeRegistro(import);
        }
    }
}
