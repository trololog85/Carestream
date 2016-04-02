using System.Collections.Generic;

namespace Carestream.AdmTramas.Model.Tipos
{
    public class Result<T>
    {
        public List<T> Source { get; set; }
        public string Mensaje { get; set; }
    }
}