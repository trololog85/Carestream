using System.Collections.Generic;
using MigraPle.Api.Windows.Utils.Entities;
using MigraPle.Model.Entities;

namespace MigraPle.Api.Windows.Utils
{
    public class Globals
    {
        public static IEnumerable<Archivo> Archivos { get; set; }
        public static IEnumerable<Combo> Monedas { get; set; }
        public static IEnumerable<Combo> Meses { get; set; }
        public static IEnumerable<Combo> LibroRegistro { get; set; }
        public static IEnumerable<Combo> IndicadorOperaciones { get; set; }
    }
}