using GerenciaServidoresAPI.Persistence;
using GerenciaServidoresAPI.Application.Commands.CreateServidor;
using GerenciaServidoresAPI.Application.Commands.UpdateServidor;
using GerenciaServidoresAPI.Application.Commands.DeleteServidor;
using GerenciaServidoresAPI.Application.Queries.GetServidores;
using GerenciaServidoresAPI.Application.Validators;
using GerenciaServidoresAPI.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddMediatR(typeof(CreateServidorCommand).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<CreateServidorCommandValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();

//utilizar swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gerencia Servidores API", Version = "v1" });
});

//Utilizando SQLite como banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"));

// Endpoints
app.MapGet("/api/servidores", async (
    [AsParameters] GetServidoresQuery query,
    IMediator mediator) =>
{
    var result = await mediator.Send(query);
    return Results.Ok(result);
});

app.MapPost("/api/servidores", async (
    CreateServidorCommand command,
    IValidator<CreateServidorCommand> validator,
    IMediator mediator) =>
{
    var validationResult = await validator.ValidateAsync(command);
    if (!validationResult.IsValid)
        return Results.BadRequest(validationResult.Errors);

    var result = await mediator.Send(command);
    return Results.Created($"/api/servidores/{result.Id}", result);
});

app.MapPut("/api/servidores/{id:guid}", async (
    Guid id,
    UpdateServidorCommand command,
    IValidator<UpdateServidorCommand> validator,
    IMediator mediator) =>
{
    if (id != command.Id)
        return Results.BadRequest("ID do corpo difere do ID da URL");

    var validationResult = await validator.ValidateAsync(command);
    if (!validationResult.IsValid)
        return Results.BadRequest(validationResult.Errors);

    var result = await mediator.Send(command);
    return result is null ? Results.NotFound() : Results.Ok(result);
});

app.MapDelete("/api/servidores/{id:guid}", async (
    Guid id,
    IMediator mediator) =>
{
    var result = await mediator.Send(new DeleteServidorCommand(id));
    return result ? Results.NoContent() : Results.NotFound();
});

// Start
app.Run();
