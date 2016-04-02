using System.Collections.Generic;

namespace Carestream.AdmTramas.Facade.Generator.Interface
{
    public interface ICodigoDetalle
    {
        IEnumerable<Model.Entities.CodigoDetalle> Listar(short tipo);
    }
}
