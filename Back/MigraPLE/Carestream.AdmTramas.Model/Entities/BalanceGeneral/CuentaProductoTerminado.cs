namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class CuentaProductoTerminado
    {
        public long FechaPeriodo { get; set; }
        public short CodigoCatalogo { get; set; }
        public short TipoExistencia { get; set; }
        public string CodigoPropioExistencia { get; set; }
        public long CodigoExistencia { get; set; }
        public string DescripcionExistencia { get; set; }
        public string CodigoUnidadExistencia { get; set; }
        public short CodigoValuacion { get; set; }
        public double CantidadExistencia { get; set; }
        public double CostoUnitarioExistencia { get; set; }
        public double CostoTotal { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
