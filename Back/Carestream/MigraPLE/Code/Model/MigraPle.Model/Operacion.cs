using System;

namespace MigraPle.Model.Entities
{
    public class Operacion
    {
        public int Id { get; set; }
        public int IdArchivo { get; set; }
        public string NombreArchivo { get; set; }
        public DateTime FechaOperacion { get; set; }
        public TipoOperacion TipoOperacion { get; set; }
        public DateTime Periodo { get; set; }
    }
}
