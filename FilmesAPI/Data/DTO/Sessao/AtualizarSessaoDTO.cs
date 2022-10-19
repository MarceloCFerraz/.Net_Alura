using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.Sessao
{
    public class AtualizarSessaoDTO
    {
        public DateTime HoraDeInicio { get; set; }
        public int cinemaID { get; set; }
        public int filmeID { get; set; }
    }
}
