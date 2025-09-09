using AuthApi.Entidades;

namespace AuthApi.Interfaces
{
    public interface ICategoriahjRepository
    {
        Task<List<Categoriahj>> GetAllAsync();
        Task<Categoriahj?> GetByIdAsync(int id);
        Task<Categoriahj> AddAsync(Categoriahj entity);
        Task<bool> UpdateAsync(Categoriahj entity);
        Task<bool> DeleteAsync(int id);
    }
}
