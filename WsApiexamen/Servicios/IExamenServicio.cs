using WsApiexamen.Dto;
using WsApiexamen.Models;

namespace WsApiexamen.Servicios
{
    public interface IExamenServicio
    {
        public Task AddExamen(Examen examen);
        public Task<Examen?> GetExamenById(int id);

        public Task DeleteById(Examen examen);

        public Task<ICollection<Examen>> GetAll(string? nombre, string? descripcion);

        public Task<bool> Update(int id, ExamenPutDto examenPutDto);
    }
}
