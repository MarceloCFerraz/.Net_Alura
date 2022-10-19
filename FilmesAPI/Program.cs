using FilmesAPI.Data;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Inicializando serviço de conexão com o banco de dados com o Entity Framework
builder.Services.AddDbContext<AppDbContext>
    (
        opts => opts.UseLazyLoadingProxies().UseMySQL(builder.Configuration.GetConnectionString("FilmeConnection"))
    );

// adicionando autenticação por token
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

// Adicionando as classes de serviços
builder.Services.AddScoped<FilmeService, FilmeService>();
builder.Services.AddScoped<CinemaService, CinemaService>();
builder.Services.AddScoped<EnderecoService, EnderecoService>();
builder.Services.AddScoped<GerenteService, GerenteService>();
builder.Services.AddScoped<SessaoService, SessaoService>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// para migrar essa estrutura para um banco de dados,
// utilize o console de gerenciador de gerenciador de pacotes (ferramentas)
// O CÓDIGO DEVE ESTAR FUNCIONANDO PARA EXECUTAR OS COMANDOS ABAIXO!
// Add-Migration CriandoTabelaDeFilme
// Update-Database
// Para remover as migrações do banco de dados e começar do zero, faça o seguinte:
// abra o workbench do mysql
// dê um drop em todas as tabelas individualmente
// abra o console do gerenciador de pacotes do nuget
// update-database 0
// remove-migration
// add-migration "recomeçando"
// update-database
// https://stackoverflow.com/questions/38961115/build-failed-on-database-first-scaffold-dbcontext
