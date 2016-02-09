using System.Collections.Generic;
using System.Windows.Documents;

namespace Carestream.AdmTramas.Model.Entities
{
    public class ExportResult
    {
        public string Message { get; set; }
        public List<Error> Errores { get; set; }
    }
}