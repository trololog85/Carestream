using System.Collections.Generic;

namespace MigraPle.Model.Entities
{
    public class Archivo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public IEnumerable<MetaArchivo> MetaArchivo { get; set; }
    }
}
