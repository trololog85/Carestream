using System;
using System.Collections.Generic;
using Carestream.AdmTramas.DataAccess.Model;

namespace Carestream.AdmTramas.DataAccess.Repository.Interfaces
{
    public interface IEstructuraRepository : IDisposable
    {
        List<Estructura> Listar();
        void Guardar(Estructura estructura);
        void Actualizar(Estructura estructura);
        void Eliminar(int id);
        int ObtieneMaximoID();
    }
}
