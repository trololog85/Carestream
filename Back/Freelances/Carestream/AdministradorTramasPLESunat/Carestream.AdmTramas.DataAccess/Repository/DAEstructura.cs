using System;
using System.Collections.Generic;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository.Interfaces;

namespace Carestream.AdmTramas.DataAccess.Repository
{
    public class DAEstructura:IEstructuraRepository
    {
        private AdmTramasContainer context;

        private bool disposed = false;
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

        public List<Estructura> Listar()
        {
            var lst = new List<Estructura>();

            using (context)
            {
                return null;
            }
        }

        public void Guardar(Estructura estructura)
        {
            throw new System.NotImplementedException();
        }

        public void Actualizar(Estructura estructura)
        {
            throw new System.NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public int ObtieneMaximoID()
        {
            throw new System.NotImplementedException();
        }
    }
}
