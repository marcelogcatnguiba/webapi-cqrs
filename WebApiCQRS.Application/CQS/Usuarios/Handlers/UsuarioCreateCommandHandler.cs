using MediatR;
using WebApiCQRS.Application.CQS.Usuarios.Commands;
using WebApiCQRS.Domain.Entities;
using WebApiCQRS.Domain.Interfaces;

namespace WebApiCQRS.Application.CQS.Usuarios.Handlers
{
    public class UsuarioCreateCommandHandler : IRequestHandler<UsuarioCreateCommand>
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioCreateCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new Usuario(request.Nome, request.Idade);
            await _repository.CreateAsync(user);
        }
    }
}