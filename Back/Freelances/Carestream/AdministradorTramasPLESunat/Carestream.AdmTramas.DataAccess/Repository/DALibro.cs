using System;
using System.Collections.Generic;
using System.Linq;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository.Interfaces;

namespace Carestream.AdmTramas.DataAccess.Repository
{
    public class DALibro:ILibroRepository,IDisposable
    {
        private readonly AdmTramasContainer context;
        private bool disposed = false;

        public DALibro(AdmTramasContainer context)
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

        public List<Libro> Listar()
        {
            using (context)
            {
                return context.ListarLibros().ToList();
            }
        }

        public void Guardar(Libro libro)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(Libro libro)
        {
            throw new NotImplementedException();
        }

        public int ObtieneLibroxCod(string codigo)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int cod)
        {
            throw new NotImplementedException();
        }
    }
}
