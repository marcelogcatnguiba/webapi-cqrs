using MediatR;
using WebApiCQRS.Domain.Entities;

namespace WebApiCQRS.Application.CQS.Usuarios.Commands
{
    public abstract class UsuarioCommand : IRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
    }
}