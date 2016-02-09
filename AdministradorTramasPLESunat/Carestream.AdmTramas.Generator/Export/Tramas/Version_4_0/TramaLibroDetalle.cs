using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Export.Tramas.Version_4_0
{
    public class TramaLibroDetalle
    {
        private readonly string separador = ConfigurationManager.AppSettings["separador"];

        public void GeneraTrama(List<LibroDiarioDetalle> registros, RutaArchivo ruta)
        {
            var trama = new List<string>();
            string linea = null;

            foreach (var registro in registros)
            {
                linea = ArmaEstructura(registro);
                trama.Add(linea);
            }

            Archivo.GuardarTrama(trama, ruta);
        }

        private string ArmaEstructura(LibroDiarioDetalle libroDiarioDetalle)
        {
            var trama = new StringBuilder();

            var fechaPeriodo = Formato.FormateaFecha("AAAAMM00", libroDiarioDetalle.FechaPeriodo);
            var codigoCuentaContable = libroDiarioDetalle.CodigoCuentaContable;
            var descripcionCuentaContable = libroDiarioDetalle.DescripcionCuentaContable;
            var codigoPlanCuenta = libroDiarioDetalle.CodigoPlanCuenta;
            var descripcionPlanCuenta = libroDiarioDetalle.DescripcionPlanCuenta;
            var estado = libroDiarioDetalle.Estado;

            trama.Append(fechaPeriodo);
            trama.Append(separador);
            trama.Append(codigoCuentaContable);
            trama.Append(separador);
            trama.Append(descripcionCuentaContable);
            trama.Append(separador);
            trama.Append(codigoPlanCuenta);
            trama.Append(separador);
            trama.Append(descripcionPlanCuenta);
            trama.Append(separador);
            trama.Append(estado);

            return trama.ToString();
        }
    }
}
