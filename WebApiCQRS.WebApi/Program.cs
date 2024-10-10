using WebApiCQRS.WebApi.Endpoints.Usuario;
using WebApiCQRS.IoC.Dependency;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencies();

builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new() 
        { 
            Title = "ApiExemplo", 
            Description = "Exemplo de uso de CQRS",
            Version = "v1",
            Contact = new()
            {
                Name = "Marcelo Gomes",
                Url = new("https://github.com/marcelogcatnguiba/")
            }
        });
});

var app = builder.Build();

app.Services.AddDataBase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.DocumentTitle = "ApiExemplo";
    });
}

app.UsuarioEndpointMap();
app.UseHttpsRedirection();
app.Run();