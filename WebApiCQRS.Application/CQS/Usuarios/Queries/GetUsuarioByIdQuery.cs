using MediatR;
using WebApiCQRS.Domain.Entities;

namespace WebApiCQRS.Application.CQS.Usuarios.Queries
{
    public class GetUsuarioByIdQuery : IRequest<Usuario>
    {
        public int Id { get; set; }
        public GetUsuarioByIdQuery(int id)
        {
            Id = id;
        }
    }
}