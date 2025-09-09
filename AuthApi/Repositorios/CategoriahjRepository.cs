using AuthApi.Entidades;
using AuthApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Repositorios
{
    public class CategoriahjRepository : ICategoriahjRepository
    {
        private readonly AppDbContext _context;

        public CategoriahjRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoriahj>> GetAllAsync()
            => await _context.Categorias.AsNoTracking().ToListAsync();

        public async Task<Categoriahj?> GetByIdAsync(int id)
            => await _context.Categorias.FindAsync(id);

        public async Task<Categoriahj> AddAsync(Categoriahj entity)
        {
            _context.Categorias.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Categoriahj entity)
        {
            _context.Categorias.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Categorias.FindAsync(id);
            if (existing == null) return false;
            _context.Categorias.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
