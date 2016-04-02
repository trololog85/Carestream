using System;
using System.Collections.Generic;
using System.Linq;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository.Interfaces;

namespace Carestream.AdmTramas.DataAccess.Repository
{
    public class DACodigoDetalle:ICodigoDetalleRepository
    {
        private readonly AdmTramasContainer context;
        private bool disposed = false;

        public DACodigoDetalle(AdmTramasContainer context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public List<CodigoDetalle> Listar(short tipo)
        {
            using (context)
            {
                return context.ListarCodigoDetalle(tipo).ToList();
            }
        }
    }
}
