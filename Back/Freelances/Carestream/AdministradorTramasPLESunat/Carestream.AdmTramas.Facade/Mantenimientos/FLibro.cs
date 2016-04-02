using System;
using System.Collections.Generic;
using System.Linq;
using Carestream.AdmTramas.Converter;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository;
using Carestream.AdmTramas.Facade.Generator.Interface;

namespace Carestream.AdmTramas.Facade.Mantenimientos
{
    public class FLibro : IFLibro
    {
        public IEnumerable<Model.Entities.Libro> Listar()
        {
            var objDA = new DALibro(new AdmTramasContainer());

            var lstLibros = new List<Libro>();

            try
            {
                lstLibros = objDA.Listar();
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }

            var lst = lstLibros.Select(LibroConverter.Convert).ToList();

            lst.Insert(0, new Model.Entities.Libro {Codigo = "",Id = 0,Nombre = "Elija Libro"});

            return lst;
        }
    }
}
