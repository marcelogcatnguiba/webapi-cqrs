using MediatR;
using WebApiCQRS.Domain.Entities;

namespace WebApiCQRS.Application.CQS.Usuarios.Queries
{
    public class GetUsuariosQuery : IRequest<IEnumerable<Usuario>>
    {

    }
}