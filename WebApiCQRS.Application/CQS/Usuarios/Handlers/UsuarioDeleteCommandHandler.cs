using MediatR;
using WebApiCQRS.Application.CQS.Usuarios.Commands;
using WebApiCQRS.Domain.Interfaces;

namespace WebApiCQRS.Application.CQS.Usuarios.Handlers
{
    public class UsuarioDeleteCommandHandler : IRequestHandler<UsuarioDeleteCommand>
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioDeleteCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UsuarioDeleteCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}