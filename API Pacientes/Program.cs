using API_Pacientes.Data;
using API_Pacientes.Services;
using Microsoft.EntityFrameworkCore;


string politicaCORS = "AllowEverything";

var builder = WebApplication.CreateBuilder(args);

// Inicializando servi�o de conex�o com o banco de dados com o Entity Framework
builder.Services.AddDbContext<AppDbContext>
(
    opts => opts.UseLazyLoadingProxies()
            .UseMySQL(builder.Configuration.GetConnectionString("PacienteConnection"))
);

// Adicionando pol�tica de Cross-Origin Resource Sharing (CORS)
builder.Services.AddCors(options =>
{
    options.AddPolicy(politicaCORS, builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// Add services to the container.
// Adicionando as classes de servi�os
builder.Services.AddScoped<PacienteService, PacienteService>();
// Inicializando servi�o do automapper para facilitar convers�es de objetos com campos semelhantes
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(politicaCORS);

app.UseAuthorization();

app.MapControllers();

app.Run();
