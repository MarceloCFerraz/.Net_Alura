using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Criando relacionamento 1 para 1
            builder.Entity<Endereco>() // dentro da entidade Endereço
                .HasOne(endereco => endereco.Cinema) // há uma relação com um cinema
                .WithOne(cinema => cinema.Endereco) // esse cinema também possui um endereço
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId); // e o Cinema cinema guarda a chave estrangeira em EnderecoId
            // dessa forma, um cinema precisa que um endereço exista antes

            builder.Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteID);
            // .OnDelete(DeleteBehavior.Restrict); ou
            // .IsRequired(false);

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
