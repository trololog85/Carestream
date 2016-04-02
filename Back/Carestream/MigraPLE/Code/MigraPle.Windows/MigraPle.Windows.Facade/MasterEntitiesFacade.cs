using MigraPle.Api.Windows.Utils;
using MigraPle.Api.Windows.Utils.Interfaces;

namespace MigraPle.Windows.Facade
{
    public class MasterEntitiesFacade : IMasterEntitiesFacade
    {
        private readonly IMetaInfoProvider _xmlMetaInfoProvider;

        private MasterEntitiesFacade(IMetaInfoProvider xmlMetaInfoProvider)
        {
            _xmlMetaInfoProvider = xmlMetaInfoProvider;
        }

        public MasterEntitiesFacade():this(new XmlMetaInfoProvider())
        {
            
        }

        public void GetMetaData()
        {
            Globals.Monedas = _xmlMetaInfoProvider.GetMetaData("Monedas.xml");
            Globals.Meses = _xmlMetaInfoProvider.GetMetaData("Meses.xml");
            Globals.LibroRegistro = _xmlMetaInfoProvider.GetMetaData("LibroRegistro.xml");
            Globals.IndicadorOperaciones = _xmlMetaInfoProvider.GetMetaData("IndicadorOperacion.xml");
        }
    }
}