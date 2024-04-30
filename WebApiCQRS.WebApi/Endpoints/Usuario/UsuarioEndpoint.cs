using MediatR;
using WebApiCQRS.Application.CQS.Usuarios.Commands;
using WebApiCQRS.Application.CQS.Usuarios.Queries;

namespace WebApiCQRS.WebApi.Endpoints.Usuario
{
    public static class UsuarioEndpoint
    {
        public static void UsuarioEndpointMap(this WebApplication app)
        {
            app.MapGet("Usuario", async (IMediator mediator) =>
                Results.Ok(await mediator.Send(new GetUsuariosQuery()))
            );

            app.MapGet("Usuarios/{id}", async (int id, IMediator mediator) =>
                {
                    var user = await mediator.Send(new GetUsuarioByIdQuery(id));
                    return user is null
                        ? Results.NotFound("Usuario nao encontrado !!!")
                        : Results.Ok(user);
                });

            app.MapPost("Usuarios", async (IMediator mediator, UsuarioCreateCommand command) =>
            {
                await mediator.Send(command);
                return Results.Ok();
            });

            app.MapPut("Usuario/", async (IMediator mediator, UsuarioUpdateCommand command) =>
            {
                await mediator.Send(command);
                return Results.Created();
            });

            app.MapDelete("Usuario/{id}", async (IMediator mediator, int id) =>
            {
                await mediator.Send(new UsuarioDeleteCommand() { Id = id });
                return Results.Ok();
            });
        }
    }
}