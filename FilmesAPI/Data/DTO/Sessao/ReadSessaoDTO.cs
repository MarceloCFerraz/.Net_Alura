using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.Sessao
{
    public class ReadSessaoDTO
    {
        public int Id { get; set; }
        public Models.Cinema Cinema { get; set; }
        public Models.Filme Filme { get; set; }
        public DateTime HoraDeInicio { get; set; }
        public DateTime HoraDeTermino { get; set; }
    }
}
