using Microsoft.EntityFrameworkCore;
using WsApiexamen.Models;

namespace WsApiexamen.Repositorios
{
    public class ExamenRepositorio : IExamenRepositorio
    {
        private readonly AplicationContext _context;
        public ExamenRepositorio(AplicationContext context) { _context = context; }
        public async Task<int> AddExamen(Examen examen)
        {
            await _context.Examenes.AddAsync(examen);

            return await _context.SaveChangesAsync();

        }

        public async Task<Examen?> GetById(int id)
        {
            return await _context.Examenes.FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task DeleteById(Examen examen)
        {
            _context.Examenes.Remove(examen);

            await _context.SaveChangesAsync();

        }
        public async Task<ICollection<Examen>> GetAll(string? nombre, string? descripcion)
        {
            var query = _context.Examenes as IQueryable<Examen>;
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query = query.Where(x => x.Nombre.StartsWith(nombre));
            }

              if (!string.IsNullOrWhiteSpace(descripcion))
                {
                query = query.Where(x => x.Descripcion.Contains (descripcion) );
                 }

            return await query.ToListAsync();
          
        }

        public async Task SaveChanges()
        { await _context.SaveChangesAsync(); }

    }
}
