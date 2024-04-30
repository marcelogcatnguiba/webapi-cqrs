using Microsoft.EntityFrameworkCore;
using WebApiCQRS.Data.Context;
using WebApiCQRS.Domain.Entities;
using WebApiCQRS.Domain.Interfaces;

namespace WebApiCQRS.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApiContext _context;

        public UsuarioRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task CreateAsync(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateAsync(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                var usuarioDelete = _context.Usuarios.FirstOrDefault(x => x.Id.Equals(id));
                _context.Usuarios.Remove(usuarioDelete!);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}