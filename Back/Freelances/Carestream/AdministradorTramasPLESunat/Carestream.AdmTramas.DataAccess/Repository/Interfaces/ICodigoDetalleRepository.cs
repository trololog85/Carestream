using System;
using System.Collections.Generic;
using Carestream.AdmTramas.DataAccess.Model;

namespace Carestream.AdmTramas.DataAccess.Repository.Interfaces
{
    public interface ICodigoDetalleRepository : IDisposable
    {
        List<CodigoDetalle> Listar(short tipo);
    }
}
