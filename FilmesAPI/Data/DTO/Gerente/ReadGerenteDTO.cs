using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.Gerente
{
    public class ReadGerenteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Cinemas { get; set; }
    }
}
