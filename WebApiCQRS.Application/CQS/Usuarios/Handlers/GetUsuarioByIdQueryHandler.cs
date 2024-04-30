using MediatR;
using WebApiCQRS.Application.CQS.Usuarios.Queries;
using WebApiCQRS.Domain.Entities;
using WebApiCQRS.Domain.Interfaces;

namespace WebApiCQRS.Application.CQS.Usuarios.Handlers
{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, Usuario?>
    {
        private readonly IUsuarioRepository _repository;
        public GetUsuarioByIdQueryHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<Usuario?> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUsuarioByIdAsync(request.Id);
        }
    }
}