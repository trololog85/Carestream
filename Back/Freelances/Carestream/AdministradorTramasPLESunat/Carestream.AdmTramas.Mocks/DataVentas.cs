using System.Collections.Generic;
using Carestream.AdmTramas.Facade.Generator.Interface;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Model.Tipos;

namespace Carestream.AdmTramas.Mocks
{
    public class DataVentas
    {
        public IEnumerable<LibroLog> Listar(string tipoLog)
        {
            var librolog = new LibroLog
            {
                Id = 1,
                IdLibro = 1,
                IndicadorLibro = "1",
                IndicadorMoneda = "PEN",
                IndicadorOperacion = "1",
                NombreLibro = "prueba.xlsx",
                RUC = "20515033841",
                Registros = 20,
                TipoLog = "I",
                sFechaCarga = "2014-03-01",
                sFechaGeneracion = "1900-01-01"
            };

            var librolog1 = new LibroLog
            {
                Id = 1,
                IdLibro = 1,
                IndicadorLibro = "1",
                IndicadorMoneda = "PEN",
                IndicadorOperacion = "1",
                NombreLibro = "prueba1.xlsx",
                RUC = "20515033842",
                Registros = 20,
                TipoLog = "I",
                sFechaCarga = "2014-03-02",
                sFechaGeneracion = "1900-01-01"
            };

            var librolog2 = new LibroLog
            {
                Id = 1,
                IdLibro = 1,
                IndicadorLibro = "1",
                IndicadorMoneda = "PEN",
                IndicadorOperacion = "1",
                NombreLibro = "prueba2.xlsx",
                RUC = "20515033843",
                Registros = 20,
                TipoLog = "I",
                sFechaCarga = "2014-03-03",
                sFechaGeneracion = "1900-01-01"
            };

            return new List<LibroLog>() { librolog, librolog1, librolog2};
        }

        public string GuardarImport(TipoLibro tipoLibro, Import import)
        {
            throw new System.NotImplementedException();
        }
    }
}
