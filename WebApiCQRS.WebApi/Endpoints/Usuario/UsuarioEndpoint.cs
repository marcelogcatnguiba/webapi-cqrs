using MediatR;
using WebApiCQRS.Application.CQS.Usuarios.Commands;
using WebApiCQRS.Application.CQS.Usuarios.Queries;
using Domain = WebApiCQRS.Domain.Entities;

namespace WebApiCQRS.WebApi.Endpoints.Usuario
{
    public static class UsuarioEndpoint
    {
        public static void UsuarioEndpointMap(this WebApplication app)
        {
            var usuarioMap = app.MapGroup("Usuario");
            
            usuarioMap
                .MapGet("/{id}", Get)
                .Produces<Domain::Usuario>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            usuarioMap
                .MapGet("/", GetAll)
                .Produces<List<Domain::Usuario>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent);

            usuarioMap
                .MapPost("/", Create)
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest);

            usuarioMap
                .MapPut("/", Update)
                .Produces(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            usuarioMap
                .MapDelete("/{id}", Delete)
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            static async Task<IResult> Get(IMediator mediator, int id)
            {
                return await mediator.Send(new GetUsuarioByIdQuery(id)) is {} user 
                    ? Results.Ok(user)
                    : Results.NotFound("Usuario nao encontrado !!!");
            }
            
            static async Task<IResult> GetAll(IMediator mediator)
            {
                return await mediator.Send(new GetUsuariosQuery()) is {} users
                    ? Results.Ok(users)
                    : Results.NoContent();
            }
                
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
                try
                {
                    await mediator.Send(new UsuarioDeleteCommand() { Id = id });
                    return Results.Ok();    
                }
                catch
                {
                    return Results.NotFound("Usuario não encontrado");
                }
                
            }
        }
    }
}