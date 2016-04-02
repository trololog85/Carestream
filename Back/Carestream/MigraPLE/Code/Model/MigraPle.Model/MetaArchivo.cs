using System.Collections.Generic;

namespace MigraPle.Model.Entities
{
    public class MetaArchivo
    {
        public int Id { get; set; }
        public string Campo { get; set; }
        public int Indice { get; set; }
        public string CampoImport { get; set; }
        public IEnumerable<Regla> Reglas { get; set; }
        public bool EsFijo { get; set; }
        public string ValorFijo { get; set; }
    }
}
