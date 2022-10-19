using FilmesAPI.Data;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Inicializando servi�o de conex�o com o banco de dados com o Entity Framework
builder.Services.AddDbContext<AppDbContext>
    (
        opts => opts.UseLazyLoadingProxies().UseMySQL(builder.Configuration.GetConnectionString("FilmeConnection"))
    );

// adicionando autentica��o por token
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(token =>
    {
        token.RequireHttpsMetadata = false;
        token.SaveToken = true;
        token.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey
                (
                    Encoding.UTF8.GetBytes("TuRCN9CoqGc0d2rWMc0pR4suqf8L4OVUlx80cVqLegfxw8M7OqsEcbYXIqKsR164")
                ),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
    };
});

// Adicionando as classes de servi�os
builder.Services.AddScoped<FilmeService, FilmeService>();
builder.Services.AddScoped<CinemaService, CinemaService>();
builder.Services.AddScoped<EnderecoService, EnderecoService>();
builder.Services.AddScoped<GerenteService, GerenteService>();
builder.Services.AddScoped<SessaoService, SessaoService>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// para migrar essa estrutura para um banco de dados,
// utilize o console de gerenciador de gerenciador de pacotes (ferramentas)
// O C�DIGO DEVE ESTAR FUNCIONANDO PARA EXECUTAR OS COMANDOS ABAIXO!
// Add-Migration CriandoTabelaDeFilme
// Update-Database
// Para remover as migra��es do banco de dados e come�ar do zero, fa�a o seguinte:
// abra o workbench do mysql
// d� um drop em todas as tabelas individualmente
// abra o console do gerenciador de pacotes do nuget
// update-database 0
// remove-migration
// add-migration "recome�ando"
// update-database
// https://stackoverflow.com/questions/38961115/build-failed-on-database-first-scaffold-dbcontext
