using API_Pacientes.Data;
using API_Pacientes.Services;
using Microsoft.EntityFrameworkCore;


string politicaCORS = "AllowEverything";

var builder = WebApplication.CreateBuilder(args);

// Inicializando serviço de conexão com o banco de dados com o Entity Framework
builder.Services.AddDbContext<AppDbContext>
(
    opts => opts.UseLazyLoadingProxies()
            .UseMySQL(builder.Configuration.GetConnectionString("PacienteConnection"))
);

// Adicionando política de Cross-Origin Resource Sharing (CORS)
builder.Services.AddCors(options =>
{
    options.AddPolicy(politicaCORS, builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// Add services to the container.
// Adicionando as classes de serviços
builder.Services.AddScoped<PacienteService, PacienteService>();
// Inicializando serviço do automapper para facilitar conversões de objetos com campos semelhantes
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
