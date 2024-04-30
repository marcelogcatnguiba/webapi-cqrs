using WebApiCQRS.Domain.Entities;

namespace WebApiCQRS.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetUsuarioByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
        Task CreateAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}