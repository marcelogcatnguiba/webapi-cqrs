using WebApiCQRS.WebApi.Endpoints.Usuario;
using WebApiCQRS.IoC.Dependency;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencies();

var app = builder.Build();

app.Services.AddDataBase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UsuarioEndpointMap();
app.UseHttpsRedirection();
app.Run();