using System.Xml.Linq;
using WsApiexamen.Dto;
using WsApiexamen.Models;
using WsApiexamen.Repositorios;

namespace WsApiexamen.Servicios
{
    public class ExamenServicio : IExamenServicio
    {
        private readonly IExamenRepositorio _repositorio;

        public ExamenServicio(IExamenRepositorio repositorio)
        { _repositorio = repositorio; }
        public async Task AddExamen(Examen examen)
        {
          

            await _repositorio.AddExamen(examen);
        }

        public async Task DeleteById(Examen examen)
        {
            await _repositorio.DeleteById(examen);
        }

        public async Task<ICollection<Examen>> GetAll(string? nombre, string? descripcion)
        {
            return await _repositorio.GetAll(nombre, descripcion);
        }

        public async Task<Examen?> GetExamenById(int id)
        {
            return await _repositorio.GetById(id);
        }

        public async Task<bool> Update(int id, ExamenPutDto examenPutDto)
        {
            var examen = await _repositorio.GetById(id);
            if (examen == null)

                return false;
            examen.Nombre = examenPutDto.Nombre;

            examen.Descripcion = examenPutDto.Descripcion;

            await _repositorio.SaveChanges();
            return true;
        }
    }
}
