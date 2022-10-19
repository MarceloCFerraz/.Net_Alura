using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public DateTime HoraDeInicio { get; set; }
        public DateTime HoraDeTermino { get; set; }
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public virtual Cinema Cinema { get; set; }
        public int CinemaId { get; set; }
    }
}
