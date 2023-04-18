using WsApiexamen.Models;

namespace WsApiexamen.Repositorios
{
    public interface IExamenRepositorio
    {
        public Task<int> AddExamen(Examen examen);

        public Task<Examen?> GetById(int id);
        public Task DeleteById(Examen examen);

        public Task<ICollection<Examen>> GetAll(string? nombre, string? descripcion);

        public Task SaveChanges();
    }
}
