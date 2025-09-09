using AuthApi.DTOs.CategoriaDTOs;

namespace AuthApi.Interfaces
{
    public interface ICategoriahjService
    {
        Task<List<CategoriaResponsehjDTO>> GetAllAsync();
        Task<CategoriaResponsehjDTO?> GetByIdAsync(int id);
        Task<CategoriaResponsehjDTO> CreateAsync(CategoriaCreatehjDTO dto);
        Task<bool> UpdateAsync(int id, CategoriaUpdatehjDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
