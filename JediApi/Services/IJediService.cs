using JediApi.Models;

namespace JediApi.Services
{
    public interface IJediService
    {
        Task<Jedi> GetbyIdAsync(int id);
        Task<Jedi> GetAllAsync();
        Task<Jedi> addAsync(Jedi jedi);
        Task<bool> UpdadeteAsync(Jedi jedi);
        Task<bool> DeleteAsync(Jedi jedi);

    }
}
