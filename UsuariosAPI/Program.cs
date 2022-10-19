using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosAPI.Data;
using UsuariosAPI.Models;
using UsuariosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


// Inicializando o servi�o do automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Utilizando o banco com o Identity
// https://stackoverflow.com/questions/71011516/c-sharp-entity-framework-core-unable-to-resolve-service
builder.Services.AddDbContext<UserDbContext>
(
    options => options.UseMySQL(builder.Configuration.GetConnectionString("UsuarioConnection"))
);
builder.Services.AddIdentity<CustomIdentityUser, IdentityRole<int>>
    (
        opt => opt.SignIn.RequireConfirmedAccount = false
        //opt => opt.SignIn.RequireConfirmedAccount = true
    )
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();


// alterando os padr�es de senhas exigidos pelo identity
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = true; // exige caracteres especiais
    options.Password.RequireUppercase = true;       // exige letras mai�sculas
    options.Password.RequireLowercase = true;       // exige letras min�sculas
    options.Password.RequiredLength = 6;            // exige pelo menos 6 caracteres
});


// injetando os servi�os
builder.Services.AddScoped<CadastroService, CadastroService>();
builder.Services.AddScoped<EmailService, EmailService>();
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<LogoutService, LogoutService>();
builder.Services.AddScoped<TokenService, TokenService>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
