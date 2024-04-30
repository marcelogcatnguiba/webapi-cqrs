using MediatR;
using WebApiCQRS.Application.CQS.Usuarios.Commands;
using WebApiCQRS.Domain.Entities;
using WebApiCQRS.Domain.Interfaces;

namespace WebApiCQRS.Application.CQS.Usuarios.Handlers
{
    public class UsuarioUpdateCommandHandle : IRequestHandler<UsuarioUpdateCommand>
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioUpdateCommandHandle(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UsuarioUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = new Usuario(request.Nome, request.Idade) { Id = request.Id };
            await _repository.UpdateAsync(user);
        }
    }
}