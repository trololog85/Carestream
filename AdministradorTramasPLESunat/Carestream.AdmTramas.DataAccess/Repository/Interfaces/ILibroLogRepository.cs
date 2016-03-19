using System;
using System.Collections.Generic;
using Carestream.AdmTramas.DataAccess.Model;

namespace Carestream.AdmTramas.DataAccess.Repository.Interfaces
{
    public interface ILibroLogRepository
    {
        List<LibroLog> Listar(string tipoLog);
        List<RegistroVenta> ConsultaImportVentas(int idLibroLog);
        List<LibroDiario> ConsultaLibroDiario(int idLibroLog);
        List<LibroDiario> ConsultaLibroDiarioPorPeriodo(DateTime periodo);
        List<RegistroCompra> ConsultaRegistroCompras(int idLibroLog);
        List<LibroMayor> ConsultaLibroMayor(int idLibroLog);
        List<LibroDiarioDetalle> ConsultaLibroDiarioDetalle(int idLibroLog);
        List<RegistroNoDomiciliado> ConsultaLibroNoDomiciliado(int idLibroLog);
        int Guardar(LibroLog libroLog);
        void GuardarDetalleImportVentas(List<RegistroVenta> lstRegistroVentas);
        void GuardarDetalleImportCompras(List<RegistroCompra> lstRegistroCompras);
        void GuardarDetalleImportDiario(List<LibroDiario> lstLibroDiarios);
        void GuardarDetalleImportMayor(List<LibroMayor> lstLibroMayor);
        void GuardarDetalleImportDiarioDetalle(List<LibroDiarioDetalle> detalle4);
        void GuardarDetalleNoDomicialado(List<RegistroNoDomiciliado> detalle5);
    }
}
