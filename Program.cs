using Microsoft.EntityFrameworkCore;
using EFPractica;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p =>p.UseInMemoryDatabase("TareaDB")); //para conectar a db en memoria

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

//app.MapGet("/prueba", () => { return "Hello!"; });

//mapeo de metodo (endpoint: dbconexion) 
app.MapGet("/dbconexion", /*async*/ ([FromServices] TareasContext dbContext) =>
{
    //var tareaAwait = await File.ReadAllTextAsync("tareas.json");        //variables agregadas por mi para hacer el metodo async
    //var categoriaAwait = await File.ReadAllTextAsync("categorias.json");
    dbContext.Database.EnsureCreated();
    return Results.Ok($"Base de datos en memoria:  {dbContext.Database.IsInMemory()} ");
});

/*
app.MapGet("/apiTareas", ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.TareaDb);
});
*/

app.UseHttpsRedirection();
app.Run();
