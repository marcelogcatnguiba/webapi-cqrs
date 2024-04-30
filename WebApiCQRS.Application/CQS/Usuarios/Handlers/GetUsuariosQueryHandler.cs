using MediatR;
using WebApiCQRS.Application.CQS.Usuarios.Queries;
using WebApiCQRS.Domain.Entities;
using WebApiCQRS.Domain.Interfaces;

namespace WebApiCQRS.Application.CQS.Usuarios.Handlers
{
    public class GetUsuariosQueryHandler : IRequestHandler<GetUsuariosQuery, IEnumerable<Usuario>>
    {
        private readonly IUsuarioRepository _repository;
        public GetUsuariosQueryHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Usuario>> Handle(GetUsuariosQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetUsuariosAsync();
        }
    }
}