using System;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Model.Tipos;

namespace Carestream.AdmTramas.Converter
{
    public class LibroConverter
    {
        public static Libro Convert(DataAccess.Model.Libro libro)
        {
            return new Libro
            {
                Codigo = libro.Codigo,
                Id = libro.Id,
                Nombre = libro.Nombre
            };
        }

        public static TipoLibro ConvertTipoLibro(string codigo)
        {
            switch (codigo)
            {
                case "140100":
                    return TipoLibro.Ventas;
                case "080100":
                    return TipoLibro.Compras;
                case "050100":
                    return TipoLibro.LibroDiario;
                case "050200":
                    return TipoLibro.LibroDiarioDetalle;
                case "060100":
                    return TipoLibro.LibroMayor;
                default:
                    throw new ArgumentOutOfRangeException("codigo");
            }
        }
    }
}
