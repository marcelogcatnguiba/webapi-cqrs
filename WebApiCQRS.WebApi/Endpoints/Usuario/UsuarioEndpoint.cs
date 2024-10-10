using MediatR;
using WebApiCQRS.Application.CQS.Usuarios.Commands;
using WebApiCQRS.Application.CQS.Usuarios.Queries;

namespace WebApiCQRS.WebApi.Endpoints.Usuario
{
    public static class UsuarioEndpoint
    {
        public static void UsuarioEndpointMap(this WebApplication app)
        {
            var usuarioMap = app.MapGroup("Usuario");
            
            usuarioMap.MapGet("/", GetAll);
            usuarioMap.MapGet("/{id}", Get);
            usuarioMap.MapPost("/", Create);
            usuarioMap.MapPut("/", Update);
            usuarioMap.MapDelete("/{id}", Delete);

            static async Task<IResult> GetAll(IMediator mediator) => 
                Results.Ok(await mediator.Send(new GetUsuariosQuery()));

            static async Task<IResult> Get(IMediator mediator, int id) => 
                await mediator.Send(new GetUsuarioByIdQuery(id)) is {} user 
                    ? Results.Ok(user)
                    : Results.NotFound("Usuario nao encontrado !!!");

            static async Task<IResult> Create(IMediator mediator, UsuarioCreateCommand command)
            {
                await mediator.Send(command);
                return Results.Ok();
            };

            static async Task<IResult> Update(IMediator mediator, UsuarioUpdateCommand command)
            {
                await mediator.Send(command);
                return Results.Created();
            }

            static async Task<IResult> Delete(IMediator mediator, int id)
            {
                await mediator.Send(new UsuarioDeleteCommand() { Id = id });
                return Results.Ok();
            }
        }
    }
}