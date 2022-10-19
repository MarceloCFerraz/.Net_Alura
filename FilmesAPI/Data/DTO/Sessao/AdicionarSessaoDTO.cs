using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.Sessao
{
    public class AdicionarSessaoDTO
    {
        [Required]
        public int cinemaID{ get; set; }
        [Required]
        public int filmeID{ get; set; }
        [Required]
        public DateTime HoraDeInicio { get; set; }
    }
}
