using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["Database:SqlServer"]);
var app = builder.Build();
var configuration = app.Configuration;
RepositorioUsuario.Init(configuration);

//Insere os dados no banco
app.MapPost("/usuario", (UsuarioRequest usuarioRequest, ApplicationDbContext context) =>
{
    var usuario = new Usuario
    {
        Id = usuarioRequest.Id,
        Nome = usuarioRequest.Nome,
        Sobrenome = usuarioRequest.Sobrenome,
        Email = usuarioRequest.Email,
        Dt = usuarioRequest.Dt,
        Escolaridade = usuarioRequest.Escolaridade
    };
    context.Usuarios.Add(usuario);
    context.SaveChanges();
    return Results.Accepted("/usuario/" + usuario.Id, usuario.Id);
});

//Busca somente um usuario para consulta
app.MapGet("/usuario/{id}", ([FromRoute] string id, ApplicationDbContext context) =>
{
    var usuario = context.Usuarios.Where(p => p.Id == id).First();

    //verifica se o usuario eiste
    if (usuario != null)
        return Results.Ok(usuario);
    return Results.NotFound();
});

//atualiza somente um usuario
app.MapPut("/usuario/{id}", ([FromRoute] string id, UsuarioRequest usuarioRequest, ApplicationDbContext context) =>
{
    var usuario = context.Usuarios
    .Where(p => p.Id == id).First();

    usuario.Id = usuarioRequest.Id;
    usuario.Nome = usuarioRequest.Nome;
    usuario.Sobrenome = usuarioRequest.Sobrenome;
    usuario.Email = usuarioRequest.Email;
    usuario.Dt = usuarioRequest.Dt;
    usuario.Escolaridade = usuarioRequest.Escolaridade;


    context.SaveChanges();
    return Results.Ok();
});

//deleta os dados de um usuario
app.MapDelete("/usuario/{id}", ([FromRoute] string id, ApplicationDbContext context) =>
{
    var usuario = context.Usuarios
    .Where(p => p.Id == id).First();
    context.Usuarios.Remove(usuario);
    context.SaveChanges();
    return Results.Ok();
});

//retorna a conexão com o banco
app.MapGet("/configuration/database", (IConfiguration configuration) =>
{
    return Results.Ok($"{configuration["database:connection"]}/{configuration["database:port"]}");
});

app.Run();
