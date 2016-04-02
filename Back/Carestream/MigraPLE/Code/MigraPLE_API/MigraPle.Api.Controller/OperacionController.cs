using System;
using MigraPle.Api.Controller.Interface;
using MigraPle.Api.Processor.Interface;
using MigraPle.Api.Utilities.Interfaces;
using MigraPle.DataAccess.Repository;
using MigraPle.Model.Entities;

namespace MigraPle.Api.Controller
{
    public class OperacionController : IOperacionController
    {
        private readonly IFileUtilities _fileUtilities;
        private readonly IFileProcessor _fileProccesor;
        private readonly IOperacionRepository _operacionRepository;

        public OperacionController(IFileUtilities fileUtilities, IFileProcessor fileProccesor, IOperacionRepository operacionRepository)
        {
            _fileUtilities = fileUtilities;
            _fileProccesor = fileProccesor;
            _operacionRepository = operacionRepository;
        }

        public void ImportArchivo(int idArchivo, string ruta,DateTime periodo)
        {
            var operacion = new Operacion
            {
                FechaOperacion = DateTime.Now,
                IdArchivo = idArchivo,
                InfoImport = _fileProccesor.ImportProcess(ruta),
                Nombre =  _fileUtilities.GetNombreArchivo(ruta),
                Periodo = periodo,
                TipoOperacion = TipoOperacion.Import
            };

            _operacionRepository.InsertOperacion(operacion);
        }

        public string ExportArchivo(int idArchivo, DateTime periodo)
        {
            throw new NotImplementedException();
        }
    }
}