using AuthApi.DTOs.CategoriaDTOs;
using AuthApi.Entidades;
using AuthApi.Interfaces;

namespace AuthApi.Servicios
{

    public class CategoriahjService : ICategoriahjService
    {
        private readonly ICategoriahjRepository _repo;

        public CategoriahjService(ICategoriahjRepository repo) => _repo = repo;

        public async Task<List<CategoriaResponsehjDTO>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(x => new CategoriaResponsehjDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            }).ToList();

        public async Task<CategoriaResponsehjDTO?> GetByIdAsync(int id)
        {
            var x = await _repo.GetByIdAsync(id);
            return x == null ? null : new CategoriaResponsehjDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            };
        }

        public async Task<CategoriaResponsehjDTO> CreateAsync(CategoriaCreatehjDTO dto)
        {
            var entity = new Categoriahj { Nombre = dto.Nombre.Trim(), Descripcion = dto.Descripcion.Trim() };
            var saved = await _repo.AddAsync(entity);
            return new CategoriaResponsehjDTO { Id = saved.Id, Nombre = saved.Nombre, Descripcion = saved.Descripcion };
        }

        public async Task<bool> UpdateAsync(int id, CategoriaUpdatehjDTO dto)
        {
            var current = await _repo.GetByIdAsync(id);
            if (current == null) return false;
            current.Nombre = dto.Nombre.Trim();
            current.Descripcion = dto.Descripcion.Trim();
            return await _repo.UpdateAsync(current);
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }

}
